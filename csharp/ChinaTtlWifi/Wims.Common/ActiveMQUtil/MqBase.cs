using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;

namespace Wims.Common.ActiveMQUtil
{
    public class MqBase
    {


        protected MqBase()
        {
            this.factory = new ConnectionFactory(new Uri(GlobalValues.MQ_URL));
            this.connection = factory.CreateConnection();
        }

        protected IConnectionFactory factory;
        protected IConnection connection;
        protected IMessageConsumer consumer;
        protected ISession session;
        public void Dispose()
        {
            if (null != this.session)
            {
                this.session.Close();
            }
            if (null != this.connection)
            {
                this.connection.Stop();
                this.connection.Close();
            }
        }
    }
}
