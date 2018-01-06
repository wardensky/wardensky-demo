
using System.ComponentModel;
namespace ChinaTtlWifi.NewEntity
{
    public class AAction
    {
        public string Id { get; set; }
        [Description("通道名称")]
        public string Name { get; set; }
        [Description("是否等待")]
        public bool WaitResponse { get; set; }
        [Description("错误退出")]
        public bool BreakOnFail { get; set; }
        [Description("执行前等待")]
        public int Predelay { get; set; }
        [Description("命令")]
        public string Command { get; set; }
        [Description("执行后等待")]
        public int Postdelay { get; set; }
    }
}
