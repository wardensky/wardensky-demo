using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgentApTest
{
    public static class AgentApFactory
    {
        public static AgentApiAp GetAgentAp(string model)
        {
            if(model == "h3c" || model == "huawei")
            {
                return new ApImplH3c();
            }
            else if(model == "broadcom" )
            {
                return new ApImplBroadcom();
            }
            return null;
        }
    }
}
