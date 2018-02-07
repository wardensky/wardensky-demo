using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace wardensky.zUI
{
    public partial class WimsToolStrip : ToolStrip
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;


        public Action<object, EventArgs> ActionClickAdd { get; set; }
        public Action<object, EventArgs> ActionClickModify { get; set; }
        public Action<object, EventArgs> ActionClickDelete { get; set; }
        public Action<object, EventArgs> ActionClickSelect { get; set; }
        public Action<object, EventArgs> ActionClickLook { get; set; }

        public Action<object, EventArgs> ActionClickCustom1 { get; set; }

        public Action<object, EventArgs> ActionClickCustom2 { get; set; }

        public string TextCustom1 { get; set; }
        public string TextCustom2 { get; set; }
        public bool ShowCustom1 { get; set; }
        private bool showCustom2 = false;
        public bool ShowCustom2 
        {
            get { return showCustom2; }
            set { showCustom2 = value; }
        }


        private bool showSelect = false;

        public bool ShowSelect
        {
            get { return showSelect; }
            set { showSelect = value; }
        }


        private bool showDelete = true;

        public bool ShowDelete
        {
            get { return showDelete; }
            set { showDelete = value; }
        }

        private bool showAdd = true;

        public bool ShowAdd
        {
            get { return showAdd; }
            set { showAdd = value; }
        }
        private bool showModify = true;

        public bool ShowModify
        {
            get { return showModify; }
            set { showModify = value; }
        }

        private bool showLook = false;

        public bool ShowLook
        {
            get { return showLook ; }
            set { showLook = value; }
        }


        public WimsToolStrip()
        {
            InitializeComponent();
        }
        public WimsToolStrip(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7});
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::wardensky.zUI.Properties.Resources.增加;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "增加";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::wardensky.zUI.Properties.Resources.修改;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "修改";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::wardensky.zUI.Properties.Resources.删除;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton3.Text = "删除";


            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::wardensky.zUI.Properties.Resources.选择;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton4.Text = "选择";

            // 
            // toolStripButton5
            // 
          //  this.toolStripButton5.Image = global::wardensky.zUI.Properties.Resources.查看;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton5.Text = "查看";

            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = global::wardensky.zUI.Properties.Resources.设备;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton6.Text = this.TextCustom1;
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::wardensky.zUI.Properties.Resources.设备;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton7.Text = this.TextCustom2;

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
            if (this.ActionClickSelect != null)
            {
                this.toolStripButton4.Click += new System.EventHandler(this.ActionClickSelect);
            }
            if (this.ActionClickLook != null)
            {
                this.toolStripButton5.Click += new System.EventHandler(this.ActionClickLook);
            }
            if (this.ActionClickCustom1 != null)
            {
                this.toolStripButton6.Click += new System.EventHandler(this.ActionClickCustom1);
            }
            if (this.ActionClickCustom2 != null)
            {
                this.toolStripButton7.Click += new System.EventHandler(this.ActionClickCustom2);
            }
            this.toolStripButton4.Visible = this.ShowSelect;
            this.toolStripButton1.Visible = this.ShowAdd;
            this.toolStripButton2.Visible = this.ShowModify;
            this.toolStripButton3.Visible = this.ShowDelete;
            this.toolStripButton5.Visible = this.ShowLook;
            this.toolStripButton6.Visible = this.ShowCustom1;
            this.toolStripButton7.Visible = this.showCustom2;

            this.toolStripButton6.Text = this.TextCustom1;
            this.toolStripButton7.Text = this.TextCustom2;
        }
    }
}