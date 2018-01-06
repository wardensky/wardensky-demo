
using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Wims.Common.Entity;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public class FormTestDeviceNew : FormBaseNew<TestDevice>
    {
        public FormTestDeviceNew()
        {
            this.Load += new System.EventHandler(this.FormLoad);
        }

        private void FormLoad(object sender, System.EventArgs e)
        {
            this.Width = 500;
            this.Height = 350;
            var list = base.uc.GenReflectElements();
            foreach (var inst in list)
            {
                if (inst.Key == "WaitResponse" || inst.Key == "BreakOnFail")
                {
                    inst.Type = ControlType.COMBO_BOX;
                }
                if (inst.Key == "AgentType")
                {
                    inst.Type = ControlType.COMBO_BOX;
                    //inst.Value = Enum.GetNames(typeof(AGENT_TYPE));
                    inst.Value = Enum.GetName(typeof(AGENT_TYPE),inst.Value);
                    
                    inst.DisplayMember = "Name";
                }
                if (inst.Key == "Model")
                {
                    inst.Type = ControlType.COMBO_BOX;
                }
            }
            Dictionary<string, List<object>> dic = new Dictionary<string, List<object>>();
            dic.Add("WaitResponse", new List<object>() { true, false });
            dic.Add("BreakOnFail", new List<object>() { true, false });
            dic.Add("Model", AgentModelAp.DataList);

            dic.Add("AgentType", Enum.GetNames(typeof(AGENT_TYPE)).Select(s => { return (object)s; }).ToList());

            Dictionary<string, Action<object, EventArgs>> actionDic = new Dictionary<string, Action<object, EventArgs>>();

            Action<object, EventArgs> action = this.SelectChanged;
            actionDic.Add("AgentType", action);


            base.uc.Init(list, dic, actionDic);
        }

        private void SelectChanged(object sender, System.EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox cb = sender as ComboBox;
                string value = (string)cb.SelectedItem;
                foreach (Control c in this.uc.Controls[0].Controls)
                {
                    if (c is UCRowComboBox)
                    {
                        UCRowComboBox box = c as UCRowComboBox;
                        if (box.GetRow().Key == "Model")
                        {
                            if (value == AGENT_TYPE.AGENT_AP.ToString())
                            {
                                box.ResetList(AgentModelAp.DataList);
                            }
                            else if (value == AGENT_TYPE.AGENT_CHARIOT.ToString())
                            {
                                box.ResetList(AgentModelChariot.DataList);
                            }
                            else if (value == AGENT_TYPE.AGENT_SNIFFER.ToString())
                            {
                                box.ResetList(AgentModelSniffer.DataList);
                            }
                            else if (value == AGENT_TYPE.AGENT_STATION.ToString())
                            {
                                box.ResetList(AgentModelStation.DataList);
                            }
                            else if (value == AGENT_TYPE.AGENT_IPERF.ToString())
                            {
                                box.ResetList(AgentModelIperf.DataList);
                            }
                            break;
                        }
                    }
                }
            }

        }
    }
}
