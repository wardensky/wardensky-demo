using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class TestCase : BaseEntity
    {
        [Description("测试例名称")]
        public string Name { get; set; }

        [Description("测试例编号")]

        public string Code { get; set; }
        [Description("测试例描述")]

        public string Desc { get; set; }

        private string status = TestStatus.测试未开始;
        [Description("测试状态")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string assign = EquipmentStatus.未指定;
        [Description("是否指定设备")]
        public string Assign
        {
            get { return assign; }
            set { assign = value; }
        }
        public List<double> LimitList { get; set; }

        public LinkedList<Step> StepList { get; set; }

        public List<TestLog> LogList { get; set; }

    }
}
