using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaTtlWifi.NewEntity
{
    public class Agent
    {

        public AGENT_TYPE AgentType { get; set; }
        public string Name { get; set; }
        public List<string> SupportModelList { get; set; }
       
    }
}
