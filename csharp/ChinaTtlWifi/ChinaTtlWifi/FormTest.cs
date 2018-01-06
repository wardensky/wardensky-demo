using ChinaTtlWifi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormTest : FormBase
    {
        private List<Param> paramList = new List<Param>();

        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormParamNew form = new FormParamNew();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.paramList.Add(form.Entity);
            }
            this.myGridView1.DataSource = null;
            this.myGridView1.LoadData(this.paramList, base.ignoreFields);
            this.myGridView1.Refresh();
            this.Refresh();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Param p = new Param();
                p.Id = Guid.NewGuid().ToString();
                p.Key = i.ToString();
                p.Value = (i * 100).ToString();
                this.paramList.Add(p);
            }
            this.myGridView1.LoadData(this.paramList, base.ignoreFields);
        }
    }
}
