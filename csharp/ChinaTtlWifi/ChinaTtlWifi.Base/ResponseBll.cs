using System;
using Wims.Common.MongoDBUtil;

namespace ChinaTtlWifi.Base
{
    public class ResponseBll : MongoUtil<Response>
    {

        private ResponseBll() { }

        private static ResponseBll inst;
        public static ResponseBll GetInst()
        {
            if (null == inst)
                inst = new ResponseBll();
            return inst;
        }
        public void Save(bool result, string msg, string oriMsgId, string agentName, string command)
        {
            Response entity = new Response();
            entity.CreateTime = DateTime.Now;
            entity.AgentName = agentName;
            entity.Command = command;
            entity.Msg = msg;
            entity.orgiMsgId = oriMsgId;
            entity.Result = result;
            this.Insert(entity);
        }
    }
}
