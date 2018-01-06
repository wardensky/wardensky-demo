using ChinaTtlWifi.IAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgentChariot
{
    public class ChariotFactory
    {
        public static IAgentApiChariot GetChariot(string Version)
        {
            if (Version == ChariotVersion.Version)
            {
                return new ChariotVersion();
            }

            return null;
        }
    }
}
