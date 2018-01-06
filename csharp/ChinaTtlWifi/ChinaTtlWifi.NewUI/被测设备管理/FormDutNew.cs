using ChinaTtlWifi.NewEntity;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public class FormDutNew : FormBaseNew<Dut>
    {
        public FormDutNew()
        {
            this.Load += new System.EventHandler(this.FormLoad);
        }

        private void FormLoad(object sender, System.EventArgs e)
        {
            if (this.Entity == null)
            {
                this.Text = "添加被测设备";
            }
            else
            {
                this.Text = "修改被测设备";
            }
            this.Width = 500;
            this.Height = 500;
            base.uc.Init();
        }
    }
}
