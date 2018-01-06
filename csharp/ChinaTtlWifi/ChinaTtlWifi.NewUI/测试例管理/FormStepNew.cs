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
    public class FormStepNew : FormBaseNew<Step>
    {
        MongoUtil<Command> commandBll = DbFactory.CommandBll;
        MongoUtil<TestParams> paramsBll = DbFactory.TestParamsBll;

        public FormStepNew()
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
                    inst.Value = Enum.GetNames(typeof(AGENT_TYPE));
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
            List<object> commandAgentApList = this.commandBll.SelectAll().Where(p => p.AgentType.Equals(AGENT_TYPE.AGENT_AP)).ToList<object>();
            dic.Add("Command", commandAgentApList);
            dic.Add("AgentType", Enum.GetNames(typeof(AGENT_TYPE)).Select(s => { return (object)s; }).ToList());
            dic.Add("Params", (this.paramsBll.SelectAll().ToList<object>()));
            List<object> list99 = new List<object>();
            for (int i = 1; i < 20; i++)
            {
                list99.Add(i);
            }
            dic.Add("Index", list99);
            dic.Add("NextStepIndex", list99);

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
                        if (box.GetRow().Key == "Command")
                        {
                            if (value == AGENT_TYPE.AGENT_AP.ToString())
                            {
                                assignmentCommand(box, AGENT_TYPE.AGENT_AP);
                            }
                            else if (value == AGENT_TYPE.AGENT_CHARIOT.ToString())
                            {
                                assignmentCommand(box, AGENT_TYPE.AGENT_CHARIOT);
                            }
                            else if (value == AGENT_TYPE.AGENT_SNIFFER.ToString())
                            {
                                assignmentCommand(box, AGENT_TYPE.AGENT_SNIFFER);
                            }
                            else if (value == AGENT_TYPE.AGENT_STATION.ToString())
                            {
                                assignmentCommand(box, AGENT_TYPE.AGENT_STATION);
                            }
                            else if (value == AGENT_TYPE.AGENT_IPERF.ToString())
                            {
                                assignmentCommand(box, AGENT_TYPE.AGENT_IPERF);
                            }
                            else if (value == AGENT_TYPE.AGENT_MANUAL.ToString())
                            {
                                assignmentCommand(box, AGENT_TYPE.AGENT_MANUAL);
                            }
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 根据agent_type 给UCRowComboBox动态赋值
        /// </summary>
        /// <param name="box"></param>
        /// <param name="agentType"></param>
        private void assignmentCommand(UCRowComboBox box, AGENT_TYPE agentType)
        {
            List<object> commandList = commandBll.SelectAll().Where(p => p.AgentType.Equals(agentType)).ToList<object>();
            box.ResetList(commandList);
        }
    }
}
