using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Threading;

namespace MqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            InitConsumer();
            for (; ; ) {
                Thread.Sleep(100);
            }
        }

        private static void InitConsumer()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection();
            connection.ClientId = "firstQueueListener";
            connection.Start();
            ISession session = connection.CreateSession();
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"));
            consumer.Listener += new MessageListener(consumer_Listener);
        }

        private static void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            Console.WriteLine(string.Format(@"接收到:{0}{1}", msg.Text, Environment.NewLine));
        }

       

    }
}
