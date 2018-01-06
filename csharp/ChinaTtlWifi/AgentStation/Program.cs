using Apache.NMS;
using ChinaTtlWifi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using Wims.Common.ActiveMQUtil;
using Wims.Common;
using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewEntity;
using MqUtil;
using AgentUtil;
using System.Net.Sockets;
using MongoDB.Driver;


namespace AgentStation
{
    class Program
    {
        private static string AGENT_NAME { get; set; }
        private static string AGENT_FILTER { get; set; }
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
                log = LogBll.GenLogBll(AGENT_NAME);
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
                AgentApiStation stationBll = StationFactory.GetStation(param["deviceModel"].ToString());
                projectId = param["projectId"].ToString();
                log.Info(msg.NMSMessageId, projectId);
                StepTestStatus stepTestStatus = StepTestStatus.测试通过;
                if (msg.NMSType == "Ping")
                {
                    string ip = param["ip"].ToString();
                    double packetLoss;
                    if (!Double.TryParse(param["pingnum"].ToString(), out packetLoss))
                    {
                        log.Error("丢包率限值参数异常！");
                    }

                    int num;
                    if (!int.TryParse(param["pingnum"].ToString(), out num))
                    {
                        log.Error("pingnum 参数异常！");
                    }
                    List<IPStatus> statusList = PingHelper.PingHost(ip, num);
                    double PacketLoss = 1 - statusList.Where(p => p == IPStatus.Success).Count() / num;
                    if (PacketLoss > 0.1)
                    {
                        stepTestStatus = StepTestStatus.测试未通过;
                    }
                    MqAgentProducer.SendResponse(msg.NMSMessageId, stepTestStatus, "完成任务 丢包率：" + (1 - PacketLoss), projectId, param["caseId"].ToString(), param["stepId"].ToString());
                }

                else if (msg.NMSType == "ModifyWirelessMode")
                {
                    string param1 = param["modeString"].ToString();
                    log.Info(string.Format("执行命令，参数是{0}", param1), projectId);
                    Thread.Sleep(1000 * 1);
                    try
                    {
                        stationBll.ModifyWirelessMode(param1);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                        stepTestStatus = StepTestStatus.测试异常;
                    }
                    MqAgentProducer.SendResponse(msg.NMSMessageId, stepTestStatus, "成功", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
                else if (msg.NMSType == "UpStation")
                {
                    string ssid = param["ssid"].ToString();
                    string pwd = param["password"].ToString();
                    stationBll.UpStation(ssid, pwd);
                    Thread.Sleep(1000 * 3);
                    MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试通过, "回复消息，我已经完成任务！", projectId, param["caseId"].ToString(), param["stepId"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info(ex.Message, projectId);
            }
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("出现未处理的异常,异常如下:" + e.ExceptionObject.ToString());
        }
    }
}
