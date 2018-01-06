using Apache.NMS;
using ChinaTtlWifi.Base;
using ChinaTtlWifi.Entity;
using MqUtil;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;


namespace ChinaTtlWifi.Bll
{
    public class TaskEngineCore
    {
        private static LogBll log = LogBll.GenLogBll("Master");
        private bool isPause = false;
        private Task currentTask;
        private Case currentScript;
        private static object lock1 = new object();
        private ConcurrentDictionary<string, bool> msgReturnDic = new ConcurrentDictionary<string, bool>();
        private ConcurrentDictionary<string, Response> responseReturnDic = new ConcurrentDictionary<string, Response>();

        public string Status { get; set; }
        public string StepStatus { get; set; }
        public Step currentStep { get; set; }
        private TaskEngineCore()
        {
        }

        private static TaskEngineCore inst;
        public static TaskEngineCore GetInst(Task currentTask)
        {
            if (inst == null)
            {
                inst = new TaskEngineCore();
            }
            inst.currentTask = currentTask;
            return inst;
        }

        public void Init(Case TestCase)
        {
            Console.WriteLine("给case赋值，case是" + TestCase.Id);

            this.currentScript = TestCase;
            this.msgReturnDic.Clear();
            this.responseReturnDic.Clear();
            MqMasterConsumer.GetInst(inst.MasterListener);
        }


        public void Pause(bool isPause)
        {

            lock (lock1)
            {
                this.isPause = isPause;
                this.Status = this.isPause ? TaskStatus.测试暂停 : TaskStatus.测试中;
            }
        }

        /// <summary>
        /// 查找下一步。
        /// 如果是currentStep空，则查找第一步。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Step FindNextStep(string condition)
        {
            Step nextStep = null;
            if (this.currentStep == null)
            {
                nextStep = this.currentScript.StepList.OrderBy(a => a.Id).First();
                goto finish;
            }
            if (this.currentStep.Id == 99)
            {
                this.Status = TaskStatus.测试完成;
                nextStep = this.currentStep;
                goto finish;
            }
            if (string.IsNullOrEmpty(condition))
            {
                nextStep = this.currentScript.StepList.Where(a => a.Id == this.currentStep.NextStepId).FirstOrDefault();
                goto finish;
            }
            else
            {
                nextStep = this.currentScript.StepList.Where(a => a.Id == this.currentStep.Id && a.Conditon == condition).FirstOrDefault();
                goto finish;
            }
        finish:
            if (nextStep != null)
            {
                log.Info("查找下一步, 名称是：" + nextStep.Name, this.currentTask.Id);
            }
            return nextStep;
        }

        public void Run()
        {

            string condition = "";
            this.Status = TaskStatus.测试中;
            this.currentStep = this.FindNextStep(string.Empty);
            for (; ; )
            {
                this.currentStep.StepStatus = "测试中";
                while (isPause)
                {
                    Thread.Sleep(1000);
                }
                if (this.currentStep.Id == 99)
                {
                    this.currentStep.StepStatus = "测试完成";
                    this.Status = TaskStatus.测试完成;
                    break;
                }
                else if (this.Status == TaskStatus.测试异常)
                {
                    this.Status = TaskStatus.测试异常;
                    break;
                }
                condition = this.ExecAction();
                this.currentStep.StepStatus = "测试完成";
                this.currentStep = this.FindNextStep(condition);
            }
            log.Info("测试完成", this.currentScript.Id);
        }

