using ChinaTtlWifi.Base;
using System.Collections.Generic;
using Wims.Common.ActiveMQUtil;

namespace MqUtil
{
    public class MqMasterProducer
    {
        private static LogBll log = LogBll.GenLogBll("Master");
        public static string SendAction(string agentName, string command, Dictionary<string, object> param,string filter)
        {
            string ret = MqProducerQueue.GetInst().SendJsonMessage(agentName, command, param,filter);
            //log.Info("Master发送消息" + agentName + command);
            return ret;
        }
    }
}
