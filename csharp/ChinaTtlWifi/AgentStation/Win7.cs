using AgentUtil;
using ChinaTtlWifi.Base;
using ChinaTtlWifi.IAgent;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace AgentStation
{
    public class Win7 : AgentApiStation
    {
        public const string MODEL = AgentModelStation.Win7;
        private static LogBll log = LogBll.GenLogBll("");
        public void ModifyWirelessMode(string modeString)
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
            Thread.Sleep(1000 * 20);
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

        public void UpStation(string ssid, string password)
        {
            CmdHelper.ConvertStringToHex(ssid);
            string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "wireless.xml";
            XElement xe = XElement.Load(xmlPath);
            foreach (var item in xe.Descendants(xe.Name.Namespace + "name"))
            {
                item.Value = ssid;
            }
            XElement hexElement = xe.Descendants(xe.Name.Namespace + "hex").FirstOrDefault();
            hexElement.Value = CmdHelper.ConvertStringToHex(ssid);
            XElement keyElement = xe.Descendants(xe.Name.Namespace + "keyMaterial").FirstOrDefault();
            keyElement.Value = password;
            xe.Save(xmlPath);
            CmdHelper.ConnectAp(ssid, password);
        }
    }
}
