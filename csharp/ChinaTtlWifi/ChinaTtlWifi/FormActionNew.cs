
using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace ChinaTtlWifi
{
    public partial class FormActionNew : FormBase
    {
        private XmlLoader xmlBll = XmlLoader.GetInst();
        private bool isModify = false;
        public AAction Entity { get; set; }
        public FormActionNew()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, System.EventArgs e)
        {
            if (!this.ReadUI())
            {
                return;
            }
            if (isModify)
            {
                foreach (var inst in xmlBll.ActionList)
                {
                    if (inst.Id == this.Entity.Id)
                    {
                        inst.Name = this.Entity.Name;
                        inst.BreakOnFail = this.Entity.BreakOnFail;
                        inst.Command = this.Entity.Command;
                        inst.Postdelay = this.Entity.Postdelay;
                        inst.Predelay = this.Entity.Predelay;
                        inst.WaitResponse = this.Entity.WaitResponse;
                        break;
                    }
                }
            }
            else
            {
                xmlBll.ActionList.Add(this.Entity);
            }
            xmlBll.SaveActions();
            this.Close();

        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private bool ReadUI()
        {
            Regex reg = new Regex( @"^\d*$");

            if (!reg.IsMatch(this.textBox2.Text.Trim()))
            {
                MessageBox.Show("操作前等待需要输入正整数");
                return false;
            }
            if (!reg.IsMatch(this.textBox4.Text.Trim()))
            {
                MessageBox.Show("操作后等待需要输入正整数");
                return false;
            }

            if (this.Entity == null)
            {
                this.Entity = new AAction();
                this.Entity.Id = Guid.NewGuid().ToString();
            }
            this.Entity.BreakOnFail = this.comboBox2.SelectedIndex == 0;
            this.Entity.WaitResponse = this.comboBox1.SelectedIndex == 0;
            this.Entity.Predelay = Convert.ToInt32(this.textBox2.Text.Trim());
            this.Entity.Postdelay = Convert.ToInt32(this.textBox4.Text.Trim());
            this.Entity.Name = this.textBox1.Text.Trim();
            this.Entity.Command = this.textBox3.Text.Trim();
            return true;

        }

        private void LoadUI()
        {
            if (this.Entity != null)
            {
                this.isModify = true;
                this.comboBox2.SelectedIndex = this.Entity.BreakOnFail ? 0 : 1;
                this.comboBox1.SelectedIndex = this.Entity.WaitResponse ? 0 : 1;
                this.textBox2.Text = this.Entity.Predelay.ToString();
                this.textBox4.Text = this.Entity.Postdelay.ToString();
                this.textBox1.Text = this.Entity.Name;
                this.textBox3.Text = this.Entity.Command;
            }


        }

        private void FormActionNew_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;

            this.LoadUI();

        }
    }
}
