using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormChannel : FormBase
    {
        private XmlLoader xmlBll = XmlLoader.GetInst();
        public FormChannel()
        {
            InitializeComponent();
            this.Text = "通道管理";
        }

        private void FormChannel_Load(object sender, EventArgs e)
        {
            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.AddEvent();
            this.xmlBll.Load();
            this.myGridView1.LoadData(this.xmlBll.ChannelList, base.ignoreFields);
        }


        private void ClickAdd(object sender, EventArgs arg)
        {
            new FormChannelNew().ShowDialog();
            this.myGridView1.LoadData(this.xmlBll.ChannelList, base.ignoreFields);
        }
        private void ClickModify(object sender, EventArgs arg)
        {
            FormChannelNew form = new FormChannelNew();
            form.Entity = this.myGridView1.FindFirstSelect<Channel>();
            form.ShowDialog();
            this.myGridView1.LoadData(this.xmlBll.ChannelList, base.ignoreFields);
        }

        private void ClickDelete(object sender, EventArgs arg)
        {
            Channel entity = this.myGridView1.FindFirstSelect<Channel>();
            if (entity != null)
            {
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    xmlBll.ChannelList.Remove(entity);
                    xmlBll.SaveChannels();
                    xmlBll.Load();
                    this.myGridView1.LoadData(this.xmlBll.ChannelList, base.ignoreFields);
                }
            }
        }
    }
}
