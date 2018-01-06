

using System.Collections.Generic;
namespace ChinaTtlWifi.IPerf
{
    public interface IPerfApiPerf
    {
        bool SetSSId(string ssid, string user, string password);

        void InitPerfConfig(string ip, string user, string password, List<string> commandList);

        void UpStation(string ssid, string password);
    }
}
