using Apache.NMS;
using ChinaTtlWifi.Base;
using MqUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AgentWirelessMode
{
    public class Program
    {
        private static LogBll log = LogBll.GenLogBll("AgentWirelessMode");
        private const string AGENT_NAME = "AGENT_WIRELESS_MODE";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread t = new Thread(() => startListen());
            t.Start();
            for (; ; )
            {
                log.Info("I'm alive");
                Thread.Sleep(1000 * 5);

            }

        }

        private static void startListen()
        {
            MqAgentConsumer.GetInst(consumer_Listener, AGENT_NAME);
            log.Info("AgentWirelessMode开始监听");
        }

        private static void consumer_Listener(IMessage message)
        {
            string taskId = string.Empty;
            try
            {

                ITextMessage msg = (ITextMessage)message;
                Dictionary<string, object> param = MqConsumer.ReadParaFromJson(msg.Text);


                if (msg.NMSType == "ModifyWirelessMode")
                {
                    string param1 = param["modeString"].ToString();
                    taskId = param["taskId"].ToString();
                    log.Info(string.Format("执行命令，参数是{0}", param1), taskId);
                    Thread.Sleep(1000 * 1);
                    WirelessModeOper.ModifyWirelessMode(param1);
                    MqAgentProducer.SendResponse(msg.NMSMessageId, true, "成功", "");
                }

            }
            catch (Exception ex)
            {
                log.Info(ex.Message);
            }
        }
    }
}
