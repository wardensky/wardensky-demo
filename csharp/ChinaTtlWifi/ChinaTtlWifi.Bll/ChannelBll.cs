using ChinaTtlWifi.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ChinaTtlWifi.Bll
{
    public class ChannelBll  
    {
      

        private static ChannelBll channelBll { get; set; }

        public static ChannelBll GetInst()
        {
            if (channelBll == null)
            {
                channelBll = new ChannelBll();
            }
            return channelBll;
        }
        
    }
}
