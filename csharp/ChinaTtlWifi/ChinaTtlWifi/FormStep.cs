using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;

namespace ChinaTtlWifi
{
    public partial class FormStep : FormBase
    {
        private XmlLoader xmlBll = XmlLoader.GetInst();
        public Step Entity { get; set; }

        public Case ScriptEntity { get; set; }
        public FormStep()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            this.ReadUI();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStep_Load(object sender, EventArgs e)
        {
            this.InitUI();
            this.LoadUI();
        }

        private void InitUI()
        {
            xmlBll.Load();
            this.comboBox1.DataSource = xmlBll.ActionList;
            this.comboBox1.DisplayMember = "Name";

            this.comboBox2.DataSource = xmlBll.ParamsList;
            this.comboBox2.DisplayMember = "Name";

            this.comboBox3.DataSource = xmlBll.ChannelList;
            this.comboBox3.DisplayMember = "AgentName";
            if (this.ScriptEntity != null)
            {
                this.comboBox4.DataSource = this.ScriptEntity.StepList;
                this.comboBox4.DisplayMember = "Name";
            }
        }

        private void ReadUI()
        {
            if(this.Entity == null)
            {
                this.Entity = new Step();
            }
            this.Entity.Id = Convert.ToInt32(this.textBox1.Text);
            this.Entity.Name = this.textBox2.Text.Trim();
            this.Entity.Conditon = this.textBox3.Text.Trim();
            this.Entity.StepAction = this.comboBox1.SelectedItem as AAction;
            this.Entity.StepParams = this.comboBox2.SelectedItem as Params;
            this.Entity.AgentName = (this.comboBox3.SelectedItem as Channel).AgentName;
            this.Entity.NextStepId = (this.comboBox4.SelectedItem as Step).Id;



        }

        private void LoadUI()
        {
            if (this.Entity != null)
            {
                this.textBox1.Text = this.Entity.Id.ToString();
                this.textBox2.Text = this.Entity.Name;
                this.textBox3.Text = this.Entity.Conditon;
                this.comboBox1.Text = this.Entity.StepAction.Name;
                this.comboBox2.Text = this.Entity.StepParams.Name;
                this.comboBox3.Text = this.Entity.AgentName;
                this.comboBox4.Text = this.Entity.NextStepId.ToString();
            }
        }
    }
}
