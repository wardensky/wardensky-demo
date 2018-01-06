using ChinaTtlWifi.NewEntity;
using System;
using System.Windows.Forms;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormTestRoomCrud : FormCrud<TestRoom>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       

        public FormTestRoomCrud()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ignoreFields.Add("TestRoomDevice");
            InitializeComponent();
            base.formNew = new FormTestRoomNew();
            this.Text = "测试环境管理";
        }
        

    }
}