using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormAction : FormBase
    {
        private XmlLoader xmlBll = XmlLoader.GetInst();
        public FormAction()
        {
            InitializeComponent();
        }

        private void FormAction_Load(object sender, EventArgs e)
        {
            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.AddEvent();
            this.xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ActionList, base.ignoreFields);
        }

        private void ClickAdd(object sender, EventArgs arg)
        {
            new FormActionNew().ShowDialog();
            xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ActionList, base.ignoreFields);
        }
        private void ClickModify(object sender, EventArgs arg)
        {
            FormActionNew form = new FormActionNew();
            form.Entity = this.myGridView1.FindFirstSelect<AAction>();
            form.ShowDialog();
            xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ActionList, base.ignoreFields);
        }

        private void ClickDelete(object sender, EventArgs arg)
        {
            AAction entity = this.myGridView1.FindFirstSelect<AAction>();
            if (entity != null)
            {
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    xmlBll.ActionList.Remove(entity);
                    xmlBll.SaveActions();
                    xmlBll.Load();
                    this.myGridView1.LoadData(this.xmlBll.ActionList, base.ignoreFields);
                }
            }
        }
    }
}
