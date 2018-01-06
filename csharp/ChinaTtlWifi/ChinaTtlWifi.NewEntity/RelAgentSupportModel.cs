using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChinaTtlWifi.NewEntity
{
    /// <summary>
    /// 这个类用来表示agent支持的型号，由页面设置。
    /// </summary>
    public class RelAgentSupportModel
    {
        public string AgentName { get; set; }

        public List<string> SupportModel { get; set; }
    }
}
