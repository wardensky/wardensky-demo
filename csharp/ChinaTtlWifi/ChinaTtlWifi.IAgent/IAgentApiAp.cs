
using ChinaTtlWifi.NewEntity;
using System.Collections.Generic;
namespace ChinaTtlWifi.IAgent
{
    public interface AgentApiAp
    {
        bool SetSSId(string ssid, string user, string password);

        void InitApConfig(string ip, string user, string password, List<string> commandList);

        void UpStation(string ssid, string password);
    }
}
