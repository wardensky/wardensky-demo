using ChinaTtlWifi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Common.ActiveMQUtil;
using Wims.Common;
using System.Threading;
using Apache.NMS;

using MqUtil;
using ChinaTtlWifi.NewEntity;

using ChinaTtlWifi.IPerf;
using AgentPerfChariot;
using AgentperfUtil;


namespace AgentperfChariot
{
    class Program
    {
        private const string AGETN_NAME = "AGENT_CHARIOT";
        private static LogBll log { get; set; }
        [STAThread]
        static void Main()
        {
            CommonConfig.ConfigBll.GetInst().LoadConfig();
            log = LogBll.GenLogBll(AGETN_NAME);
            Thread t = new Thread(() => startListen());
            t.Start();
            for (; ; )
            {
                log.HeartBeat("I'm alive");
                Thread.Sleep(1000 * 20);
            }
        }

        private static void startListen()
        {
            MqConsumerQueue.GetInst(consumer_Listener, AGETN_NAME);
            log.Info(AGETN_NAME + "开始监听");
        }

        private static void consumer_Listener(IMessage message)
        {
            string taskId = string.Empty;
            try
            {
                ITextMessage msg = (ITextMessage)message;
                Dictionary<string, object> param = MqConsumerBase.ReadMapFromJson(msg.Text);
                IPerfApiChariot chariotBll = ChariotFactory.GetChariot(param["deviceModel"].ToString());

                log.Info(msg.NMSMessageId, taskId);
                if (msg.NMSType == "TestThroughput")
                {
                    taskId = param["taskId"].ToString();
                    string param1 = param["param1"].ToString();
                    string param2 = param["param2"].ToString();
                    string param3 = param["param3"].ToString();
                    string param4 = param["param4"].ToString();
                    string param5 = param["param5"].ToString();
                    string param6 = param["param6"].ToString();
                    string ping = "ping 127.0.0.1 -n 2 >nul";
                    List<string> commandList = new List<string>() { param1, ping, param2, ping, param3, ping, param4, ping, param5, ping, param6, ping + "&exit" };
                    CmdHelper.SendCmdCommandList(commandList);
                    WriteLogAndSendResponse(msg.NMSMessageId, "回复消息，我已经完成任务！", StepTestStatus.测试通过, "", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
                else if (msg.NMSType == "AnalysisResult")
                {
                    taskId = param["taskId"].ToString();
                    List<string> resultList = new List<string>();
                    string filePath1 = param["FilePath1"].ToString();
                    //string filePath2 = param["FilePath2"].ToString();
                    //string filePath3 = param["FilePath3"].ToString();
                    resultList.Add(chariotBll.GetTestValue(filePath1));
                    //resultList.Add(AnalysisResult.GetTestValue(filePath2));
                    //resultList.Add(AnalysisResult.GetTestValue(filePath3));
                    string result = string.Join(",", resultList.ToArray());
                    WriteLogAndSendResponse(msg.NMSMessageId, "回复消息，我已经完成任务！", StepTestStatus.测试通过, "", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info(ex.Message, taskId);
            }
        }

        private static void WriteLogAndSendResponse(string msgId, string logMsg, StepTestStatus result, string resultMsg, string projectId, string caseId, string stepId)
        {
            log.Info(logMsg, msgId);
            MqAgentProducer.SendResponse(msgId, result, resultMsg, projectId, caseId, stepId);
        }
    }
}
