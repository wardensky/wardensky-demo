
using System;
using System.ComponentModel;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    /// <summary>
    /// 测试步骤
    /// </summary>
    [Serializable]
    public class Step : BaseEntity
    {
        [Description("步骤名称")]
        public string Name { get; set; }
        [Description("步骤id")]
        public int Index { get; set; }
        [Description("Agent类型")]
        public AGENT_TYPE AgentType { get; set; }

        [Description("命令")]
        public Command Command { get; set; }
        [Description("步骤参数")]
        public TestParams Params { get; set; }


        private string status = TestStatus.测试未开始;
        [Description("测试状态")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }



       
        [Description("Agent过滤")]
        public string AgentFilter { get; set; }
        [Description("测试设备id")]
        public string TestDeviceId { get; set; }
        [Description("测试设备型号")]
        public string TestDeviceModel { get; set; }



    }
}
