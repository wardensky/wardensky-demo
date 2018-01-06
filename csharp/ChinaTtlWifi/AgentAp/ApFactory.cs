using ChinaTtlWifi.IAgent;

namespace AgentAp
{
    public class ApFactory
    {
        public static AgentApiAp GetAp(string model)
        {
            if (model == QualcommAP.MODEL)
            {
                return new QualcommAP();
            }

            return null;
        }
    }
}
