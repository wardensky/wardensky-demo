
using ChinaTtlWifi.NewEntity;
using System.Collections.Generic;
using Wims.Common.ActiveMQUtil;
namespace MqUtil
{
    public class MqAgentProducer
    {
        public static string SendResponse(string messageId, StepTestStatus result, string message, string projectId, string caseId, string stepId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("result", result);
            param.Add("msg", message);
            param.Add("correlationId", messageId);
            param.Add("projectId", projectId);
            param.Add("caseId", caseId);
            param.Add("stepId", stepId);
            string ret = MqProducerQueue.GetInst().SendJsonMessage(MqConst.RESPONSE_Q, null, param, null);
            return ret;
        }

        public static string SendResponse(string messageId, bool result, string message)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("result", result);
            param.Add("msg", message);
            param.Add("correlationId", messageId);
            string ret = MqProducerQueue.GetInst().SendJsonMessage(MqConst.RESPONSE_Q, null, param, null);
            return ret;
        }


        public static string SendResponse(string messageId, StepTestStatus result, string message)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("result", result);
            param.Add("msg", message);
            param.Add("correlationId", messageId);
            string ret = MqProducerQueue.GetInst().SendJsonMessage(MqConst.RESPONSE_Q, null, param, null);
            return ret;
        }
    }
}
