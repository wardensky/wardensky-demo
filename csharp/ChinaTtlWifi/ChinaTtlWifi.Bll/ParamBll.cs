using ChinaTtlWifi.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ChinaTtlWifi.Bll
{
    public class ParamBll  
    {
        public List<Params> ParamsList { get; set; }

        private static ParamBll paramBll { get; set; }
        public static ParamBll GetInst()
        {
            if (paramBll == null)
            {
                paramBll = new ParamBll();
            }
            return paramBll;
        }
 
    }
}
