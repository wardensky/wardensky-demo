using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{

    public partial class FormResultShow : FormBase
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Project project { get; set; }
        public FormResultShow() { }
        public FormResultShow(Project project)
        {
            this.project = project;
            this.Load += new System.EventHandler(this.FormLoad);
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ucTestResultShow1.project = this.project;

        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.Text = "测试结果查看";
          
            this.Width = 1000;
            this.Height = 800; 
        }

        private void FormResult_Load(object sender, EventArgs e)
        {
            
        }
    }
}
