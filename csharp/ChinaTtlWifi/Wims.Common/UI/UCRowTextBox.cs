using System;
using System.Windows.Forms;
using Wims.Common.Entity;
namespace Wims.Common.UI
{
    public partial class UCRowTextBox : UserControl
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(173, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 21);
            this.textBox1.TabIndex = 1;
            // 
            // UCRowTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCRowTextBox";
            this.Size = new System.Drawing.Size(280, 66);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private RowEntity row;
        public UCRowTextBox()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public UCRowTextBox(RowEntity row)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.label1.Text = row.Name + ":";
            this.textBox1.Text = row.Value.ToString();
            this.row = row;
        }
        public RowEntity GetRow()
        {
            if (this.row == null)
            {
                return this.row;
            }
            string value = this.textBox1.Text.Trim();
            if (this.row.DataType == typeof(string))
            {
                this.row.Value = value;
            }
            if (this.row.DataType == typeof(int))
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.row.Value = 0;
                }
                else
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(value, this.regInt))
                    {
                        MessageBox.Show("需要输入整数");
                        return null;
                    }
                    this.row.Value = Convert.ToInt32(value);
                }
            }
            if (this.row.DataType == typeof(double))
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.row.Value = 0.0;
                }
                else
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(value, this.regDouble))
                    {
                        MessageBox.Show("需要输入小数");
                        return null;

                    }
                    this.row.Value = Convert.ToDouble(value);
                }
            }
            if (this.row.DataType == typeof(DateTime))
            {
                this.row.Value = Convert.ToDateTime(value);
            }
            return this.row;
        }

        private string regInt = @"[0-9]\d*";
        private string regDouble = @"[1-9]\d*.\d*|0.\d*[1-9]\d*";

    }
}