namespace ChinaTtlWifi.NewUI
{
    partial class FormProjectNew
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
            ChinaTtlWifi.NewEntity.Project project1 = new ChinaTtlWifi.NewEntity.Project();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucProjectInfo1 = new ChinaTtlWifi.NewUI.UCProjectInfo();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.devToolStrip1 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.myGridView1 = new Wims.Common.UI.WimsGridView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.Cancel = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 621F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.77612F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 681);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 615);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(858, 615);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucProjectInfo1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(850, 589);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "项目基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucProjectInfo1
            // 
            this.ucProjectInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            project1.CaseList = null;
            project1.Customer = null;
            project1.CustomerAddr = null;
            project1.CustomerPhone = null;
            project1.DeadlineTime = new System.DateTime(2017, 9, 19, 9, 42, 46, 837);
            project1.DUT = null;
            project1.EndTime = new System.DateTime(2017, 9, 19, 9, 42, 46, 837);
            project1.Id = null;
            project1.MongoId = null;
            project1.Name = null;
            project1.ResultList = null;
            project1.SamplePerson = null;
            project1.SendTime = new System.DateTime(2017, 9, 19, 9, 42, 46, 837);
            project1.StartTime = new System.DateTime(2017, 9, 19, 9, 42, 46, 837);
            project1.Status = "测试未开始";
            project1.TestPerson = null;
            this.ucProjectInfo1.Entity = project1;
            this.ucProjectInfo1.Location = new System.Drawing.Point(3, 3);
            this.ucProjectInfo1.Name = "ucProjectInfo1";
            this.ucProjectInfo1.Size = new System.Drawing.Size(844, 583);
            this.ucProjectInfo1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(850, 589);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "测试例选择";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(844, 583);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试例";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.devToolStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.myGridView1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(838, 563);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // devToolStrip1
            // 
            this.devToolStrip1.ActionClickAdd = null;
            this.devToolStrip1.ActionClickCustom1 = null;
            this.devToolStrip1.ActionClickDelete = null;
            this.devToolStrip1.ActionClickLook = null;
            this.devToolStrip1.ActionClickModify = null;
            this.devToolStrip1.ActionClickSelect = null;
            this.devToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.devToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.devToolStrip1.Name = "devToolStrip1";
            this.devToolStrip1.ShowAdd = true;
            this.devToolStrip1.ShowCustom1 = false;
            this.devToolStrip1.ShowDelete = true;
            this.devToolStrip1.ShowLook = false;
            this.devToolStrip1.ShowModify = true;
            this.devToolStrip1.ShowSelect = false;
            this.devToolStrip1.Size = new System.Drawing.Size(838, 30);
            this.devToolStrip1.TabIndex = 5;
            this.devToolStrip1.Text = "wimsToolStrip1";
            this.devToolStrip1.TextCustom1 = null;
            // 
            // myGridView1
            // 
            this.myGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridView1.Location = new System.Drawing.Point(3, 33);
            this.myGridView1.Name = "myGridView1";
            this.myGridView1.RowTemplate.Height = 23;
            this.myGridView1.Size = new System.Drawing.Size(832, 527);
            this.myGridView1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Cancel);
            this.panel3.Controls.Add(this.Submit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 624);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(858, 54);
            this.panel3.TabIndex = 4;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.Location = new System.Drawing.Point(763, 18);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(50, 23);
            this.Cancel.TabIndex = 21;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Submit
            // 
            this.Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Submit.Location = new System.Drawing.Point(668, 18);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(50, 23);
            this.Submit.TabIndex = 20;
            this.Submit.Text = "确定";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // FormProjectNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormProjectNew";
            this.Text = "测试项目管理";
            this.Load += new System.EventHandler(this.FormProjectM_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UCProjectInfo ucProjectInfo1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Wims.Common.UI.WimsToolStrip devToolStrip1;
        private Wims.Common.UI.WimsGridView myGridView1;

    }
}