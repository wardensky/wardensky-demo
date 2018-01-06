using ChinaTtlWifi.IAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgentStation
{
    public class StationFactory
    {
        public static AgentApiStation GetStation(string model)
        {
            if (model == Win7.MODEL)
            {
                return new Win7();
            }

            return null;
        }
    }
}
