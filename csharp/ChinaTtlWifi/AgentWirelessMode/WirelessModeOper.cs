using ChinaTtlWifi.Base;
using Microsoft.Win32;
using System;
using System.Threading;

namespace AgentWirelessMode
{
    public class WirelessModeOper
    {
        private static LogBll log = LogBll.GenLogBll("");

        public static void ModifyWirelessMode(string modeString)
        {
            log.Info("modeString = " + modeString);
            RegistryKey hkml = Registry.LocalMachine;
            string registData = "";
            RegistryKey myKey = hkml.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\0007", true);
            if (myKey != null)
            {
                object wirelessMode = myKey.GetValue("WirelessMode");
                if (wirelessMode == null)
                {
                    log.Info("系统不存在WirelessMode键值");
                    return;
                }
                registData = wirelessMode.ToString();
                log.Info(registData);
                myKey.SetValue("WirelessMode", modeString);
            }
            log.Info(myKey.GetValue("WirelessMode").ToString());
            NetWork("无线网络连接", "禁用");
            NetWork("无线网络连接", "启用");
        }
        /// <summary>
        /// example:
        /// NetWork("无线网络连接","禁用")
        /// NetWork("无线网络连接","启用")
        /// </summary>
        /// <param name="netWorkName"></param>
        /// <param name="operation"></param>
        static void NetWork(string netWorkName, string operation)
        {
            Shell32.Shell shell = new Shell32.ShellClass();
            Shell32.Folder folder = shell.NameSpace(49);
            foreach (Shell32.FolderItem fi in folder.Items())
            {
                if (fi.Name != netWorkName)
                    continue;

                Shell32.ShellFolderItem folderItem = (Shell32.ShellFolderItem)fi;
                foreach (Shell32.FolderItemVerb fiv in folderItem.Verbs())
                {
                    if (!fiv.Name.Contains(operation)) continue;
                    else
                    {
                        fiv.DoIt();
                        Thread.Sleep(1000);
                        break;
                    }
                }
            }
        }
    }
}
