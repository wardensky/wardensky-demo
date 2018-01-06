using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using System;
namespace Wims.Common.ActiveMQUtil
{
    public class MqProducerTopic : MqProducerBase
    {
        private static MqProducerTopic inst;

        public MqProducerTopic()
            : base()
        {

        }

        public static MqProducerTopic GetInst()
        {
            if (inst == null)
            {
                inst = new MqProducerTopic();
            }
            return inst;
        }

        public string SendTopic(string qName, string command, string content, string filter)
        {
            return base.SendTextMessage(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(qName), command, content, filter);
        }



    }
}