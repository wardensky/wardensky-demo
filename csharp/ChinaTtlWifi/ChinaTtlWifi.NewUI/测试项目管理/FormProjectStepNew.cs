using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Wims.Common.Entity;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;


namespace ChinaTtlWifi.NewUI
{
    public class FormProjectStepNew : FormBaseNew<Step>
    {
        MongoUtil<Command> commandBll = DbFactory.CommandBll;
        MongoUtil<TestParams> paramsBll = DbFactory.TestParamsBll;

        public FormProjectStepNew()
        {
            this.Load += new System.EventHandler(this.FormLoad);
        }

        private void FormLoad(object sender, System.EventArgs e)
        {
            this.Width = 400;
            this.Height = 400;
            base.uc.ignoreFields.Add("Status");
            base.uc.ignoreFields.Add("Condition");
            base.uc.ignoreFields.Add("TestDeviceId");
            base.uc.ignoreFields.Add("TestDeviceModel");

            var list = base.uc.GenReflectElements();

            foreach (var inst in list)
            {
                if (inst.Key == "Command")
                {
                    inst.Type = ControlType.COMBO_BOX;
                    inst.DisplayMember = "Cmd";
                }
                else if (inst.Key == "AgentType")
                {
                    inst.Type = ControlType.COMBO_BOX;
                    //inst.Value = Enum.GetNames(typeof(AGENT_TYPE));
                    inst.DisplayMember = "Name";
                }
                else if (inst.Key == "Params")
                {
                    inst.Type = ControlType.COMBO_BOX;
                    inst.DisplayMember = "Name";
                }
                else if (inst.Key == "Index")
                {
                    inst.Type = ControlType.COMBO_BOX;
                }
                else if (inst.Key == "NextStepIndex")
                {
                    inst.Type = ControlType.COMBO_BOX;
                }
            }
            Dictionary<string, List<object>> dic = new Dictionary<string, List<object>>();
            dic.Add("Command", (this.commandBll.SelectAll().ToList<object>()));
            dic.Add("AgentType", Enum.GetNames(typeof(AGENT_TYPE)).Select(s => { return (object)s; }).ToList());
            dic.Add("Params", (this.paramsBll.SelectAll().ToList<object>()));
            List<object> list99 = new List<object>();
            for (int i = 1; i < 20; i++)
            {
                list99.Add(i);
            }
            dic.Add("Index", list99);
            dic.Add("NextStepIndex", list99);




            base.uc.Init(list, dic);
        }

    }
}
