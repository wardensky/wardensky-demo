using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Newtonsoft.Json;
using System;
namespace Wims.Common.ActiveMQUtil
{
    public class MqProducerQueue : MqProducerBase
    {
        private static MqProducerQueue inst;

        public MqProducerQueue()
            : base()
        {

        }

        public static MqProducerQueue GetInst()
        {
            if (inst == null)
            {
                inst = new MqProducerQueue();
            }
            return inst;
        }


        public string SendJsonMessage<T>(string qName, string command, T t, string filter)
        {
            string json = JsonConvert.SerializeObject(t);
            return SendTextMessage(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(qName), command, json, filter);


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qName"></param>
        /// <param name="fileName">file name not absolute file path</param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SendByteMessage(string qName, string fileName, byte[] param, string filter)
        {

            return SendByteMessage(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(qName), fileName, param, filter);

        }

    }
}