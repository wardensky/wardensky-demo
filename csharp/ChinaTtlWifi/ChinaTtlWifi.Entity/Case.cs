
using System.Collections.Generic;
using System.ComponentModel;
using Wims.Common.Entity;
namespace ChinaTtlWifi.Entity
{
    /// <summary>
    /// 脚本
    /// </summary>
    public class Case : BaseEntity
    {
        public string Name { get; set; }

        [Description("脚本描述")]
        public string Desc { get; set; }
        [Description("限值")]
        public string Limit { get; set; }
        public List<Step> StepList { get; set; }
    }
}
