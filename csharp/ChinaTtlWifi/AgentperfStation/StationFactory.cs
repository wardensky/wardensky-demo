using ChinaTtlWifi.IPerf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgentPerfStation
{
    public class StationFactory
    {
        public static IPerfApiStation GetStation(string model)
        {
            if (model == Win7.MODEL)
            {
                return new Win7();
            }

            return null;
        }
    }
}
