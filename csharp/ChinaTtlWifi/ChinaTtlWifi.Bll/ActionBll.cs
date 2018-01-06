using ChinaTtlWifi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ChinaTtlWifi.Bll
{
    public class ActionBll 
    {
        public List<AAction> ActionList { get; set; }
        private static ActionBll actionBll { get; set; }

        public static ActionBll GetInst()
        {
            if (actionBll == null)
            {
                actionBll = new ActionBll();
            }
            return actionBll;
        }
       
    }
}
