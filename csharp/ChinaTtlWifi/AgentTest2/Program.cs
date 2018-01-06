using Apache.NMS;
using ChinaTtlWifi.Base;
using MqUtil;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AgentTest2
{
    class Program
    {
        private static LogBll log = LogBll.GenLogBll("AgentTest2");
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
                log.HeartBeat("I'm alive");
                Thread.Sleep(1000 * 20);
            }
        }

        private static void startListen()
        {
            MqAgentConsumer.GetInst(consumer_Listener, MqConst.AgentTest2);
            log.Info("AgentTest2开始监听");
        }

        private static void consumer_Listener(IMessage message)
        {
            string taskId = string.Empty;
            try
            {
                ITextMessage msg = (ITextMessage)message;
                Dictionary<string, object> param = MqConsumer.ReadParaFromJson(msg.Text);
                log.Info(msg.NMSMessageId, taskId);
                if (msg.NMSType == "command2")
                {
                    string param1 = param["param2"].ToString();
                    taskId = param["taskId"].ToString();
                    log.Info("执行命令，参数是" + param1, taskId);
                    Thread.Sleep(1000 * 3);
                    log.Info("回复消息，执行成功", taskId);
                    MqAgentProducer.SendResponse(msg.NMSMessageId, true, "我已经成功执行了", "");
                }

            }
            catch (Exception ex)
            {
                log.Info(ex.Message, taskId);
            }

        }
    }
}
