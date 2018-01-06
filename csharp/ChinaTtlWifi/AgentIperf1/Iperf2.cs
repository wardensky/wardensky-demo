using AgentUtil;
using ChinaTtlWifi.IAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgentIperf
{
    public class Iperf2 : IAgentApiIperf
    {

        public void StartLinten(string filePath, string cmd)
        {
            CmdHelper.GetInst();
            CmdHelper.SendCmdCommand("\"" + filePath + "\"" + " " + cmd, false);                                 
        }

        public double GetResult(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
