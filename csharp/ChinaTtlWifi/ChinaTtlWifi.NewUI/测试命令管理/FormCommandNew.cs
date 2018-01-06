
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using Wims.Common.Entity;
using Wims.Common.UI;
using System.Linq;

namespace ChinaTtlWifi.NewUI
{
    public class FormCommandNew : FormBaseNew<Command>
    {
        public FormCommandNew()
        {
            this.Load += new System.EventHandler(this.FormLoad);
        }

        private void FormLoad(object sender, System.EventArgs e)
        {
            List<string> comboxStrList = new List<string>() { "WaitResponse", "BreakOnFail", "AgentType" };
            this.Width = 400;
            this.Height = 400;
            var list = base.uc.GenReflectElements();
            List<string> comboxControlList = null;
            foreach (var inst in list)
            {
                comboxControlList = null;
                comboxControlList = comboxStrList.Where(p => p.Equals(inst.Key)).ToList();
                if (comboxControlList.Count != 0)
                {
                    inst.Type = ControlType.COMBO_BOX;
                }
            }

            Dictionary<string, List<object>> dic = new Dictionary<string, List<object>>();
            dic.Add("AgentType", Enum.GetNames(typeof(AGENT_TYPE)).Select(s => { return (object)s; }).ToList());
            dic.Add("WaitResponse", new List<object>() { false, true });
            dic.Add("BreakOnFail", new List<object>() { true, false });

            base.uc.Init(list, dic);
        }

    }
}
