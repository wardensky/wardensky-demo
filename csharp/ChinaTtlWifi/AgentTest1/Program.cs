using Apache.NMS;
using ChinaTtlWifi.Base;
using ChinaTtlWifi.NewEntity;
using MqUtil;
using System;
using System.Collections.Generic;
using System.Threading;
using Wims.Common.ActiveMQUtil;
namespace AgentTest1
{
    class Program
    {
        private static LogBll log { get; set; }
        private const string AGENT_NAME = "AGENT_TEST1";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CommonConfig.ConfigBll.GetInst().LoadConfig();
            log = LogBll.GenLogBll("AgentTest1");
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
            MqAgentConsumer.GetInst(consumer_Listener, AGENT_NAME);
            log.Info("agent test1 开始监听");
        }

        private static void consumer_Listener(IMessage message)
        {
            string taskId = string.Empty;
            try
            {
                ITextMessage msg = (ITextMessage)message;
                Dictionary<string, object> param = MqConsumerBase.ReadMapFromJson(msg.Text);
                log.Info(msg.NMSMessageId, taskId);
                if (msg.NMSType == "command1")
                {
                    string param1 = param["param1"].ToString();
                    taskId = param["taskId"].ToString();
                    log.Info("执行命令，参数是" + param1, taskId);
                    Thread.Sleep(1000 * 3);
                    log.Info("回复消息，执行成功", taskId);
                    MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试通过, "我已经成功执行了");
                }
            }
            catch (Exception ex)
            {
                log.Info(ex.Message, taskId);
            }
        }
    }
}
