using ChinaTtlWifi.IAgent;
using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;

namespace AgentApTest
{

    public class ApImplH3c : Agent, AgentApiAp
    {
        public ApImplH3c()
        {
            this.AgentType = AGENT_TYPE.AGENT_AP;
            this.SupportModelList = new System.Collections.Generic.List<string>();
            this.SupportModelList.Add(AgentModelAp.h3c);
            this.SupportModelList.Add(AgentModelAp.huawei);
        }
        public bool SetSSId(string ssid, string user, string password)
        {
            //do something, set ssid via web
            return true;
        }


        public void InitApConfig(string ip, string user, string password, System.Collections.Generic.List<string> commandList)
        {
            throw new NotImplementedException();
        }


        public void UpStation(string ssid, string password)
        {
            throw new NotImplementedException();
        }
    }
}
