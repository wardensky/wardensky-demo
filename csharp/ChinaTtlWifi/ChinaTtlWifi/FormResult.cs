using System.Linq;
using ChinaTtlWifi.Base;
using ChinaTtlWifi.Bll;
using System.Collections.Generic;
using ChinaTtlWifi.Entity;
using System.Windows.Forms;
namespace ChinaTtlWifi
{
    public partial class FormResult : FormBase
    {
        private static LogBll log = LogBll.GenLogBll("Master");
        private TaskBll taskBll = TaskBll.GetInst();
        public FormResult()
        {
            InitializeComponent();
        }

        private void FormResult_Load(object sender, System.EventArgs e)
        {
            FormHelper.InitTaskGrid(this.myGridView1, true);
            FormHelper.LoadTask2Grid(this.myGridView1, true);
        }

        private void myGridView1_Click(object sender, System.EventArgs e)
        {
            this.richTextBox1.Clear();
            string taskName = this.myGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Task t = this.taskBll.SelectBy("Name", taskName).FirstOrDefault();
            if (t == null)
            {
                return;
            }
            List<Log> logList = log.SelectBy("TaskId", t.Id).OrderBy(a => a.CreateTime).ToList();
            if (logList.Count == 0)
            {
                MessageBox.Show("没有测试结果");
                return;
            }

            foreach (var inst in logList)
            {
                this.richTextBox1.AppendText(inst.CreateTime.ToString() + ": " + inst.Author + ": " + inst.Content + "\r\n");
                this.richTextBox1.ScrollToCaret();
            }

        }
    }
}
