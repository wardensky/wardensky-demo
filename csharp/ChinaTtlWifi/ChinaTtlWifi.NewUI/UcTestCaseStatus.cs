using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChinaTtlWifi.NewUI
{
    public partial class UCTestCaseStatus : UserControl
    {
        private Wims.Common.UI.WimsGridView projectGridView;
        private Timer timer1;
        private List<string> hides = new List<string>() { "Id", "Index", "LimitList", "StepList", "LogList", "Desc", "MongoId" };

        public void AddGridView(Project project)
        {
            if (project == null)
            {
                return;
            }
            this.projectGridView.LoadData<TestCase>(project.CaseList.ToList(), hides);
        }


        public UCTestCaseStatus()
        {
            InitializeComponent();
        }

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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UCTestCaseStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCTestCaseStatus";
            this.Size = new System.Drawing.Size(325, 355);
            this.Load += new System.EventHandler(this.UCTestCaseStatus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private void UCTestCaseStatus_Load(object sender, EventArgs e)
        {
            this.projectGridView = new Wims.Common.UI.WimsGridView(this.components);
            this.Controls.Clear();
            this.Controls.Add(this.projectGridView);
            this.projectGridView.LoadData<TestCase>(new List<TestCase>(), hides);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }



    }
}
