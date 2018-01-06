using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;

namespace ChinaTtlWifi
{
    public partial class FormChannelNew : FormBase
    {
        private XmlLoader xmlBll = XmlLoader.GetInst();
        private bool isModify = false;
        public Channel Entity { get; set; }
        public FormChannelNew()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            this.ReadUI();
            if (isModify)
            {
                foreach (var inst in xmlBll.ChannelList)
                {
                    if (inst.Id == this.Entity.Id)
                    {
                        inst.AgentName = this.Entity.AgentName;
                        inst.Description = this.Entity.Description;
                    }
                }

            }
            else
            {
                xmlBll.ChannelList.Add(this.Entity);
            }
            xmlBll.SaveChannels();
            this.Close();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ReadUI()
        {
            if (this.Entity == null)
            {
                this.Entity = new Channel();
                this.Entity.Id = Guid.NewGuid().ToString();

            }

            this.Entity.AgentName = this.textBox1.Text.Trim();
            this.Entity.Description = this.textBox2.Text.Trim();

        }

        private void LoadUI()
        {
            if (this.Entity != null)
            {
                this.isModify = true;
                this.textBox1.Text = this.Entity.AgentName;
                this.textBox2.Text = this.Entity.Description;
            }
        }

        private void FormChannelNew_Load(object sender, EventArgs e)
        {
            xmlBll.Load();
            this.LoadUI();
        }
    }
}
