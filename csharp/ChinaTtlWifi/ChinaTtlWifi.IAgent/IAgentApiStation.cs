using System;
namespace ChinaTtlWifi.IAgent
{
    public interface AgentApiStation
    {
        void ModifyWirelessMode(string modeString);
        void UpStation(string ssid, string password);
    }
}
