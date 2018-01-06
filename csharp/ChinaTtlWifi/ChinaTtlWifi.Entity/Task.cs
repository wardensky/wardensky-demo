using System;
using System.ComponentModel;
using Wims.Common.Entity;

namespace ChinaTtlWifi.Entity
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }

        [Description("任务描述")]
        public string Desc { get; set; }
        [Description("脚本ID")]
        public string ScriptId { get; set; }
        [Description("脚本名称")]
        public string ScriptName { get; set; }
        [Description("被测设备ID")]
        public string EutId { get; set; }
        [Description("被测设备型号")]
        public string EutModel { get; set; }
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }
        [Description("测试状态")]
        public string Status { get; set; }


    }
}
