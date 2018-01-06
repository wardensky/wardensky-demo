using ChinaTtlWifi.NewEntity;
using System;
using System.Windows.Forms;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormTestDeviceCrud : FormCrud<TestDevice>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FormTestDeviceNew newForm { get; set; }

        public FormTestDeviceCrud()
        {
            this.EnumType = typeof(AGENT_TYPE);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ignoreFields.Add("TestDeviceDevice");
            InitializeComponent();
            this.Text = "测试设备管理";
        }
        protected override void ClickModify(object arg1, EventArgs arg2)
        {
            try
            {
                this.newForm = new FormTestDeviceNew();
                this.newForm.Entity = this.myGridView1.FindFirstSelect<TestDevice>();
                this.newForm.ShowDialog();
                this.LoadData();
            }
            catch (Exception ex)
            {
                logger.Error(ex + "");
                return;
            }
        }

        protected override void ClickAdd(object arg1, EventArgs arg2)
        {
            this.newForm = new FormTestDeviceNew();
            this.newForm.ShowDialog();
            this.LoadData();

        }

    }
}