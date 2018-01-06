using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace AgentUtil
{
    public static class PingHelper
    {
        public static List<IPStatus> PingHost(string ip, int num)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "a";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;
            List<IPStatus> statusList = new List<IPStatus>();
            for (int i = 0; i < num; i++)
            {
                PingReply reply = pingSender.Send(ip, timeout, buffer, options);
                statusList.Add(reply.Status);
            }
            return statusList;

        }
    }
}
