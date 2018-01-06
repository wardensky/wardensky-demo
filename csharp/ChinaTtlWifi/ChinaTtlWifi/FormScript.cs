
using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ChinaTtlWifi
{
    public partial class FormScript : FormBase
    {
        private XmlLoader xmlBll = XmlLoader.GetInst();

        public FormScript()
        {
            InitializeComponent();
        }

        private void FormScript_Load(object sender, System.EventArgs e)
        {
            this.xmlBll.Load();
            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.AddEvent();
           
            this.myGridView1.LoadData<Case>(this.xmlBll.ScriptList, base.ignoreFields);
        }


        private void ClickAdd(object sender, EventArgs arg)
        {
            FormScriptNew form = new FormScriptNew();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.myGridView1.LoadData(this.xmlBll.ScriptList, base.ignoreFields);
            }
           
           
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

     
    }
}
