using Apache.NMS;
using ChinaTtlWifi.Base;
using CommonConfig;
using MqUtil;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using System.Linq;
using Wims.Common.ActiveMQUtil;
using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewEntity;
using Newtonsoft.Json;
using AgentUtil;
using Wims.Common;
using MongoDB.Driver;
using System.Net.Sockets;

namespace AgentAp
{
    class Program
    {
        private static LogBll log { get; set; }
        private static string AGENT_NAME { get; set; }
        private static string AGENT_FILTER { get; set; }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            try
            {
                ConfigBll.GetInst().LoadConfig();
                AGENT_NAME = GlobalValues.AGENT_NAME;
                AGENT_FILTER = GlobalValues.AGENT_FILTER;
                log = LogBll.GenLogBll(AGENT_NAME);
                //CmdHelper.ConnectAp("BTs", "yahaoweikoujiuhao");
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
                AgentApiAp apBll = ApFactory.GetAp(param["deviceModel"].ToString());
                projectId = param["projectId"].ToString();
                log.Info(msg.NMSMessageId, projectId);
                if (msg.NMSType == "PostWebRequest")
                {
                    string param1 = param["dns2"].ToString();
                    log.Info("执行命令，参数是" + param1, projectId);
                    Thread.Sleep(1000 * 3);

                    string url = "http://192.168.0.1/goform/NetWorkSetupSave";
                    string param11 = string.Format("Go=index.htm&con-type=0&adsl-user=302000230640&adsl-pwd=36663381&ssid=sss&ssid-pwd=lizc580231&ipval=192.168.163.82&submask=255.255.255.0&gateway=192.168.163.1&dns1=114.114.114.114&dns2={0}", param1);
                    string ret = HttpHelper.PostWebRequest(url, param11);

                    log.Info("回复消息，执行成功", projectId);
                    MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试通过, "我已经成功执行了");
                }
                else if (msg.NMSType == "ModifySp")
                {
                    string param1 = param["p1"].ToString();
                    SpHelper sp = new SpHelper();
                    sp.ModifySp(param1);
                    log.Info("执行命令，参数是" + param1, projectId);
                    Thread.Sleep(1000 * 3);
                    WriteLogAndSendResponse(msg.NMSMessageId, "回复消息，我已经完成任务！", StepTestStatus.测试通过, "", projectId, param["caseId"].ToString(), param["stepId"].ToString());
                }
                else if (msg.NMSType == "InitApConfig")
                {
                    string ip = param["ip"].ToString();
                    string user = param["user"].ToString();
                    string pwd = param["password"].ToString();
                    List<string> commandList = ((Newtonsoft.Json.Linq.JArray)param["cfgCommand"]).Select(s => s.ToString()).ToList();
                    apBll.InitApConfig(ip, user, pwd, commandList);
                    Thread.Sleep(1000 * 3);
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    WriteLogAndSendResponse(msg.NMSMessageId, "回复消息，我已经完成任务！", StepTestStatus.测试通过, "", projectId, param["caseId"].ToString(), param["stepId"].ToString());
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


