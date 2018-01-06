using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class MyToolStrip : ToolStrip
    {
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        public Action<object, EventArgs> ActionClickAdd { get; set; }
        public Action<object, EventArgs> ActionClickModify { get; set; }
        public Action<object, EventArgs> ActionClickDelete { get; set; }


        public MyToolStrip()
        {
            InitializeComponent();
        }

        public MyToolStrip(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ChinaTtlWifi.Properties.Resources.增加;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "增加";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::ChinaTtlWifi.Properties.Resources.修改__1_;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "修改";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::ChinaTtlWifi.Properties.Resources.删_除;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton3.Text = "删除";
        }


        public void AddEvent()
        {
            if (this.ActionClickAdd != null)
            {
                this.toolStripButton1.Click += new System.EventHandler(this.ActionClickAdd);
            }
            if (this.ActionClickModify != null)
            {
                this.toolStripButton2.Click += new System.EventHandler(this.ActionClickModify);
            }
            if (this.ActionClickDelete != null)
            {
                this.toolStripButton3.Click += new System.EventHandler(this.ActionClickDelete);
            }
        }
    }
}
