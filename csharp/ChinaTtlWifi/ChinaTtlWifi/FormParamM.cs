using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormParamM : FormBase
    {
        public FormParamM()
        {
            base.ignoreFields.Add("ParamList");
            InitializeComponent();
        }
        private XmlLoader xmlBll = XmlLoader.GetInst();

        private void ClickAdd(object sender, EventArgs arg)
        {
            new FormParam().ShowDialog();
            xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ParamsList, base.ignoreFields);
        }
        private void ClickModify(object sender, EventArgs arg)
        {
            FormParam form = new FormParam();
            form.Entity = this.myGridView1.FindFirstSelect<Params>();
            form.ShowDialog();
            xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ParamsList, base.ignoreFields);
        }

        private void ClickDelete(object sender, EventArgs arg)
        {
            Params entity = this.myGridView1.FindFirstSelect<Params>();
            if (entity != null)
            {
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    xmlBll.ParamsList.Remove(entity);
                    xmlBll.SaveParams();
                    xmlBll.Load();
                    this.myGridView1.LoadData(this.xmlBll.ParamsList, base.ignoreFields);
                }
            }
        }
        private void FormParamM_Load(object sender, EventArgs e)
        {

            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.AddEvent();
            this.xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ParamsList, base.ignoreFields);
        }
    }
}
