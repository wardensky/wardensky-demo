using ChinaTtlWifi.NewEntity;
using System;
using System.Windows.Forms;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormParamCrud : FormCrud<TestParams>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FormParam newForm { get; set; }

        public FormParamCrud()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.ignoreFields.Add("ParamList");
            
            InitializeComponent();
            base.ucSearch.ignoreFields.Add("ParamList");
            this.Text = "参数管理";
        }
        protected override void ClickModify(object arg1, EventArgs arg2)
        {
            try
            {
                this.newForm = new FormParam();
                this.newForm.Entity = this.myGridView1.FindFirstSelect<TestParams>();
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
            this.newForm = new FormParam();
            this.newForm.ShowDialog();
            this.LoadData();

        }

    }
}