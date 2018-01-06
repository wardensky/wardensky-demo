using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTest1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TestCase> data = new List<TestCase>();
            List<string> hides = new List<string>();
            this.wimsGridView1.LoadData<TestCase>(data, hides);
        }
    }
}
