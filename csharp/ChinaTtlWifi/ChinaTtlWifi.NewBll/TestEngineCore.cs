using Apache.NMS;
using ChinaTtlWifi.NewEntity;
using MqUtil;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace ChinaTtlWifi.NewBll
{
    public class TestEngineCore
    {



        private TestEngineCore()
        {
        }


        public static TestEngineCore GetInst(Project project)
        {
            if (inst == null)
            {
                inst = new TestEngineCore();
            }
            inst.currentProject = project;
            return inst;
        }

        public void Init()
        {
            this.dicReturnMsg.Clear();
            MqMasterConsumer.GetInst(inst.MasterListener);
        }

        private void MasterListener(IMessage message)
        {
            if (message is ITextMessage)
            {
                ITextMessage textMsg = (ITextMessage)message;
                string text = textMsg.Text;
                Dictionary<string, object> dic = Wims.Common.ActiveMQUtil.MqConsumerBase.ReadMapFromJson(text);
                string oriMsgId = dic["correlationId"].ToString();
                if (this.dicReturnMsg.Keys.Contains(oriMsgId))
                {
                    var entity = this.dicReturnMsg[oriMsgId];
                    entity.HasReturn = true;
                    entity.ResultString = dic["msg"].ToString();
                    entity.ResultStatus = (StepTestStatus)Enum.Parse(typeof(StepTestStatus), dic["result"].ToString());
                }
                this.CheckStatus();
            }
        }
        /// <summary>
        /// 根据字典判断整个测试的状态
        /// </summary>
        private void CheckStatus()
        {
            bool projectPass = true;
            foreach (var instCase in this.currentProject.CaseList)
            {
                bool casePass = true;
                foreach (var instStep in instCase.StepList)
                {
                    foreach (var obj in this.dicReturnMsg.Values)
                    {
                        if (!obj.HasReturn)
                        {
                            continue;
                        }
                        if (obj.StepId == instStep.Id)
                        {
                            instStep.Status = obj.ResultStatus.ToString();
                            if (instStep.Status == TestStatus.测试异常)
                            {
                                this.Status = instStep.Status;
                                return;
                            }
                            break;
                        }
                    }

                    if (instStep.Status != TestStatus.测试通过)
                    {
                        casePass = false;
                    }

                }
                if (casePass)
                {
                    instCase.Status = TestStatus.测试通过;
                }
                else
                {
                    projectPass = false;
                }
            }
            if (projectPass)
            {
                this.currentProject.Status = TestStatus.测试通过;
            }
        }


        public void Run()
        {
            if (this.currentProject == null || this.currentProject.CaseList == null)
            {
                throw new ArgumentException("current project is null");
            }
            this.currentProject.Status = TestStatus.测试中;
            foreach (var testCase in this.currentProject.CaseList)
            {
                this.currentCase = testCase;
                if (testCase == null || testCase.StepList == null)
                {
                    throw new ArgumentException("current case is null");
                }
                this.currentCase.Status = TestStatus.测试中;
                foreach (var step in testCase.StepList)
                {
                    while (isPause)
                    {
                        this.currentProject.Status = TestStatus.测试暂停;
                        Thread.Sleep(1000);
                    }
                    if (isZhongZhi)
                    {
                        this.currentProject.Status = TestStatus.终止任务;
                        isZhongZhi = false;
                        return;
                    }
                    this.currentStep = step;
                    this.ExecAction();

                }
            }

        }
        public void Pause(bool isPause)
        {
            lock (lock1)
            {
                this.isPause = isPause;
                this.Status = this.isPause ? TestStatus.测试暂停 : TestStatus.测试中;
            }
        }
        public void ExecAction()
        {
            log.Write(this.currentProject.Id, "执行action: " + this.currentStep.Command.Cmd, this.currentCase.Id);
            string ret = string.Empty;
            Thread.Sleep(this.currentStep.Command.Predelay * 1000);
            Dictionary<string, object> param = new Dictionary<string, object>();
            foreach (var inst in this.currentStep.Params.ParamList.ToLookup(s => s.Key))
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
            param.Add("projectId", this.currentProject.Id);
            param.Add("caseId", this.currentCase.Id);
            param.Add("stepId", this.currentStep.Id);
            param.Add("deviceModel", this.currentStep.TestDeviceModel);

            string msgId = MqMasterProducer.SendAction(this.currentStep.AgentType.ToString(), this.currentStep.Command.Cmd, param, this.currentStep.AgentFilter);
            log.Write(this.currentProject.Id, string.Format("发送消息给{0}，其命令是{1}", this.currentStep.AgentType.ToString(), this.currentStep.Command.Cmd), this.currentCase.Id);
            this.dicReturnMsg.Add(msgId, new TestMsg(this.currentProject.Id, this.currentCase.Id, this.currentStep.Id));
            bool isResive = false;

            if (this.currentStep.Command.WaitResponse)
            {
                int count = 0;
                while (!isResive)
                {
                    Thread.Sleep(1000);
                    count++;
                    if (count > 3600)
                    {
                        this.Status = TestStatus.测试异常;
                        Console.WriteLine("超时");
                        break;
                    }
                    foreach (var obj in this.dicReturnMsg.Values)
                    {
                        if (!obj.HasReturn)
                        {
                            continue;
                        }
                        if (obj.StepId == this.currentStep.Id)
                        {
                            isResive = true;
                            break;
                        }
                    }

                }
            }
            Thread.Sleep(this.currentStep.Command.Postdelay * 1000);
        }

        private LinkedListNode<Step> currentStepNode;
        private LinkedListNode<TestCase> currentCaseNode;
        private bool isPause = false;
        private bool isZhongZhi = false;

        public bool IsZhongZhi
        {
            get { return isZhongZhi; }
            set { isZhongZhi = value; }
        }




        private class TestMsg
        {

            public TestMsg(string projectId, string caseId, string stepId)
            {
                this.ProjectId = projectId;
                this.CaseId = caseId;
                this.StepId = stepId;
                this.ResultStatus = StepTestStatus.测试未开始;
                this.ResultString = string.Empty;
                this.HasReturn = false;
            }
            //一个步骤的超时时间，目前是1小时
            private const int _stepTimeout = 3600000;

            //    public string MsgId { get; set; }
            public string ProjectId { get; set; }
            public string CaseId { get; set; }
            public string StepId { get; set; }
            public string ResultString { get; set; }
            public StepTestStatus ResultStatus { get; set; }

            public bool HasReturn { get; set; }
        }
        private static TestEngineCore inst;
        private TestLogBll log = TestLogBll.GetInst();
        private Project currentProject;
        public Step currentStep { get; set; }
        private TestCase currentCase;

        private Dictionary<string, TestMsg> dicReturnMsg = new Dictionary<string, TestMsg>();



        private static object lock1 = new object();


        public string Status { get; set; }

    }
}
