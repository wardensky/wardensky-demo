using AgentUtil;
using ChinaTtlWifi.IAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AgentAp
{
    public class QualcommAP : AgentApiAp
    {
        public const string MODEL = AgentModelAp.qualcomm;
        public bool SetSSId(string ssid, string user, string password)
        {
            throw new NotImplementedException();
        }

        public void InitApConfig(string ip, string user, string password, List<string> commandList)
        {
            TelnetHelper.SetAPConfig(ip, user, password, commandList);
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
