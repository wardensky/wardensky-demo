using CommonConfig;
using System;
using System.Windows.Forms;
using Wims.Common;

namespace ChinaTtlWifi.NewUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //这句话为了解决界面崩溃的问题
            //GlobalValues.MONGO_URL = "mongodb://192.168.163.50/chinattl";
            ConfigBll.GetInst().LoadConfig();
            GlobalValues.MONGO_URL = "mongodb://127.0.0.1/chinattl";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FormMain());
        }
    }
}
