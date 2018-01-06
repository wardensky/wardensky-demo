using System;
using System.Linq;
using System.Xml.Linq;
using Wims.Common;

namespace CommonConfig
{
    public class ConfigBll
    {
        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "GlobalConfig.xml";
        private ConfigBll() { }

        private static ConfigBll inst;
        public static ConfigBll GetInst()
        {
            if (null == inst)
                inst = new ConfigBll();
            return inst;
        }

        public void LoadConfig()
        {
            XElement xe = XElement.Load(xmlPath);
            XElement gv = xe.Descendants("GlobalConfig").FirstOrDefault();
            if (gv != null)
            {
                GlobalValues.MQ_URL = gv.Element("MQ_URL").Value;
                GlobalValues.MONGO_URL = gv.Element("MONGO_URL").Value;
                XElement element = gv.Element("AGENT_NAME");
                if (element != null)
                {
                    GlobalValues.AGENT_NAME = element.Value;
                }
                XElement elFilter = gv.Element("AGENT_FILTER");
                if (elFilter != null)
                {
                    GlobalValues.AGENT_FILTER = elFilter.Value;
                }
            }
        }
    }
}
