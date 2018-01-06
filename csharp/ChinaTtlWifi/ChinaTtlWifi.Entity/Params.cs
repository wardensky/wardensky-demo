using System.Collections.Generic;
using System.ComponentModel;

namespace ChinaTtlWifi.Entity
{
    public class Params
    {
        public string Id { get; set; }
        [Description("参数名称")]
        public string Name { get; set; }
        [Description("参数描述")]

        public string Desc { get; set; }



        public List<Param> ParamList { get; set; }
    }

}
