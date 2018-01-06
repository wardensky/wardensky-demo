using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AgentUtil
{
    public class ProcessHelper
    {
        public static void ProcessStartWithNewWindow(string fileName, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = fileName;
            startInfo.Arguments = arguments;
            Process.Start(startInfo);
        }

        public static void KillProcessByFileName(string nameOrFullName)
        {
            string name = nameOrFullName;
            var processes = Process.GetProcesses().Where(p => p.MainWindowTitle.StartsWith(name));
            if (processes.Count() == 0)
            {
                return;
            }
            foreach (var process in processes)
            {
                process.CloseMainWindow();
                process.WaitForExit();

            }
        }
    }
}
