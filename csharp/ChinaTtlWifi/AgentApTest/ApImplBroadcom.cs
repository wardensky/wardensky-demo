using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentApTest
{
    public class ApImplBroadcom : AgentApiAp
    {
        public bool SetSSId(string ssid, string user, string password)
        {
            //do something, set ssid via telnet
            return true;
        }


        public void InitApConfig(string ip, string user, string password, List<string> commandList)
        {
            throw new NotImplementedException();
        }


        public void UpStation(string ssid, string password)
        {
            throw new NotImplementedException();
        }
    }
}
