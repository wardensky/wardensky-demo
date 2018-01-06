
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Wims.Common;
using Wims.Common.ActiveMQUtil;

namespace MqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = typeof(Int32).GetMethods()[3];
             
          
            MethodInfo p2 = typeof(int).GetMethod("Equals");

            //GlobalValues.MQ_URL = "activemq:failover:(tcp://192.168.163.50:61616?maxInactivityDurationInitalDelay=30000)";
            //string agentName = "AgentTest1";
            //string command = "aaaaaaaaaaa";
            //Dictionary<string, object> param = new Dictionary<string, object>();
            //int i = 0;
            //for (; ; )
            //{
            //    MqProducerTopic.GetInst().SendTopic(agentName, command, "aaaa");
            //    Console.WriteLine("发送" + i++);
            //    Thread.Sleep(1000);
            //}
        }
    }
}
