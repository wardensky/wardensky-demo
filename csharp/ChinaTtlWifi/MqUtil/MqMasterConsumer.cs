
using Apache.NMS;
using System;
using Wims.Common.ActiveMQUtil;
namespace MqUtil
{
    public class MqMasterConsumer
    {
        private static MqMasterConsumer inst;

        private MqMasterConsumer(Action<IMessage> listener)
        {
            MqConsumerQueue.GetInst(listener, MqConst.RESPONSE_Q,null);
        }

        public static MqMasterConsumer GetInst(Action<IMessage> listener)
        {
            if (null == inst)
                inst = new MqMasterConsumer(listener);
            return inst;
        }


    }
}
