using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormParam : FormBase
    {
        private XmlLoader xmlBll = XmlLoader.GetInst();
        private bool isModify = false;
        public Params Entity { get; set; }
        public FormParam()
        {
            InitializeComponent();
        }


        private void ClickAdd(object sender, EventArgs arg)
        {
            this.isModify = false;
            FormParamNew form = new FormParamNew();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.Entity == null)
                {
                    this.Entity = new Params();
                    this.Entity.Id = Guid.NewGuid().ToString();
                    this.Entity.ParamList = new List<Param>();
                }
                this.Entity.ParamList.Add(form.Entity);
            }
            this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
            this.myGridView1.Refresh();
            this.Refresh();
        }
        private void ClickModify(object sender, EventArgs arg)
        {
            this.isModify = true;
            FormParamNew form = new FormParamNew();
            form.Entity = this.myGridView1.FindFirstSelect<Param>();
            form.ShowDialog();
            xmlBll.Load();
            this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
        }

        private void ClickDelete(object sender, EventArgs arg)
        {
            Param entity = this.myGridView1.FindFirstSelect<Param>();
            if (entity != null)
            {
                this.isModify = true;
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Entity.ParamList.Remove(entity);
                    if (isModify)
                    {
                        xmlBll.ParamsList.RemoveAll(p => p.Id == this.Entity.Id);
                    }
                    xmlBll.SaveParams();
                    xmlBll.Load();
                    this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
                }
            }
        }

        private void FormParam_Load(object sender, EventArgs e)
        {
            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.AddEvent();
            this.xmlBll.Load();
            this.LoadUI();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (this.Entity == null)
            {
                this.Entity = new Params();
                this.Entity.Id = Guid.NewGuid().ToString();
            }
            this.Entity.Name = this.textBox1.Text.Trim();
            this.Entity.Desc = this.textBox2.Text.Trim();
            this.Entity.ParamList = (List<Param>)this.myGridView1.DataSource;
            if (isModify)
            {
                xmlBll.ParamsList.RemoveAll(p => p.Id == this.Entity.Id);
            }
            xmlBll.ParamsList.Add(this.Entity);
            xmlBll.SaveParams();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReadUI() { }

        private void LoadUI()
        {
            if (this.Entity != null)
            {
                this.textBox1.Text = this.Entity.Name;
                this.textBox2.Text = this.Entity.Desc;
                this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
            }
        }
    }
}
