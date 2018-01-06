using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChinaTtlWifi.IAgent
{
    public class AgentModelIperf
    {
        public static List<object> DataList = new List<object>() { iperf2, iperf3 };

        public const string iperf2 = "iperf2.0";
        public const string iperf3 = "iperf3";
    }
}
