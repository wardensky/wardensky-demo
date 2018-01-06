using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormTest1
{
    public partial class Form2 : Form
    {

        private TestResultBll bll = TestResultBll.GetInst();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestResult result = new TestResult();
            result.ProjectId = "9afcdaf0-3f86-48f3-bf85-84111f05a5c1";
            result.CaseId = "fd630f37-f8d7-4b7c-931b-cedb79ca0a10";
            result.IsPass = false;
            result.CreateTime = DateTime.Now;
            result.Result = new List<double>();
            result.Result.Add(Convert.ToDouble(this.richTextBox1.Text.Trim()));
            

            bll.Insert(result);
        }
    }
}
