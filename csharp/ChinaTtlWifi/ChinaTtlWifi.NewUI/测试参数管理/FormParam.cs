using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public partial class FormParam : FormBase
    {
        private static MongoUtil<TestParams> bll = DbFactory.TestParamsBll;
        private bool isModify = false;
        public TestParams Entity { get; set; }
        public FormParam()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (this.Entity == null)
            {
                this.Entity = new TestParams();
                this.Entity.Id = Guid.NewGuid().ToString();
            }
            this.Entity.Name = this.textBox1.Text.Trim();
            this.Entity.Desc = this.textBox2.Text.Trim();
            this.Entity.ParamList = (List<TestParam>)this.myGridView1.DataSource;
            if (isModify)
            {
                bll.SelectAll().RemoveAll(p => p.Id == this.Entity.Id);
            }

            bll.Dao.Save(this.Entity);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FormParam_Load(object sender, EventArgs e)
        {
            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.AddEvent();
            this.LoadUI();
        }

        private void ClickModify(object arg1, EventArgs arg2)
        {
            this.isModify = true;
            FormParamNew form = new FormParamNew();
            form.Entity = this.myGridView1.FindFirstSelect<TestParam>();
            form.ShowDialog();
            //xmlBll.Load();
            this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
        }

        private void ClickDelete(object arg1, EventArgs arg2)
        {
            TestParam entity = this.myGridView1.FindFirstSelect<TestParam>();
            if (entity != null)
            {
                this.isModify = true;
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Entity.ParamList.Remove(entity);
                    if (isModify)
                    {
                        bll.SelectAll().RemoveAll(p => p.Id == this.Entity.Id);
                    }
                    this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
                }
            }
        }

        private void ClickAdd(object arg1, EventArgs arg2)
        {

            this.isModify = false;
            FormParamNew form = new FormParamNew();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            else
            {
                if (this.Entity == null)
                {
                    this.Entity = new TestParams();
                    this.Entity.Id = Guid.NewGuid().ToString();
                    this.Entity.ParamList = new List<TestParam>();
                }
                else if (this.Entity.ParamList == null)
                {
                    this.Entity.ParamList = new List<TestParam>();
                }
                this.Entity.ParamList.Add(form.Entity);
            }
            this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
            this.myGridView1.Refresh();
            this.Refresh();
        }
        private void LoadUI()
        {
            if (this.Entity != null)
            {
                this.textBox1.Text = this.Entity.Name;
                this.textBox2.Text = this.Entity.Desc;
                this.myGridView1.LoadData(this.Entity.ParamList, base.ignoreFields);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
