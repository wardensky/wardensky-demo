using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChinaTtlWifi.IAgent
{
    public interface IAgentApiIperf
    {
        void StartLinten(string filePath, string cmd);
        double GetResult(string filePath);
    }
}
