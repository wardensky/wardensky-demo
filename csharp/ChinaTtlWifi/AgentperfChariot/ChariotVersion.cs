 
using ChinaTtlWifi.IPerf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AgentPerfChariot
{
    public class ChariotVersion : IPerfApiChariot
    {
        public static string Version = "v1.0";
        public string GetTestValue(string FilePath)
        {
            string ret = string.Empty;
            StreamReader sr = new StreamReader(FilePath, Encoding.UTF8);
            int i = 1;
            while (!sr.EndOfStream)
            {
                i++;
                string text = sr.ReadLine();
                if (i == 6)
                {
                    string[] resultArray = text.Split(',');
                    if (resultArray.Length > 17)
                    {
                        ret = resultArray[17];
                    }
                }
            }
            return ret;
        }
    }
}
