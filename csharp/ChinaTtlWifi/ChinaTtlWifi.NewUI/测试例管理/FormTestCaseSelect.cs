using ChinaTtlWifi.NewEntity;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public class FormTestCaseSelect : FormCrud<TestCase>
    {
        public FormTestCaseSelect()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ShowSelect = true;
            this.ShowAdd = false;
            this.ShowModify = false;
            this.ShowDelete = false;
            InitializeComponent();
            base.ignoreFields.Add("StepList");
            base.ignoreFields.Add("Assign");
            this.Text = "选择测试例";


        }




    }
}
