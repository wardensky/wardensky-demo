using Apache.NMS;
using System;
using Wims.Common.ActiveMQUtil;

namespace MqUtil
{
    public class MqAgentConsumer
    {
        private static MqAgentConsumer inst;

        private MqAgentConsumer(Action<IMessage> listener, string agentName)
        {
            MqConsumerTopic.GetInst(listener, agentName);
        }

        public static MqAgentConsumer GetInst(Action<IMessage> listener, string agentName)
        {
            if (null == inst)
                inst = new MqAgentConsumer(listener, agentName);
            return inst;
        }

    }
}
