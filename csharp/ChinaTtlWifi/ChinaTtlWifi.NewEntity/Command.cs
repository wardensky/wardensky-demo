using System;
using System.ComponentModel;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class Command : BaseEntity
    {
        public Command()
        {
            this.WaitResponse = true;
            this.BreakOnFail = true;
        }
        [Description("Agent类型")]
        public AGENT_TYPE AgentType { get; set; }

        [Description("命令")]
        public string Cmd { get; set; }
        [Description("执行前等待")]
        public int Predelay { get; set; }
        [Description("执行后等待")]
        public int Postdelay { get; set; }
        [Description("等待返回")]
        public bool WaitResponse { get; set; }
        [Description("错误即退出")]
        public bool BreakOnFail { get; set; }
        [Description("备注")]
        public string Remark { get; set; }

        public override string ToString()
        {
            return this.Cmd;
        }
    }
}
