using System.Linq;
using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public partial class UCProjectInfo : UCBaseNew<Project>
    {
        public UCProjectInfo()
        {
            InitializeComponent();
            this.Load += UCProjectInfo_Load;
        }

        void UCProjectInfo_Load(object sender, EventArgs e)
        {
            this.ignoreFields.Add("CaseList");
            this.ignoreFields.Add("DeviceList");
            this.ignoreFields.Add("StepDevice");
            this.ignoreFields.Add("ResultList");
            this.ignoreFields.Add("TestStatus");

            var list = this.GenReflectElements();
            foreach (var inst in list)
            {
                if (inst.Key == "DUT")
                {
                    inst.Type = Wims.Common.Entity.ControlType.COMBO_BOX;
                    inst.DisplayMember = "Name";
                }
            }
            MongoUtil<Dut> DutBll = DbFactory.DutBll;
            Dictionary<string, List<object>> dic = new Dictionary<string, List<object>>();
            dic.Add("DUT", DutBll.SelectAll().ToList<object>());
            this.Init(list, dic);
        }
    }
}
