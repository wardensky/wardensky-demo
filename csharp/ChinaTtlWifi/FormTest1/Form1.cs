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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.htmlPanel1.Text += "<p> " + Guid.NewGuid().ToString() + " </p>";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.htmlPanel1.AutoScroll = true;
            this.htmlPanel1.Text = "<h1>head1</h1>";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.htmlPanel1.Text += @"<table border='1'><tr><td>row 1, cell 1</td><td>row 1, cell 2</td></tr><tr><td>row 2, cell 1</td><td>row 2, cell 2</td></tr></table>";
        }
    }
}
