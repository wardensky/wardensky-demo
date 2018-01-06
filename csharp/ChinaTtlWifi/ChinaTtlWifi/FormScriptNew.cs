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
    public partial class FormScriptNew : FormBase
    {

        private Case Entity { get; set; }

        private XmlLoader xmlBll = XmlLoader.GetInst();

        public FormScriptNew()
        {
            InitializeComponent();

        }

        private void AddEndStep()
        {

            if (this.Entity.StepList.Find(a => a.Id == 99) == null)
            {
                this.Entity.StepList.Add(Step.GenEndStep());
            }
        }

        private void FormScriptNew_Load(object sender, EventArgs e)
        {
            if (this.Entity == null)
            {
                this.Entity = new Case();
            }
            if (this.Entity.StepList == null)
            {
                this.Entity.StepList = new List<Step>();
            }
            this.AddEndStep();
            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.AddEvent();
            this.xmlBll.Load();
            //       this.LoadUI();
        }
        private void ClickAdd(object sender, EventArgs arg)
        {
            FormStep form = new FormStep();
            form.ScriptEntity = this.Entity;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Entity.StepList.Add(form.Entity);
            }
            this.myGridView1.LoadData(this.Entity.StepList, base.ignoreFields);

        }

        private void ClickModify(object sender, EventArgs arg)
        {
            FormParamNew form = new FormParamNew();
            form.Entity = this.myGridView1.FindFirstSelect<Param>();
            form.ShowDialog();
            xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ActionList, base.ignoreFields);
        }

        private void ClickDelete(object sender, EventArgs arg)
        {
            Params entity = this.myGridView1.FindFirstSelect<Params>();
            if (entity != null)
            {
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //xmlBll.Remove(entity);
                    xmlBll.SaveActions();
                    xmlBll.Load();
                    this.myGridView1.LoadData(this.xmlBll.ActionList, base.ignoreFields);
                }
            }
        }

        private void ReadUI() { }

        private void LoadUI()
        {
            if (this.Entity != null)
            {
                this.textBox1.Text = this.Entity.Name;
                this.textBox2.Text = this.Entity.Desc;
                this.myGridView1.LoadData(this.Entity.StepList, base.ignoreFields);
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {

        }
    }
}
