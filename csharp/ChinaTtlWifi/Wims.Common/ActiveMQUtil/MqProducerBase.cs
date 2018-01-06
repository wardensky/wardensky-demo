using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using Newtonsoft.Json;
using System;
namespace Wims.Common.ActiveMQUtil
{
    public class MqProducerBase : MqBase
    {


        protected MqProducerBase()
            : base()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="nmsType"></param>
        /// <param name="data"></param>
        /// <returns>NMSMessageId</returns>
        protected string SendByteMessage(ActiveMQDestination dest, string nmsType, byte[] data, string filter)
        {
            string ret = "";

            using (ISession session = connection.CreateSession())
            {
                using (IMessageProducer prod = session.CreateProducer(dest))
                {
                    IBytesMessage message = session.CreateBytesMessage(data);
                    if (!string.IsNullOrEmpty(filter))
                    {
                        message.Properties.SetString("filter", filter);
                    }
                    message.NMSType = nmsType;
                    prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                    ret = message.NMSMessageId;
                }
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="nmsType"></param>
        /// <param name="data"></param>
        /// <returns>NMSMessageId</returns>
        protected string SendTextMessage(ActiveMQDestination dest, string nmsType, string data, string filter)
        {
            string ret = "";

            using (ISession session = connection.CreateSession())
            {
                using (IMessageProducer prod = session.CreateProducer(dest))
                {

                    ITextMessage message = session.CreateTextMessage();
                    if (!string.IsNullOrEmpty(filter))
                    {
                        message.Properties.SetString("filter", filter);
                    }
                    message.NMSType = nmsType;
                    message.Text = data;
                    prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                    ret = message.NMSMessageId;
                }
            }
            return ret;
        }
    }
}