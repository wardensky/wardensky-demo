using ChinaTtlWifi.IAgent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AgentChariot
{
    public class ChariotVersion : IAgentApiChariot
    {
        public static string Version = "v1.0";
        public string GetTestValue(string FilePath)
        {
            string ret = string.Empty;
            StreamReader sr = new StreamReader(FilePath, Encoding.UTF8);
            int i = 0;
            while (!sr.EndOfStream)
            {
                i++;
                string text = sr.ReadLine();
                if (i == 11)
                {
                    string[] resultArray = text.Split(',');
                    if (resultArray.Length > 9)
                    {
                        ret = resultArray[9];
                    }
                }
            }
            return ret;
        }
    }
}
