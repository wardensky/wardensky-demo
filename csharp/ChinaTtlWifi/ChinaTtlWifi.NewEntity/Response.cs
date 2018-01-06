using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class Response : BaseEntity
    {
        public string ProjectId { get; set; }
        public string Msg { get; set; }

        public bool Result { get; set; }

        public string orgiMsgId { get; set; }

        public string AgentName { get; set; }

        public string Command { get; set; }

        public DateTime CreateTime { get; set; }

        public string Condition { get; set; }
    }
}
