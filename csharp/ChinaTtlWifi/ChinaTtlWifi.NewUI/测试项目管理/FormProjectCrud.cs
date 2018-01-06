using ChinaTtlWifi.NewEntity;
using System;
using System.Windows.Forms;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormProjectCrud : FormCrud<Project>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FormProjectNew newForm { get; set; }

        public bool IsSelect { get; set; }

        public FormProjectCrud()
        {
            this.Load += FormProjectCrud_Load;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            InitializeComponent();


            this.Text = "项目管理";
        }

        void FormProjectCrud_Load(object sender, EventArgs e)
        {
            try
            {
                base.ucSearch.ignoreFields.Add("CaseList");
                base.ucSearch.ignoreFields.Add("StepDevice");
                base.ucSearch.ignoreFields.Add("DeviceList");
                base.ucSearch.ignoreFields.Add("ResultList");

                base.ShowSelect = false;
                base.ShowAdd = false;
                base.ShowModify = false;
                base.ShowDelete = false;
                this.ignoreFields.Add("StepDevice");
                this.ignoreFields.Add("CaseList");
                this.ignoreFields.Add("ResultList");
                this.ignoreFields.Add("Status");

                if (this.IsSelect)
                {
                    base.ShowSelect = true;
                    this.Text = "选择项目";
                    this.ignoreFields.Add("SamplePerson");
                    this.ignoreFields.Add("TestPerson");
                    this.ignoreFields.Add("StartTime");
                    this.ignoreFields.Add("EndTime");
                    this.ignoreFields.Add("SendTime");
                    this.ignoreFields.Add("DeadlineTime");

                }
                else
                {
                    base.ShowAdd = true;
                    base.ShowModify = true;
                    base.ShowDelete = true;
                }

            }
            catch (Exception ex)
            {
                logger.Info("FormProjectCrud FormProjectCrud base.ucSearch is not null, but base.ucSearch is null :" + ex);
            }
        }


        protected override void ClickModify(object arg1, EventArgs arg2)
        {
            try
            {
                this.newForm = new FormProjectNew(this.myGridView1.FindFirstSelect<Project>());
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
            this.newForm = new FormProjectNew();
            this.newForm.ShowDialog();
            this.LoadData();
        }

    }
}