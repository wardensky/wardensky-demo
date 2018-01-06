using System;
using System.Collections.Generic;
namespace ChinaTtlWifi.IPerf
{
    public class AgentModelPerf
    {
        public static List<object> DataList = new List<object>() { h3c, huawei, broadcom, qualcomm };
        public const string h3c = "h3c";
        public const string huawei = "huawei";
        public const string broadcom = "broadcom";
        public const string qualcomm = "qualcomm";
    }
}
