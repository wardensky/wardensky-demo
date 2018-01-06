using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wims.Common.MongoDBUtil;

namespace ChinaTtlWifi.NewUI
{
    public class UCTestBase : UserControl
    {
        protected MongoUtil<Project> projectBll = DbFactory.ProjectBll;
        public string ProjectId { get; set; }

        protected List<string> showIdList;

        public string CaseId { get; set; }

        protected Project project;

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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.htmlPanelResult = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // htmlPanelResult
            // 
            this.htmlPanelResult.AutoScroll = true;
            this.htmlPanelResult.BackColor = System.Drawing.SystemColors.Window;
            this.htmlPanelResult.BaseStylesheet = null;
            this.htmlPanelResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.htmlPanelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlPanelResult.Location = new System.Drawing.Point(0, 0);
            this.htmlPanelResult.Name = "htmlPanelResult";
            this.htmlPanelResult.Size = new System.Drawing.Size(323, 327);
            this.htmlPanelResult.TabIndex = 1;
            this.htmlPanelResult.Text = null;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UCTestResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.htmlPanelResult);
            this.Name = "UCTestResult";
            this.Size = new System.Drawing.Size(323, 327);
            this.Load += new System.EventHandler(this.UcLoad);
            this.ResumeLayout(false);

        }

        protected virtual void timer1_Tick(object sender, EventArgs e) { }
        protected virtual void UcLoad(object sender, EventArgs e)
        {
            Console.WriteLine("xxxx");
       
        }
        #endregion

        protected TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanelResult;
        protected System.Windows.Forms.Timer timer1;
    }
}
