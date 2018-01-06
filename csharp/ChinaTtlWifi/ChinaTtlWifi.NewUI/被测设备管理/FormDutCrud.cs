using ChinaTtlWifi.NewEntity;
using Wims.Common.UI;
namespace ChinaTtlWifi.NewUI
{
    public partial class FormDutCrud : FormCrud<Dut>
    {
        public FormDutCrud()
        {
            this.ignoreFields.Add("StepDevice");
            InitializeComponent();
            this.Text = "被测设备管理";
            base.formNew = new FormDutNew();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}