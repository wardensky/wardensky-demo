using ChinaTtlWifi.NewEntity;
using System;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormProjectTestCaseCrud : FormCrud<TestCase>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FormProjectTestCaseCrud()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ignoreFields.Add("StepDevice");
            this.ignoreFields.Add("StepList");
            this.ignoreFields.Add("Status");
            this.ignoreFields.Add("Assign");
            InitializeComponent();
            this.Text = "测试例管理";
        }
        protected override void ClickModify(object arg1, EventArgs arg2)
        {
            try
            {
                FormTestCaseNew newForm = new FormTestCaseNew();
                newForm.Entity = this.myGridView1.FindFirstSelect<TestCase>();
                newForm.ShowDialog();
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
            try
            {
                FormTestCaseNew newForm = new FormTestCaseNew();
                newForm.ShowDialog();
                this.LoadData();
            }
            catch (Exception ex)
            {
                logger.Info(ex + "");
            }
        }
    }
}