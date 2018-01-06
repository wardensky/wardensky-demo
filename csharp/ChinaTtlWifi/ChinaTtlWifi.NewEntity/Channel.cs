
using System.ComponentModel;
namespace ChinaTtlWifi.NewEntity
{
    public class Channel
    {
        public string Id { get; set; }
        [Description("通道名称")]
        public string AgentName { get; set; }
        [Description("通道描述")]
        public string Description { get; set; }
    }
}
