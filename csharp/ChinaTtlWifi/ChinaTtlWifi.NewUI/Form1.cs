using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChinaTtlWifi.NewUI
{
    public partial class Form1 : Form
    {
        public Form1()
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
