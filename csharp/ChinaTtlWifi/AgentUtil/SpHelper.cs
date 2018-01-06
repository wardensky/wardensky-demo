using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentUtil
{
    public class SpHelper
    {
        //定义 SerialPort对象
        SerialPort port1;

        //初始化SerialPort对象方法.PortName为COM口名称,例如"COM1","COM2"等,注意是string类型
        public void InitCOM(string PortName)
        {
            port1 = new SerialPort(PortName);
            port1.BaudRate = 9600;//波特率
            port1.Parity = Parity.None;//无奇偶校验位
            port1.StopBits = StopBits.Two;//两个停止位
            port1.Handshake = Handshake.RequestToSend;//控制协议
            port1.ReceivedBytesThreshold = 4;//设置 DataReceived 事件发生前内部输入缓冲区中的字节数
            port1.DataReceived += new SerialDataReceivedEventHandler(port1_DataReceived);//DataReceived事件委托
        }

        //DataReceived事件委托方法
        private void port1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                StringBuilder currentline = new StringBuilder();
                //循环接收数据
                while (port1.BytesToRead > 0)
                {
                    char ch = (char)port1.ReadByte();
                    currentline.Append(ch);
                }
                //在这里对接收到的数据进行处理
                //
                currentline = new StringBuilder();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        //打开串口的方法
        public void OpenPort()
        {
            try
            {
                port1.Open();
            }
            catch { }
            if (port1.IsOpen)
            {
                Console.WriteLine("the port is opened!");
            }
            else
            {
                Console.WriteLine("failure to open the port!");
            }
        }

        //关闭串口的方法
        public void ClosePort()
        {
            port1.Close();
            if (!port1.IsOpen)
            {
                Console.WriteLine("the port is already closed!");
            }
        }

        //向串口发送数据
        public void SendCommand(string CommandString)
        {
            byte[] WriteBuffer = Encoding.ASCII.GetBytes(CommandString);
            port1.Write(WriteBuffer, 0, WriteBuffer.Length);
        }

        public void ModifySp(string p1)
        {
            Console.WriteLine("end test");
        }
    }
}
