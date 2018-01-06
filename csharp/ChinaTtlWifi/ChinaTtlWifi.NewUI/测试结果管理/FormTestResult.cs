using ChinaTtlWifi.NewEntity;
using System;
using System.Windows.Forms;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormTestResult : FormCrud<Project>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormTestResult()
        {
          
            InitializeComponent();
          
            try
            {
                base.ucSearch.ignoreFields.Add("CaseList");
                base.ucSearch.ignoreFields.Add("StepDevice");
                base.ucSearch.ignoreFields.Add("DeviceList");
                base.ucSearch.ignoreFields.Add("ResultList");

                base.ShowAdd = false;
                base.myToolStrip1.ShowDelete = false;
                base.myToolStrip1.ShowSelect = false;
                base.ShowDelete = false;
                this.ShowModify = false;
                base.myToolStrip1.ShowLook = true;
                base.myToolStrip1.ActionClickLook =LookInfo;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            }
            catch (Exception ex)
            {
                logger.Info("FormTestResult FormTestResult base.ucSearch is not null, but base.ucSearch is null :" + ex);
            }

            this.Text = "测试结果管理";
        }

        private void LookInfo(object arg1, EventArgs arg2)
        {
            try
            {
                Project entity = this.myGridView1.FindFirstSelect<Project>();
                if (entity == null)
                {
                    MessageBox.Show(this, "请选中一条数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FormResultShow newForm = new FormResultShow(entity);
                newForm.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.Error(ex + "");
                return;
            }
        }
    }
}