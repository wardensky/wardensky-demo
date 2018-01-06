using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormTask : FormBase
    {
        public bool IsSelect = false;
        private TaskBll taskBll = TaskBll.GetInst();
        public FormTask()
        {
            InitializeComponent();
            FormHelper.InitTaskGrid(this.myGridView1, false);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormTaskEdit form = new FormTaskEdit();
            form.Text = "添加任务";
            form.ShowDialog();
            FormHelper.LoadTask2Grid(this.myGridView1, false);
        }

        private Task FindSelect()
        {
            string taskName = this.myGridView1.SelectedRows[0].Cells[0].Value.ToString();
            return this.taskBll.SelectAll().Where(a => a.Name == taskName).FirstOrDefault();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormTaskEdit form1 = new FormTaskEdit();
            form1.Text = "修改任务";
            form1.Entity = this.FindSelect();
            form1.ShowDialog();

            FormHelper.LoadTask2Grid(this.myGridView1, false);
        }

        private void FormTask_Load(object sender, EventArgs e)
        {
            this.toolStripButton1.Visible = true;
            this.toolStripButton2.Visible = false;
            this.toolStripButton3.Visible = true;
            if (this.IsSelect)
            {
                this.toolStripButton1.Visible = false;
                this.toolStripButton2.Visible = false;
                this.toolStripButton3.Visible = false;

            }
            
            FormHelper.LoadTask2Grid(this.myGridView1, false);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Task t = this.FindSelect();
                this.taskBll.Delete(t.Id);
                FormHelper.LoadTask2Grid(this.myGridView1, false);
            }
        }
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FormMain.GetInst().CurrentTask = this.FindSelect();
            this.Close();
        }

        private void myGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormMain.GetInst().CurrentTask = this.FindSelect();
            this.Close();
        }
    }
}
