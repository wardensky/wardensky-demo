using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormTaskEdit : FormBase
    {

        public Task Entity { get; set; }

        private TaskBll taskBll = TaskBll.GetInst();
        private EutBll eutBll = EutBll.GetInst();
        private XmlLoader xmlLoader = XmlLoader.GetInst();

        private List<Case> scriptList;

        public FormTaskEdit()
        {

            InitializeComponent();


        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (!this.ReadUi())
            {
                return;
            }
            this.taskBll.Insert(this.Entity);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InitUi()
        {
            this.cboScript.DataSource = this.scriptList.Select(a => a.Name).ToList();
            this.cboEut.DataSource = this.eutBll.SelectAll().Select(a => a.Model).ToList();
        }

        private bool ReadUi()
        {
            string name = this.textBox1.Text.Trim();
            if (this.Entity == null)
            {
                this.Entity = new Task();
                this.Entity.Id = Guid.NewGuid().ToString();
                if (this.taskBll.SelectAll().Select(a => a.Name).Contains(this.Entity.Name))
                {
                    MessageBox.Show("同名任务已存在，请更改任务名称");
                    return false;
                }
            }

            this.Entity.Status = TaskStatus.测试未开始;
            this.Entity.Name = name;


            this.Entity.CreateTime = DateTime.Now;
            this.Entity.Desc = this.richTextBox1.Text;
            Eut eut = this.eutBll.SelectAll().Where(a => a.Model == this.cboEut.Text).FirstOrDefault();
            if (eut != null)
            {
                this.Entity.EutId = eut.Id;
                this.Entity.EutModel = eut.Model;
            }
            Case TestCase = this.scriptList.Where(a => a.Name == this.cboScript.Text).FirstOrDefault();
            if (TestCase != null)
            {
                this.Entity.ScriptId = TestCase.Id;
                this.Entity.ScriptName = TestCase.Name;
            }

            return true;
        }

        private void LoadUi()
        {
            if (this.Entity != null)
            {
                this.textBox1.Text = this.Entity.Name;
                this.richTextBox1.Text = this.Entity.Desc;
                this.cboScript.Text = this.Entity.ScriptName;
                this.cboEut.Text = this.Entity.EutModel;

            }
        }

        private void FormTaskEdit_Load(object sender, EventArgs e)
        {
            this.scriptList = xmlLoader.Load();
            this.InitUi();
            this.LoadUi();
        }
    }
}
