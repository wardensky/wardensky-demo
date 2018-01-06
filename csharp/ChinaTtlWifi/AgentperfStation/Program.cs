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

using ChinaTtlWifi.NewEntity;
using MqUtil;
using AgentperfUtil;
using ChinaTtlWifi.IPerf;



namespace AgentPerfStation
{
    class Program
    {
        private const string AGETN_NAME = "AGENT_STATION";
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
                IPerfApiStation stationBll = StationFactory.GetStation(param["deviceModel"].ToString());
                log.Info(msg.NMSMessageId, taskId);
                if (msg.NMSType == "Ping")
                {
                    string ip = param["ip"].ToString();
                    int num;
                    if (!int.TryParse(param["pingnum"].ToString(), out num))
                    {
                        log.Error("pingnum 参数异常！");
                    }
                    List<IPStatus> statusList = PingHelper.PingHost(ip, num);
                    double PacketLoss = statusList.Where(p => p == IPStatus.Success).Count() / num;
                    bool isSucess = false;
                    if (PacketLoss > 0.5)
                    {
                        isSucess = true;
                    }
                    MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试通过, "完成任务 丢包率：" + (1 - PacketLoss), param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }

                else if (msg.NMSType == "ModifyWirelessMode")
                {
                    string param1 = param["modeString"].ToString();
                    taskId = param["taskId"].ToString();
                    log.Info(string.Format("执行命令，参数是{0}", param1), taskId);
                    Thread.Sleep(1000 * 1);
                    stationBll.ModifyWirelessMode(param1);
                    MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试通过, "成功", param["projectId"].ToString(), param["caseId"].ToString(), param["stepId"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info(ex.Message, taskId);
            }
        }


    }
}
