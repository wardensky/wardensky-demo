using AgentUtil;
using Apache.NMS;
using ChinaTtlWifi.Base;
using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using CommonConfig;
using MongoDB.Driver;
using MqUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Wims.Common;
using Wims.Common.ActiveMQUtil;
using Wims.Common.MongoDBUtil;

namespace AgentIperf
{
    class Program
    {
        private static LogBll log { get; set; }

        private static TestLogBll testLog { get; set; }
        private static string AGENT_NAME { get; set; }
        private static string AGENT_FILTER { get; set; }

        private static string IPERF_PATH { get; set; }
        private static TestResultBll resultBll = TestResultBll.GetInst();
        private static MongoUtil<Project> projectBll = DbFactory.ProjectBll;
        private static MongoUtil<TestCase> caseBll = DbFactory.TestCaseBll;
        static void Main(string[] args)
        {



            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            try
            {
                ConfigBll.GetInst().LoadConfig();
                AGENT_NAME = GlobalValues.AGENT_NAME;
                AGENT_FILTER = GlobalValues.AGENT_FILTER;
                log = LogBll.GenLogBll(AGENT_NAME);
                testLog = TestLogBll.GetInst();
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
            string caseId = string.Empty;
            try
            {
                ITextMessage msg = (ITextMessage)message;
                Dictionary<string, object> param = MqConsumerBase.ReadMapFromJson(msg.Text);
                IAgentApiIperf iperfBll = IperfFactory.GetAp(param["deviceModel"].ToString());
                projectId = param["projectId"].ToString();
                log.Info(msg.NMSMessageId, projectId);
                if (msg.NMSType == "StartListen" | msg.NMSType == "StartSend")
                {
                    IPERF_PATH = param["FilePath"].ToString();
                    string cmd = param["cmd"].ToString();
                    if (msg.NMSType == "StartListen")
                    {
                        string logpath = param["logpath"].ToString();
                        string temp = logpath.Remove(logpath.LastIndexOf("\\"));
                        DirectoryInfo di = new DirectoryInfo(temp);
                        if (!di.Exists)
                        {
                            di.Create();
                        }
                        FileInfo fi = new FileInfo(logpath);
                        if (fi.Exists)
                        {
                            fi.MoveTo(fi.DirectoryName + @"\" + fi.LastWriteTime.ToString("yyyyMMddHHmm") + fi.Name);
                        }
                        cmd += " " + logpath;
                    }
                    iperfBll.StartLinten(IPERF_PATH, cmd);
                    WriteLogAndSendResponse(msg.NMSMessageId, "完成测试", StepTestStatus.测试通过, "", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
                if (msg.NMSType == "AnalysisResult")
                {
                    if (!string.IsNullOrEmpty(IPERF_PATH))
                    {
                        ProcessHelper.KillProcessByFileName(IPERF_PATH);
                    }
                    List<string> resultList = new List<string>();
                    caseId = param["projectId"].ToString();
                    string filePath1 = param["FilePath1"].ToString();
                    FileInfo fi = new FileInfo(filePath1);
                    TestResult testResult = resultBll.SelectFirstBy("CaseId", caseId);
                    bool isFirst = false;
                    if (testResult == null)
                    {
                        isFirst = true;
                        testResult = new TestResult();
                        testResult.ProjectId = param["projectId"].ToString();
                        testResult.CaseId = param["caseId"].ToString();
                        testResult.CreateTime = DateTime.Now;
                        testResult.IsPass = true;
                        testResult.Result = new List<double>();
                    }
                    TestCase testCase = projectBll.SelectById(testResult.ProjectId).CaseList.Where(s => s.Id == testResult.CaseId).FirstOrDefault();
                    StepTestStatus testStatus = StepTestStatus.测试通过;
                    string reponseMsg = "回复消息 我已完成任务";
                    if (!fi.Exists)
                    {
                        testStatus = StepTestStatus.测试异常;
                        reponseMsg = "回复消息 测试未生成结果文件！";
                        testResult.IsPass = false;
                    }
                    else
                    {
                        int index = int.Parse(param["index"].ToString());
                        if (index > testCase.LimitList.Count && index <= 0)
                        {
                            testStatus = StepTestStatus.测试异常;
                            reponseMsg = "回复消息 测试时限值索引值与测试例中限值范围不符！";
                            testResult.IsPass = false;
                        }
                        else
                        {
                            double value = iperfBll.GetResult(filePath1);
                            if (value >= testCase.LimitList[index - 1])
                            {
                                testStatus = StepTestStatus.测试通过;
                                reponseMsg = "回复消息 测试通过，测试限值为" + value;
                                testResult.Result.Add(value);
                                testResult.IsPass = true;
                            }
                            else
                            {
                                testStatus = StepTestStatus.测试未通过;
                                reponseMsg = "回复消息 测试未通过，测试限值为" + value;
                                testResult.IsPass = false;
                            }
                        }
                    }
                    if (isFirst)
                    {
                        resultBll.Insert(testResult);
                    }
                    else
                    {
                        resultBll.UpdateBy("CaseId", testResult);
                    }

                    WriteLogAndSendResponse(msg.NMSMessageId, reponseMsg, testStatus, "", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info(ex.Message, projectId);
                testLog.Write(projectId, ex.Message, caseId);
            }
        }



        private static void WriteLogAndSendResponse(string msgId, string logMsg, StepTestStatus result, string resultMsg, string projectId, string caseId, string stepId)
        {
            log.Info(logMsg, msgId);
            testLog.Write(projectId, logMsg, caseId);
            MqAgentProducer.SendResponse(msgId, result, resultMsg, projectId, caseId, stepId);
        }
        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("出现未处理的异常,异常如下:" + e.ExceptionObject.ToString());
        }
    }
}
