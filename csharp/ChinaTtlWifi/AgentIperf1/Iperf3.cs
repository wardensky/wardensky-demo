using AgentUtil;
using ChinaTtlWifi.IAgent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AgentIperf
{
    public class Iperf3 : IAgentApiIperf
    {
        public void StartLinten(string filePath, string param)
        {
            ProcessHelper.ProcessStartWithNewWindow(filePath, param);
        }
        public double GetResult(string filePath)
        {
            double limit = 0.0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                bool isEnd = false;
                while (!isEnd)
                {
                    if (sr.EndOfStream)
                    {
                        isEnd = true;
                    }
                    else
                    {
                        string limitRow = sr.ReadLine();
                        if (limitRow.Contains("receiver"))
                        {
                            string limitString = Regex.Replace(limitRow, @".*MBytes\s\s(.*?)(Mbits.*|Kbits.*)", "$1");
                            limit = double.Parse(limitString);
                            isEnd = true;
                        }
                    }
                }
                return limit;
            }
        }
    }
}
