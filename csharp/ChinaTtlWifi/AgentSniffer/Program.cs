using ChinaTtlWifi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Common.ActiveMQUtil;
using Wims.Common;
using System.Threading;
using Apache.NMS;
using AgentUtil;
using MqUtil;
using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewEntity;
using ChinaTtlWifi.NewBll;
using Wims.Common.MongoDBUtil;
using System.Net.Sockets;
using MongoDB.Driver;


namespace AgentChariot
{
    class Program
    {
        private static string AGENT_NAME { get; set; }
        private static string AGENT_FILTER { get; set; }
        private static TestResultBll resultBll = TestResultBll.GetInst();
        private static MongoUtil<Project> projectBll = DbFactory.ProjectBll;
        private static MongoUtil<TestCase> caseBll = DbFactory.TestCaseBll;
        private static LogBll log { get; set; }
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            try
            {
                CommonConfig.ConfigBll.GetInst().LoadConfig();
                AGENT_NAME = GlobalValues.AGENT_NAME;
                AGENT_FILTER = GlobalValues.AGENT_FILTER;
                log = LogBll.GenLogBll(GlobalValues.AGENT_NAME);
                Thread t = new Thread(() => startListen());
                t.Start();
                for (; ; )
                {
                    log.HeartBeat("I'm alive");
                    Thread.Sleep(1000 * 20);
                }
            }
            catch (MongoConnectionException ex)
            {
                Console.WriteLine("无法连接到server端！请检查ip配置及网络连接后重试");
            }
            catch (SocketException ex)
            {
                Console.WriteLine("连接被中断，请检查网络连接，重启本程序！\n" + "错误信息：" + ex.Message);
            }
        }

        private static void startListen()
        {
            MqConsumerQueue.GetInst(consumer_Listener, AGENT_NAME, AGENT_FILTER);
            log.Info(AGENT_NAME + "开始监听");
        }

        private static void consumer_Listener(IMessage message)
        {
            string projectId = string.Empty;
            try
            {
                ITextMessage msg = (ITextMessage)message;
                Dictionary<string, object> param = MqConsumerBase.ReadMapFromJson(msg.Text);
                IAgentApiChariot chariotBll = ChariotFactory.GetChariot(param["deviceModel"].ToString());
                projectId = param["projectId"].ToString();
                log.Info(msg.NMSMessageId, projectId);
                if (msg.NMSType == "TestThroughput")
                {
                    string param1 = param["param1"].ToString();
                    //string param2 = param["param2"].ToString();
                    //string param3 = param["param3"].ToString();
                    string param4 = param["param4"].ToString();
                    ////string param5 = param["param5"].ToString();
                    ////string param6 = param["param6"].ToString();
                    string ping = "ping 127.0.0.1 -n 30 >nul";
                    List<string> commandList = new List<string>() { param1, ping,/* param2, ping, param3, ping,*/ param4, ping, /*param5, ping, param6, */ping + "&exit" };
                    CmdHelper.SendCmdCommandList(commandList);
                    WriteLogAndSendResponse(msg.NMSMessageId, "回复消息，我已经完成任务！", StepTestStatus.测试通过, "", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
                else if (msg.NMSType == "AnalysisResult")
                {
                    List<string> resultList = new List<string>();
                    string filePath1 = param["FilePath1"].ToString();
                    //string filePath2 = param["FilePath2"].ToString();
                    //string filePath3 = param["FilePath3"].ToString();
                    resultList.Add(chariotBll.GetTestValue(filePath1));
                    //resultList.Add(AnalysisResult.GetTestValue(filePath2));
                    //resultList.Add(AnalysisResult.GetTestValue(filePath3));
                    TestResult testResult = new TestResult();
                    testResult.ProjectId = param["projectId"].ToString();
                    testResult.CaseId = param["caseId"].ToString();
                    testResult.CreateTime = DateTime.Now;
                    testResult.IsPass = true;
                    testResult.Result = new List<double>();
                    TestCase testCase = caseBll.SelectById(testResult.CaseId);
                    StepTestStatus testStatus = StepTestStatus.测试通过;
                    string reponseMsg = "回复消息 我已完成任务";
                    if (testCase.LimitList.Count != resultList.Count)
                    {
                        testStatus = StepTestStatus.测试异常;
                        reponseMsg = "回复消息 测试结果数量与限值数量不一致！";
                        testResult.IsPass = false;
                    }
                    else
                    {
                        for (int i = 0; i < testCase.LimitList.Count; i++)
                        {
                            double value = Convert.ToDouble(resultList[i]);
                            if (testCase.LimitList[i] > value)
                            {
                                testResult.IsPass = false;
                                testStatus = StepTestStatus.测试未通过;
                            }
                            testResult.Result.Add(value);
                        }
                    }
                    resultBll.Insert(testResult);

                    WriteLogAndSendResponse(msg.NMSMessageId, reponseMsg, testStatus, "", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info(ex.Message, projectId);
            }
        }

        private static void WriteLogAndSendResponse(string msgId, string logMsg, StepTestStatus result, string resultMsg, string projectId, string caseId, string stepId)
        {
            log.Info(logMsg, msgId);
            MqAgentProducer.SendResponse(msgId, result, resultMsg, projectId, caseId, stepId);
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("出现未处理的异常,异常如下:" + e.ExceptionObject.ToString());
        }
    }
}
