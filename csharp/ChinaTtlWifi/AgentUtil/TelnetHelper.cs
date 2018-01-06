using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AgentUtil
{
    public static class TelnetHelper
    {
        public static void SetAPConfig(string ip, string user, string password, List<string> commandList)
        {

            TelnetConnection tc = new TelnetConnection(ip, 23);
            string s = tc.Login(user, password, 1000 * 3);
            string prompt = s.TrimEnd();
            prompt = s.Substring(prompt.Length - 1, 1);
            if (prompt != "$" && prompt != ">" && prompt != "#")
                throw new Exception("Connection failed");

            prompt = "";

            if (tc.IsConnected)
            {
                foreach (var cmd in commandList)
                {
                    Console.WriteLine("send: " + cmd);
                    tc.WriteLine(cmd);

                    Thread.Sleep(100);
                    string ret = tc.Read();
                    Console.WriteLine("receive: " + ret);
                    Thread.Sleep(100);

                }
            }
        }
    }
}
