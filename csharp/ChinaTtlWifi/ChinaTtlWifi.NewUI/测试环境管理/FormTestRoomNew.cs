using ChinaTtlWifi.NewEntity;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public class FormTestRoomNew : FormBaseNew<TestRoom>
    {
        public FormTestRoomNew()
        {
            this.Load += new System.EventHandler(this.FormLoad);
        }

        private void FormLoad(object sender, System.EventArgs e)
        {
            if (this.Entity == null)
            {
                this.Text = "添加测试环境";
            }
            else
            {
                this.Text = "修改被测环境";
            }
            this.Width = 500;
            this.Height = 500;
            base.uc.Init();
        }
    }
}
