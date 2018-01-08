using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616/");
                using (IConnection connection = factory.CreateConnection())
                {
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer prod = session.CreateProducer(
                            new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("testing"));
                        int i = 0;
                        for (int j = 0; j<2;j++ )
                        {
                            ITextMessage msg = prod.CreateTextMessage();
                            msg.Text = i.ToString();
                            msg.Properties.SetString("filter", "zch");
                            Console.WriteLine("Sending: " + i.ToString());
                            prod.Send(msg, Apache.NMS.MsgDeliveryMode.NonPersistent, Apache.NMS.MsgPriority.Normal, TimeSpan.MinValue);
                            System.Threading.Thread.Sleep(100);
                            i++;
                        }
                        prod.Close();
                        session.Close();
                    }
                    connection.Stop();
                    connection.Close();
                }

                
            }
            catch (System.Exception e)
            {
                Console.WriteLine("{0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}
