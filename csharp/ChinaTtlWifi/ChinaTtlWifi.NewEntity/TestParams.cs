using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class TestParams : BaseEntity
    {
       
        [Description("参数名称")]
        public string Name { get; set; }
        [Description("参数描述")]
        public string Desc { get; set; }
        public List<TestParam> ParamList { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

}
