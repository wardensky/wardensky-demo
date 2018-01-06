using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Wims.Common.ActiveMQUtil
{
    public class MqConsumerTopic : MqConsumerBase
    {
        private static MqConsumerTopic inst;

        public static MqConsumerTopic GetInst(Action<IMessage> listener, string topicName)
        {
            if (inst == null)
            {
                inst = new MqConsumerTopic();
            }
            inst.name = topicName;
            inst.listener = listener;
            inst.InitConsumer();
            return inst;
        }
        private MqConsumerTopic()
        {
         
        }

        private void InitConsumer()
        {
            connection.Start();
            this.session = connection.CreateSession();
            this.consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(this.name));
            consumer.Listener += new MessageListener(listener);
        }


    }
}
