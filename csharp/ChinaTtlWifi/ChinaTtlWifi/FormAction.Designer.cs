﻿namespace ChinaTtlWifi
{
    partial class FormAction
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.myToolStrip1 = new ChinaTtlWifi.MyToolStrip(this.components);
            this.myGridView1 = new ChinaTtlWifi.MyGridView(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.myToolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.myGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(714, 377);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // myToolStrip1
            // 
            this.myToolStrip1.ActionClickAdd = null;
            this.myToolStrip1.ActionClickDelete = null;
            this.myToolStrip1.ActionClickModify = null;
            this.myToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.myToolStrip1.Name = "myToolStrip1";
            this.myToolStrip1.Size = new System.Drawing.Size(714, 29);
            this.myToolStrip1.TabIndex = 0;
            this.myToolStrip1.Text = "myToolStrip1";
            // 
            // myGridView1
            // 
            this.myGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGridView1.Location = new System.Drawing.Point(3, 32);
            this.myGridView1.Name = "myGridView1";
            this.myGridView1.RowTemplate.Height = 23;
            this.myGridView1.Size = new System.Drawing.Size(194, 44);
            this.myGridView1.TabIndex = 1;
            // 
            // FormAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 377);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAction";
            this.Text = "FormAction";
            this.Load += new System.EventHandler(this.FormAction_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MyToolStrip myToolStrip1;
        private MyGridView myGridView1;
    }
}