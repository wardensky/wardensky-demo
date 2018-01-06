
using ChinaTtlWifi.NewEntity;
using System;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public partial class FormParamNew : FormBase
    {
        public TestParam Entity { get; set; }
        public FormParamNew()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (this.Entity == null)
            {
                this.Entity = new TestParam();
                this.Entity.Id = Guid.NewGuid().ToString();
            }
            this.Entity.Key = this.textBox1.Text.Trim();
            this.Entity.Value = this.textBox2.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormParamNew_Load(object sender, EventArgs e)
        {
            if (this.Entity != null)
            {
                this.textBox1.Text = this.Entity.Key;
                this.textBox2.Text = this.Entity.Value;
            }
        }
    }
}
