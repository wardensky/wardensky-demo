using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChinaTtlWifi.NewEntity;
using Wims.Common.MongoDBUtil;
using ChinaTtlWifi.NewBll;

namespace ChinaTtlWifi.NewUI
{
    public partial class UCTestResultShow : UserControl
    {
        private static MongoUtil<TestCase> taskCaseBll = DbFactory.TestCaseBll;

        public Project project { get; set; }
        public UCTestResultShow()
        {
            InitializeComponent();
         
        }

        private void UCTestResultShow_Load(object sender, EventArgs e)
        {
            FormHelper.InitTaskGrid(this.wimsGridView1, true);
            FormHelper.LoadTask2Grid(this.wimsGridView1, true, project);
            this.ucTestResult1.ProjectId = this.project.Id;
            this.ucTestLog1.ProjectId = this.project.Id;
            var testCase=this.project.CaseList.FirstOrDefault();
            if (null!=testCase)
            {
                this.ucTestLog1.CaseId = testCase.Id;
                this.ucTestResult1.CaseId = testCase.Id;
            }
            this.ucTestLog1.LoadData();
            this.ucTestResult1.LoadData();

        }

        private void wimsGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = this.wimsGridView1.SelectedCells;  
            this.ucTestResult1.CaseId = a[0].Value.ToString();
            this.ucTestLog1.CaseId = a[0].Value.ToString();
            this.ucTestResult1.LoadData();
            this.ucTestLog1.LoadData();
        }
    }
}
