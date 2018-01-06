using ChinaTtlWifi.IAgent;

namespace AgentIperf
{
    public class IperfFactory
    {
        public static IAgentApiIperf GetAp(string model)
        {
            if (model == AgentModelIperf.iperf2)
            {
                return new Iperf2();
            }
            else if (model == AgentModelIperf.iperf3)
            {
                return new Iperf3();
            }
            return null;
        }
    }
}
