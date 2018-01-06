using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChinaTtlWifi.NewUI
{
    public class UCTestLog : UCTestBase
    {
        private TestLogBll bll = TestLogBll.GetInst();


        public UCTestLog()
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
                    //if (inst.CaseId.Contains(this.CaseId))
                    //{
                    this.AppendText(inst);
                    //}
                }
            }
        }

        protected override void UcLoad(object sender, EventArgs e)
        {
            this.LoadData();

        }


        public void LoadData()
        {
            this.htmlPanelResult.AutoScroll = true;
            this.htmlPanelResult.Text = "暂无数据";
            if (string.IsNullOrEmpty(this.ProjectId))
            {
                return;
            }
            this.project = this.projectBll.Select(this.ProjectId);
            this.showIdList = new List<string>();
            this.htmlPanelResult.ClearSelection();
            this.htmlPanelResult.Text = string.Empty;
            this.htmlPanelResult.Text += "<!DOCTYPE html><html lang=\"en\"><head><title>Document</title><style> table,table tr th, table tr td {   border:1px solid #ccc; } th, td {  padding: 5px; }  </style></head><body>";
            var data = bll.SelectBy("ProjectId", this.ProjectId);
            foreach (var inst in data)
            {
                //if (inst.CaseId.Contains(this.CaseId))
                //{
                this.AppendText(inst);
                //}
            }
            this.timer1.Start();
        }

        private void AppendText(TestLog result)
        {
            if (this.project == null)
            {
                return;
            }
            this.showIdList.Add(result.Id);
            string html = string.Format("{0}: {1}<br>", result.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), result.Content);
            this.htmlPanelResult.Text += html;
        }

        public void clear()
        {
            this.htmlPanelResult.Text = "<!DOCTYPE html><html lang=\"en\"><head><title>Document</title><style> table,table tr th, table tr td {   border:1px solid #ccc; } th, td {  padding: 5px; }  </style></head><body>";
        }
    }
}
