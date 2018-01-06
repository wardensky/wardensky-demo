using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AgentUtil
{
    public class CmdHelper
    {
        public static CmdHelper cmdHelper { get; set; }
        private static Process p { get; set; }

        public static void GetInst()
        {
            if (p == null)
                p = InitCmd();
        }
        public static void SendCmdCommand(string command, bool isExit)
        {
            p.StandardInput.WriteLine(command);
            p.StandardInput.WriteLine("exit");
            p.StandardInput.AutoFlush = true;
            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            if (isExit)
            {
                ExitCmd(p);
            }
        }

        public static void SendCmdCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"D:\iperf-3.1.3-win32\iperf.exe";
            startInfo.Arguments = "-s -i -t 90 -i 1";
            Process.Start(startInfo);
        }

        public static void SendCmdCommand(string fileName, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = fileName;
            startInfo.Arguments = arguments;
            Process.Start(startInfo);
        }

        private static void ExitCmd(Process p)
        {
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
        }

        public static void SendCmdCommandList(List<string> commandList)
        {
            Process p = InitCmd();
            foreach (var command in commandList)
            {
                p.StandardInput.WriteLine(command);
            }
            p.StandardInput.AutoFlush = true;
            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
        }

        private static System.Diagnostics.Process InitCmd()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            return p;
        }
        public static void ConnectAp(string ssid, string password)
        {
            List<string> commandList = new List<string>();
            commandList.Add("netsh wlan delete profile " + ssid);
            commandList.Add("netsh wlan add profile " + "\"" + AppDomain.CurrentDomain.BaseDirectory + "wireless.xml" + "\"");
            commandList.Add("netsh wlan connect " + ssid + "&exit");
            SendCmdCommandList(commandList);
        }

        public static string ConvertStringToHex(string ssid)
        {
            string ret = string.Empty;
            char[] chars = ssid.ToCharArray();
            foreach (var item in chars)
            {
                Int32 charInt32 = Convert.ToInt32(item);
                ret += string.Format("{0:X}", charInt32);
            }
            return ret;
        }
    }
}
