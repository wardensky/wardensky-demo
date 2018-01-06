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
    public partial class FormAgentManual : Form
    {
        private static string newLine = "\n";
        public FormAgentManual(string dev, Dictionary<string, object> dic)
        {
            InitializeComponent();
            SetUI(dev, dic);
        }

        private void SetUI(string dev, Dictionary<string, object> dic)
        {
            this.richTextBox1.AppendText("******您需要将设备" + dev + "配置为*******" + newLine
                + " .您需要的命令如下：" + newLine);
            foreach (var key in dic.Keys)
            {
                this.richTextBox1.AppendText(key + "  :" + dic[key] + newLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Dispose();
        }
    }
}
