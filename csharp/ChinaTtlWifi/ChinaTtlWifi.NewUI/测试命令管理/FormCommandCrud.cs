using ChinaTtlWifi.NewEntity;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormCommandCrud : FormCrud<Command>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FormCommandCrud()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ignoreFields.Add("StepDevice");
            this.ignoreFields.Add("WaitResponse");
            this.ignoreFields.Add("BreakOnFail");
            base.formNew = new FormCommandNew();
            InitializeComponent();
            this.ucSearch.ignoreFields.Add("WaitResponse");
            this.ucSearch.ignoreFields.Add("BreakOnFail");
            this.Text = "命令管理";
        }


    }
}