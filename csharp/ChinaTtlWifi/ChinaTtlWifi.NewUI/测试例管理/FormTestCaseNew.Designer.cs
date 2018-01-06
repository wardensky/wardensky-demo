using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    partial class FormTestCaseNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.texCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labTiShi = new System.Windows.Forms.Label();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.myTestStepGridView = new Wims.Common.UI.WimsGridView(this.components);
            this.myToolStrip1 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.miniToolStrip = new Wims.Common.UI.WimsToolStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myTestStepGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textDesc);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.texCode);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.labTiShi);
            this.panel3.Controls.Add(this.txtLimit);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(701, 128);
            this.panel3.TabIndex = 3;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(98, 59);
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(222, 21);
            this.textDesc.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "测试例描述：";
            // 
            // texCode
            // 
            this.texCode.Location = new System.Drawing.Point(440, 19);
            this.texCode.Name = "texCode";
            this.texCode.Size = new System.Drawing.Size(222, 21);
            this.texCode.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "测试例编号：";
            // 
            // labTiShi
            // 
            this.labTiShi.AutoSize = true;
            this.labTiShi.Location = new System.Drawing.Point(354, 87);
            this.labTiShi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTiShi.Name = "labTiShi";
            this.labTiShi.Size = new System.Drawing.Size(317, 12);
            this.labTiShi.TabIndex = 20;
            this.labTiShi.Text = "注：限值与限值之间用英文的“;”隔开,限值为小数或整数";
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(440, 59);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(222, 21);
            this.txtLimit.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "限值：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(222, 21);
            this.txtName.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "测试例名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 290);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试步骤";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.myTestStepGridView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.myToolStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(695, 270);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // myTestStepGridView
            // 
            this.myTestStepGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myTestStepGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTestStepGridView.Location = new System.Drawing.Point(3, 38);
            this.myTestStepGridView.Name = "myTestStepGridView";
            this.myTestStepGridView.RowTemplate.Height = 23;
            this.myTestStepGridView.Size = new System.Drawing.Size(689, 229);
            this.myTestStepGridView.TabIndex = 2;
            this.myTestStepGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myTestStepGridView_MouseClick);
            // 
            // myToolStrip1
            // 
            this.myToolStrip1.ActionClickAdd = null;
            this.myToolStrip1.ActionClickDelete = null;
            this.myToolStrip1.ActionClickModify = null;
            this.myToolStrip1.ActionClickSelect = null;
            this.myToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.myToolStrip1.Name = "myToolStrip1";
            this.myToolStrip1.ShowAdd = true;
            this.myToolStrip1.ShowModify = true;
            this.myToolStrip1.ShowSelect = false;
            this.myToolStrip1.Size = new System.Drawing.Size(695, 35);
            this.myToolStrip1.TabIndex = 1;
            this.myToolStrip1.Text = "myToolStrip1";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.ActionClickAdd = null;
            this.miniToolStrip.ActionClickDelete = null;
            this.miniToolStrip.ActionClickModify = null;
            this.miniToolStrip.ActionClickSelect = null;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.ShowAdd = true;
            this.miniToolStrip.ShowModify = true;
            this.miniToolStrip.ShowSelect = false;
            this.miniToolStrip.Size = new System.Drawing.Size(952, 35);
            this.miniToolStrip.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 470);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.Submit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 432);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 36);
            this.panel1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "检查测试步骤";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(612, 6);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(50, 23);
            this.Cancel.TabIndex = 23;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(539, 6);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(50, 23);
            this.Submit.TabIndex = 22;
            this.Submit.Text = "确定";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // FormTestCaseNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTestCaseNew";
            this.Text = "测试例";
            this.Load += new System.EventHandler(this.FormTestCase_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myTestStepGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labTiShi;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private WimsGridView myTestStepGridView;
        private WimsToolStrip myToolStrip1;
        private WimsToolStrip miniToolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox texCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;

    }
}