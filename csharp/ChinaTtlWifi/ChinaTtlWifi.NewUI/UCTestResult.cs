using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChinaTtlWifi.NewUI
{
    public class UCTestResult : UCTestBase
    {
        private TestResultBll bll = TestResultBll.GetInst();


        public UCTestResult()
            : base()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

        }


        protected override void timer1_Tick(object sender, EventArgs e)
        {
            var data = bll.SelectBy("ProjectId", this.ProjectId).Where(a => this.showIdList.Contains(a.Id) == false).ToList();
            if (data != null && data.Count > 0)
            {
                foreach (var inst in data)
                {
                    this.AppendText(inst);
                }
            }
        }

        public void LoadData()
        {
            if (string.IsNullOrEmpty(this.ProjectId))
            {
                return;
            }
            this.project = this.projectBll.Select(this.ProjectId);
            this.showIdList = new List<string>();
            this.htmlPanelResult.ClearSelection();
            this.htmlPanelResult.Text = string.Empty;
            //this.htmlPanelResult.Text += "<!DOCTYPE html><html lang=\"en\"><head><title>Document</title><style> table,table tr th, table tr td {   border:1px solid #ccc; } th, td {  padding: 5px; }  </style></head><body>";
            //var data = bll.SelectBy("ProjectId", this.ProjectId);
            //foreach (var inst in data)
            //{
            //    if (!inst.CaseId.Contains(this.CaseId))
            //    {
            //        continue;
            //    }
            //    this.AppendText(inst);
            //}
            this.timer1.Start();
        }

        protected override void UcLoad(object sender, EventArgs e)
        {
            this.LoadData();


        }

        private void AppendText(TestResult result)
        {
            if (this.project == null)
            {
                return;
            }
            this.showIdList.Add(result.Id);
            var case1 = this.project.CaseList.Where(a => a.Id == result.CaseId).FirstOrDefault();
            if (case1 == null)
            {
                return;
            }
            string html = string.Format("<div><h3>测试例名称: {0}</h3></div>", case1.Name);
            html += string.Format("<div><h3>测试结果: <span {0} </span></h3></div>", result.IsPass ? " style='color:green'>通过" : "style='color:red'>未通过");
            html += "<br/>";
            html += "<table style='width:80%' border='1' cellspacing='0'><tr><td><strong>序号</strong></td><td><strong>结果</strong></td></tr>";
            int index = 1;
            foreach (var res in result.Result)
            {
                html += string.Format("<tr><td>{0}</td><td>{1}</td></tr>", index, res);
                index++;
            }
            html += "</table><hr>";
            this.htmlPanelResult.Text += html;
        }



    }
}
