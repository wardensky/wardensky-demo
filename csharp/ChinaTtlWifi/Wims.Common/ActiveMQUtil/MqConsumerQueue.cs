using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Wims.Common.ActiveMQUtil
{
    public class MqConsumerQueue : MqConsumerBase
    {
        private static MqConsumerQueue inst;
        public static MqConsumerQueue GetInst(Action<IMessage> listener, string qName, string filter)
        {
            if (inst == null)
            {
                inst = new MqConsumerQueue();
            }
            inst.name = qName;
            inst.filter = filter;
            inst.listener = listener;
            inst.InitConsumer();
            return inst;
        }
        private MqConsumerQueue()
            : base()
        {

        }

        protected void InitConsumer()
        {
            connection.Start();
            this.session = connection.CreateSession();
            if (string.IsNullOrEmpty(this.filter))
            {
                this.consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(this.name));
            }
            else
            {
                this.consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(this.name), "filter=" + "'" + filter + "'");
            }
            consumer.Listener += new MessageListener(listener);
        }


    }
}