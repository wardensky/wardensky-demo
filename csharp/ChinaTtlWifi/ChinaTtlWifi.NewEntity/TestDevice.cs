
using System;
using System.ComponentModel;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class TestDevice : BaseEntity
    {
        [Description("设备类型")]
        public AGENT_TYPE AgentType { get; set; }
        [Description("设备型号")]
        public string Model { get; set; }

        [Description("设备编号")]
        public string DeviceCode { get; set; }

        [Description("设备厂商")]
        public string Vendor { get; set; }

        [Description("设备描述")]
        public string Desc { get; set; }

        [Description("设备房间")]
        public string TestRoom { get; set; }


    }
}
