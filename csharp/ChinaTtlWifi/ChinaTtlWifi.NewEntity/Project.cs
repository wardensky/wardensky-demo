using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class Project : BaseEntity
    {
        [Description("项目名称")]

        public string Name { get; set; }

        [Description("被测试设备")]
        public Dut DUT { get; set; }

        [Description("受理工程师")]
        public string SamplePerson { get; set; }

        [Description("测试工程师")]
        public string TestPerson { get; set; }

        private DateTime startTime = DateTime.Now;
        [Description("测试开始时间")]
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime endTime = DateTime.Now;
        [Description("测试结束时间")]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }


        [Description("客户联系人")]
        public string Customer { get; set; }

        [Description("客户电话")]
        public string CustomerPhone { get; set; }

        [Description("客户地址")]
        public string CustomerAddr { get; set; }




        private DateTime sendTime = DateTime.Now;
        [Description("客户送件时间")]
        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }



        private DateTime deadlineTime = DateTime.Now;
        [Description("客户要求时间")]
        public DateTime DeadlineTime
        {
            get { return deadlineTime; }
            set { deadlineTime = value; }
        }

        private string status = TestStatus.测试未开始;
        [Description("测试状态")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    
        public LinkedList<TestCase> CaseList { get; set; }

        //[Description("测试设备")]
        //public Dictionary<string, string> StepDevice { get; set; }


        public List<TestResult> ResultList { get; set; }
    }
}
