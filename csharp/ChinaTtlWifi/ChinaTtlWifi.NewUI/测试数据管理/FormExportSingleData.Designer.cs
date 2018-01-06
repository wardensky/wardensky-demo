namespace ChinaTtlWifi.NewUI
{
    partial class FormExportSingleData
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCommand = new System.Windows.Forms.TabPage();
            this.tabDut = new System.Windows.Forms.TabPage();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.tabTestCase = new System.Windows.Forms.TabPage();
            this.tabTestDevice = new System.Windows.Forms.TabPage();
            this.tabTestParams = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.devToolStrip1 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.myGridView1 = new Wims.Common.UI.WimsGridView(this.components);
            this.wimsToolStrip1 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.DutGridView1 = new Wims.Common.UI.WimsGridView(this.components);
            this.wimsToolStrip2 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.ProjectGridView2 = new Wims.Common.UI.WimsGridView(this.components);
            this.wimsToolStrip3 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.TestCaseGridView3 = new Wims.Common.UI.WimsGridView(this.components);
            this.wimsToolStrip4 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.TestDeviceGridView4 = new Wims.Common.UI.WimsGridView(this.components);
            this.wimsToolStrip5 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.TestParamsGridView5 = new Wims.Common.UI.WimsGridView(this.components);
            this.tabControl1.SuspendLayout();
            this.tabCommand.SuspendLayout();
            this.tabDut.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.tabTestCase.SuspendLayout();
            this.tabTestDevice.SuspendLayout();
            this.tabTestParams.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestCaseGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestDeviceGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestParamsGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCommand);
            this.tabControl1.Controls.Add(this.tabDut);
            this.tabControl1.Controls.Add(this.tabProject);
            this.tabControl1.Controls.Add(this.tabTestCase);
            this.tabControl1.Controls.Add(this.tabTestDevice);
            this.tabControl1.Controls.Add(this.tabTestParams);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(749, 468);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCommand
            // 
            this.tabCommand.Controls.Add(this.groupBox2);
            this.tabCommand.Location = new System.Drawing.Point(4, 22);
            this.tabCommand.Name = "tabCommand";
            this.tabCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommand.Size = new System.Drawing.Size(741, 442);
            this.tabCommand.TabIndex = 0;
            this.tabCommand.Text = "命令表选择";
            this.tabCommand.UseVisualStyleBackColor = true;
            // 
            // tabDut
            // 
            this.tabDut.Controls.Add(this.groupBox1);
            this.tabDut.Location = new System.Drawing.Point(4, 22);
            this.tabDut.Name = "tabDut";
            this.tabDut.Padding = new System.Windows.Forms.Padding(3);
            this.tabDut.Size = new System.Drawing.Size(735, 386);
            this.tabDut.TabIndex = 1;
            this.tabDut.Text = "被测设备表选择";
            this.tabDut.UseVisualStyleBackColor = true;
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.groupBox3);
            this.tabProject.Location = new System.Drawing.Point(4, 22);
            this.tabProject.Name = "tabProject";
            this.tabProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabProject.Size = new System.Drawing.Size(735, 386);
            this.tabProject.TabIndex = 2;
            this.tabProject.Text = "测试项目表选择";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // tabTestCase
            // 
            this.tabTestCase.Controls.Add(this.groupBox4);
            this.tabTestCase.Location = new System.Drawing.Point(4, 22);
            this.tabTestCase.Name = "tabTestCase";
            this.tabTestCase.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestCase.Size = new System.Drawing.Size(735, 386);
            this.tabTestCase.TabIndex = 3;
            this.tabTestCase.Text = "测试例表选择";
            this.tabTestCase.UseVisualStyleBackColor = true;
            // 
            // tabTestDevice
            // 
            this.tabTestDevice.Controls.Add(this.groupBox5);
            this.tabTestDevice.Location = new System.Drawing.Point(4, 22);
            this.tabTestDevice.Name = "tabTestDevice";
            this.tabTestDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestDevice.Size = new System.Drawing.Size(735, 386);
            this.tabTestDevice.TabIndex = 4;
            this.tabTestDevice.Text = "测试设备表选择";
            this.tabTestDevice.UseVisualStyleBackColor = true;
            // 
            // tabTestParams
            // 
            this.tabTestParams.Controls.Add(this.groupBox6);
            this.tabTestParams.Location = new System.Drawing.Point(4, 22);
            this.tabTestParams.Name = "tabTestParams";
            this.tabTestParams.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestParams.Size = new System.Drawing.Size(735, 386);
            this.tabTestParams.TabIndex = 5;
            this.tabTestParams.Text = "测试参数表选择";
            this.tabTestParams.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 436);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "命令表";
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(729, 416);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 380);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "被测设备表";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.wimsToolStrip1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DutGridView1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(723, 360);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(729, 380);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试项目表";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.wimsToolStrip2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ProjectGridView2, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(723, 360);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(729, 380);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "测试例表";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.wimsToolStrip3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.TestCaseGridView3, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(723, 360);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(729, 380);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "测试设备表";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.wimsToolStrip4, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.TestDeviceGridView4, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(723, 360);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel7);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(729, 380);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "测试参数表";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.wimsToolStrip5, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.TestParamsGridView5, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(723, 360);
            this.tableLayoutPanel7.TabIndex = 0;
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
            this.devToolStrip1.ShowCustom2 = false;
            this.devToolStrip1.ShowDelete = true;
            this.devToolStrip1.ShowLook = false;
            this.devToolStrip1.ShowModify = true;
            this.devToolStrip1.ShowSelect = false;
            this.devToolStrip1.Size = new System.Drawing.Size(729, 30);
            this.devToolStrip1.TabIndex = 5;
            this.devToolStrip1.Text = "wimsToolStrip1";
            this.devToolStrip1.TextCustom1 = null;
            this.devToolStrip1.TextCustom2 = null;
            // 
            // myGridView1
            // 
            this.myGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridView1.Location = new System.Drawing.Point(3, 33);
            this.myGridView1.Name = "myGridView1";
            this.myGridView1.RowTemplate.Height = 23;
            this.myGridView1.Size = new System.Drawing.Size(723, 380);
            this.myGridView1.TabIndex = 2;
            // 
            // wimsToolStrip1
            // 
            this.wimsToolStrip1.ActionClickAdd = null;
            this.wimsToolStrip1.ActionClickCustom1 = null;
            this.wimsToolStrip1.ActionClickDelete = null;
            this.wimsToolStrip1.ActionClickLook = null;
            this.wimsToolStrip1.ActionClickModify = null;
            this.wimsToolStrip1.ActionClickSelect = null;
            this.wimsToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wimsToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wimsToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.wimsToolStrip1.Name = "wimsToolStrip1";
            this.wimsToolStrip1.ShowAdd = true;
            this.wimsToolStrip1.ShowCustom1 = false;
            this.wimsToolStrip1.ShowCustom2 = false;
            this.wimsToolStrip1.ShowDelete = true;
            this.wimsToolStrip1.ShowLook = false;
            this.wimsToolStrip1.ShowModify = true;
            this.wimsToolStrip1.ShowSelect = false;
            this.wimsToolStrip1.Size = new System.Drawing.Size(723, 30);
            this.wimsToolStrip1.TabIndex = 5;
            this.wimsToolStrip1.Text = "wimsToolStrip1";
            this.wimsToolStrip1.TextCustom1 = null;
            this.wimsToolStrip1.TextCustom2 = null;
            // 
            // DutGridView1
            // 
            this.DutGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DutGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DutGridView1.Location = new System.Drawing.Point(3, 33);
            this.DutGridView1.Name = "DutGridView1";
            this.DutGridView1.RowTemplate.Height = 23;
            this.DutGridView1.Size = new System.Drawing.Size(717, 324);
            this.DutGridView1.TabIndex = 2;
            // 
            // wimsToolStrip2
            // 
            this.wimsToolStrip2.ActionClickAdd = null;
            this.wimsToolStrip2.ActionClickCustom1 = null;
            this.wimsToolStrip2.ActionClickDelete = null;
            this.wimsToolStrip2.ActionClickLook = null;
            this.wimsToolStrip2.ActionClickModify = null;
            this.wimsToolStrip2.ActionClickSelect = null;
            this.wimsToolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wimsToolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wimsToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.wimsToolStrip2.Name = "wimsToolStrip2";
            this.wimsToolStrip2.ShowAdd = true;
            this.wimsToolStrip2.ShowCustom1 = false;
            this.wimsToolStrip2.ShowCustom2 = false;
            this.wimsToolStrip2.ShowDelete = true;
            this.wimsToolStrip2.ShowLook = false;
            this.wimsToolStrip2.ShowModify = true;
            this.wimsToolStrip2.ShowSelect = false;
            this.wimsToolStrip2.Size = new System.Drawing.Size(723, 30);
            this.wimsToolStrip2.TabIndex = 5;
            this.wimsToolStrip2.Text = "wimsToolStrip1";
            this.wimsToolStrip2.TextCustom1 = null;
            this.wimsToolStrip2.TextCustom2 = null;
            // 
            // ProjectGridView2
            // 
            this.ProjectGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjectGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectGridView2.Location = new System.Drawing.Point(3, 33);
            this.ProjectGridView2.Name = "ProjectGridView2";
            this.ProjectGridView2.RowTemplate.Height = 23;
            this.ProjectGridView2.Size = new System.Drawing.Size(717, 324);
            this.ProjectGridView2.TabIndex = 2;
            // 
            // wimsToolStrip3
            // 
            this.wimsToolStrip3.ActionClickAdd = null;
            this.wimsToolStrip3.ActionClickCustom1 = null;
            this.wimsToolStrip3.ActionClickDelete = null;
            this.wimsToolStrip3.ActionClickLook = null;
            this.wimsToolStrip3.ActionClickModify = null;
            this.wimsToolStrip3.ActionClickSelect = null;
            this.wimsToolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wimsToolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wimsToolStrip3.Location = new System.Drawing.Point(0, 0);
            this.wimsToolStrip3.Name = "wimsToolStrip3";
            this.wimsToolStrip3.ShowAdd = true;
            this.wimsToolStrip3.ShowCustom1 = false;
            this.wimsToolStrip3.ShowCustom2 = false;
            this.wimsToolStrip3.ShowDelete = true;
            this.wimsToolStrip3.ShowLook = false;
            this.wimsToolStrip3.ShowModify = true;
            this.wimsToolStrip3.ShowSelect = false;
            this.wimsToolStrip3.Size = new System.Drawing.Size(723, 30);
            this.wimsToolStrip3.TabIndex = 5;
            this.wimsToolStrip3.Text = "wimsToolStrip1";
            this.wimsToolStrip3.TextCustom1 = null;
            this.wimsToolStrip3.TextCustom2 = null;
            // 
            // TestCaseGridView3
            // 
            this.TestCaseGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestCaseGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestCaseGridView3.Location = new System.Drawing.Point(3, 33);
            this.TestCaseGridView3.Name = "TestCaseGridView3";
            this.TestCaseGridView3.RowTemplate.Height = 23;
            this.TestCaseGridView3.Size = new System.Drawing.Size(717, 324);
            this.TestCaseGridView3.TabIndex = 2;
            // 
            // wimsToolStrip4
            // 
            this.wimsToolStrip4.ActionClickAdd = null;
            this.wimsToolStrip4.ActionClickCustom1 = null;
            this.wimsToolStrip4.ActionClickDelete = null;
            this.wimsToolStrip4.ActionClickLook = null;
            this.wimsToolStrip4.ActionClickModify = null;
            this.wimsToolStrip4.ActionClickSelect = null;
            this.wimsToolStrip4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wimsToolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wimsToolStrip4.Location = new System.Drawing.Point(0, 0);
            this.wimsToolStrip4.Name = "wimsToolStrip4";
            this.wimsToolStrip4.ShowAdd = true;
            this.wimsToolStrip4.ShowCustom1 = false;
            this.wimsToolStrip4.ShowCustom2 = false;
            this.wimsToolStrip4.ShowDelete = true;
            this.wimsToolStrip4.ShowLook = false;
            this.wimsToolStrip4.ShowModify = true;
            this.wimsToolStrip4.ShowSelect = false;
            this.wimsToolStrip4.Size = new System.Drawing.Size(723, 30);
            this.wimsToolStrip4.TabIndex = 5;
            this.wimsToolStrip4.Text = "wimsToolStrip1";
            this.wimsToolStrip4.TextCustom1 = null;
            this.wimsToolStrip4.TextCustom2 = null;
            // 
            // TestDeviceGridView4
            // 
            this.TestDeviceGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestDeviceGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestDeviceGridView4.Location = new System.Drawing.Point(3, 33);
            this.TestDeviceGridView4.Name = "TestDeviceGridView4";
            this.TestDeviceGridView4.RowTemplate.Height = 23;
            this.TestDeviceGridView4.Size = new System.Drawing.Size(717, 324);
            this.TestDeviceGridView4.TabIndex = 2;
            // 
            // wimsToolStrip5
            // 
            this.wimsToolStrip5.ActionClickAdd = null;
            this.wimsToolStrip5.ActionClickCustom1 = null;
            this.wimsToolStrip5.ActionClickDelete = null;
            this.wimsToolStrip5.ActionClickLook = null;
            this.wimsToolStrip5.ActionClickModify = null;
            this.wimsToolStrip5.ActionClickSelect = null;
            this.wimsToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wimsToolStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wimsToolStrip5.Location = new System.Drawing.Point(0, 0);
            this.wimsToolStrip5.Name = "wimsToolStrip5";
            this.wimsToolStrip5.ShowAdd = true;
            this.wimsToolStrip5.ShowCustom1 = false;
            this.wimsToolStrip5.ShowCustom2 = false;
            this.wimsToolStrip5.ShowDelete = true;
            this.wimsToolStrip5.ShowLook = false;
            this.wimsToolStrip5.ShowModify = true;
            this.wimsToolStrip5.ShowSelect = false;
            this.wimsToolStrip5.Size = new System.Drawing.Size(723, 30);
            this.wimsToolStrip5.TabIndex = 5;
            this.wimsToolStrip5.Text = "wimsToolStrip1";
            this.wimsToolStrip5.TextCustom1 = null;
            this.wimsToolStrip5.TextCustom2 = null;
            // 
            // TestParamsGridView5
            // 
            this.TestParamsGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestParamsGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestParamsGridView5.Location = new System.Drawing.Point(3, 33);
            this.TestParamsGridView5.Name = "TestParamsGridView5";
            this.TestParamsGridView5.RowTemplate.Height = 23;
            this.TestParamsGridView5.Size = new System.Drawing.Size(717, 324);
            this.TestParamsGridView5.TabIndex = 2;
            // 
            // FormExportSingleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 468);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExportSingleData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出数据";
            this.Load += new System.EventHandler(this.FormExportSingleData_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabCommand.ResumeLayout(false);
            this.tabDut.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.tabTestCase.ResumeLayout(false);
            this.tabTestDevice.ResumeLayout(false);
            this.tabTestParams.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestCaseGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestDeviceGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestParamsGridView5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCommand;
        private System.Windows.Forms.TabPage tabDut;
        private System.Windows.Forms.TabPage tabProject;
        private System.Windows.Forms.TabPage tabTestCase;
        private System.Windows.Forms.TabPage tabTestDevice;
        private System.Windows.Forms.TabPage tabTestParams;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Wims.Common.UI.WimsToolStrip devToolStrip1;
        private Wims.Common.UI.WimsGridView myGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Wims.Common.UI.WimsToolStrip wimsToolStrip1;
        private Wims.Common.UI.WimsGridView DutGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Wims.Common.UI.WimsToolStrip wimsToolStrip2;
        private Wims.Common.UI.WimsGridView ProjectGridView2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private Wims.Common.UI.WimsToolStrip wimsToolStrip3;
        private Wims.Common.UI.WimsGridView TestCaseGridView3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Wims.Common.UI.WimsToolStrip wimsToolStrip4;
        private Wims.Common.UI.WimsGridView TestDeviceGridView4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private Wims.Common.UI.WimsToolStrip wimsToolStrip5;
        private Wims.Common.UI.WimsGridView TestParamsGridView5;
    }
}