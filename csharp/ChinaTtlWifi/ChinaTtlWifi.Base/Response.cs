using System;
using Wims.Common.Entity;

namespace ChinaTtlWifi.Base
{
    public class Response : BaseEntity
    {
        public string Msg { get; set; }

        public bool Result { get; set; }

        public string orgiMsgId { get; set; }

        public string AgentName { get; set; }

        public string Command { get; set; }

        public DateTime CreateTime { get; set; }

        public string Condition { get; set; }
    }
}
