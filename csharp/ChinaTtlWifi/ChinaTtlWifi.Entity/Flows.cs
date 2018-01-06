using System;
using System.Collections.Generic;

namespace ChinaTtlWifi.Entity
{
    [Serializable]
    public class Flows
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Flow> FlowList { get; set; }
    }
}
