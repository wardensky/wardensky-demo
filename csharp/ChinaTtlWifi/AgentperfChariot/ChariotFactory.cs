
using ChinaTtlWifi.IPerf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgentPerfChariot
{
    public class ChariotFactory
    {
        public static IPerfApiChariot GetChariot(string Version)
        {
            if (Version == ChariotVersion.Version)
            {
                return new ChariotVersion();
            }

            return null;
        }
    }
}