        public string ExecAction()
        {

            if (this.currentStep.Id == 99)
            {
                this.Status = TaskStatus.测试完成;
                return string.Empty;
            }
            log.Info("执行action: " + this.currentStep.StepAction.Name, this.currentTask.Id);
            string ret = string.Empty;
            Thread.Sleep(this.currentStep.StepAction.Predelay);
            Dictionary<string, object> param = new Dictionary<string, object>();
            foreach (var inst in this.currentStep.StepParams.ParamList.ToLookup(s => s.Key))
            {
                if (inst.Count() != 1)
                {
                    param.Add(inst.Key, inst.Select(s =>
                    {
                        return s.Value;
                    }).ToList());
                }
                else
                {
                    param.Add(inst.Key, inst.FirstOrDefault().Value);
                }

            }
            param.Add("taskId", this.currentTask.Id);
            string msgId = MqMasterProducer.SendAction(this.currentStep.AgentName, this.currentStep.StepAction.Command, param, null);
            log.Info(string.Format("发送消息给{0}，其命令是{1}", this.currentStep.AgentName, this.currentStep.StepAction.Command), this.currentTask.Id);
            if (!this.responseReturnDic.ContainsKey(msgId))
            {
                Response res = new Response();
                this.responseReturnDic.TryAdd(msgId, res);
                res.AgentName = this.currentStep.AgentName;
                res.Command = this.currentStep.StepAction.Command;
                res.orgiMsgId = msgId;
            }
            if (this.currentStep.StepAction.WaitResponse)
            {
                while (true)
                {
                    Thread.Sleep(100);
                    bool isReturn = false;

                    if (this.msgReturnDic.TryGetValue(msgId, out isReturn) && isReturn)
                    {
                        break;
                    }
                }
            }
            Response response = null;

            if (this.responseReturnDic.TryGetValue(msgId, out response))
            {
                ret = response.Condition;
                if (!response.Result)
                {
                    log.Info("命令执行失败", this.currentScript.Id);
                    if (this.currentStep.StepAction.BreakOnFail)
                    {
                        this.Status = TaskStatus.测试异常;
                    }
                }
            }

            Thread.Sleep(this.currentStep.StepAction.Postdelay);
            return ret;
        }


        private void MasterListener(IMessage message)
        {

            if (message is ITextMessage)
            {
                ITextMessage textMsg = (ITextMessage)message;
                string text = textMsg.Text.Replace(" ", "");
                string oriMsgId = Regex.Replace(text, ".*correlationId\":\"(.*?)\".*", "$1");
                string result = Regex.Replace(text, ".*result\":(.*?),.*", "$1").Replace("\"", "");
                string msg = Regex.Replace(text, ".*msg\":\"(.*?)\".*", "$1");
                this.msgReturnDic.TryAdd(oriMsgId, true);
                Response response = null;
                log.Info("接收到返回值 result = " + result + " msg = " + msg, this.currentTask.Id);
                this.CheckIsPass(result, msg);
                if (this.responseReturnDic.TryGetValue(oriMsgId, out response))
                {
                    response.Result = bool.Parse(result);
                    response.Msg = msg;
                    response.CreateTime = DateTime.Now;
                    ResponseBll.GetInst().Insert(response);
                }
            }
        }

        private void CheckIsPass(string result, string msg)
        {
            string stepPass = string.Empty;
            if (result == "true")
            {
                stepPass = "Pass";
            }
            else if (result == "False")
            {
                stepPass = "Fail";
            }
            log.Info(string.Format("{0}{1}执行结果:{3}", this.currentTask.Name, this.currentStep.Name, stepPass));
            if (this.currentStep.NextStepId == 99)
            {
                if (!string.IsNullOrEmpty(msg))
                {
                    log.Error("测试完成时未包含吞吐量数据！");
                }
                else
                {
                    string[] resultValues = msg.Split(',');
                    string[] limitValues = this.currentScript.Limit.Split(',');
                    List<bool> PassList = new List<bool>();
                    for (int i = 0; i < limitValues.Length; i++)
                    {
                        PassList.Add(double.Parse(resultValues[i]) >= double.Parse(limitValues[i]));
                    }
                    if (PassList.Contains(false))
                    {
                        log.Info("吞吐量测试未通过");
                    }
                    else
                    {
                        log.Info("吞吐量测试通过");
                    }
                }
            }
        }
        //public void CheckStatus(out int stepId, out string status)
        //{
        //    string currentStatus = this.Status;
        //    for (; ; )
        //    {
        //        if (currentStatus != this.Status && this.currentStep != null)
        //        {
        //            stepId = this.currentStep.Id;
        //            status = this.Status;
        //        }
        //    }
        //}
    }
}
