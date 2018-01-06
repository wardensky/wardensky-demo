﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wims.Common.Entity;
namespace Wims.Common.UI
{
    public partial class UCRowComboBox : UserControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 82);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(231, 26);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 23);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // UCRowComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCRowComboBox";
            this.Size = new System.Drawing.Size(373, 82);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }




        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        public Action<object, EventArgs> SelectChanged { get; set; }
        private bool isHideThirdRow = false;

        public bool IsHideThirdRow
        {
            get { return isHideThirdRow; }
            set { isHideThirdRow = value; }
        }

        private DockStyle comBoxDockStyle = DockStyle.Fill;

        public DockStyle ComBoxDockStyle
        {
            get { return comBoxDockStyle; }
            set { comBoxDockStyle = value; }
        }

        private RowEntity row;
        public UCRowComboBox()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            TriggerEvent();
        }
        public UCRowComboBox(RowEntity row)
        {
            InitializeComponent();
            this.row = row;
            this.Dock = DockStyle.Fill;
            this.label1.Text = row.Name + ":";
            TriggerEvent();
        }
        public UCRowComboBox(RowEntity row, List<object> list)
        {
            InitializeComponent();
            this.row = row;
            this.Dock = DockStyle.Fill;
            this.label1.Text = row.Name + ":";
            this.comboBox1.DataSource = list;
            if (row.Value != null)
            {
                this.comboBox1.Text = row.Value.ToString();
            }
            else if (list.Count > 0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            this.comboBox1.DisplayMember = row.DisplayMember;
            TriggerEvent();
        }
        public RowEntity GetRow()
        {
            if (this.row == null)
            {
                return this.row;
            }
            this.row.Value = this.comboBox1.SelectedItem;
            return this.row;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SelectChanged != null)
            {
                this.SelectChanged(sender, e);
            }
        }

        public void SetRow(string value)
        {
            this.comboBox1.Text = value;
        }

        public void ResetList(List<object> list)
        {
            this.comboBox1.DataSource = null;
            this.comboBox1.DataSource = list;
        }
        private void TriggerEvent()
        {
            this.Load += new System.EventHandler(this.tableLayoutPanel1_Load);
        }
        private void tableLayoutPanel1_Load(object sender, EventArgs e)
        {
            if (isHideThirdRow)
            {
                this.tableLayoutPanel1.RowStyles[2].Height = 0;
            }
            this.comboBox1.Dock = comBoxDockStyle;
        }
    }
}