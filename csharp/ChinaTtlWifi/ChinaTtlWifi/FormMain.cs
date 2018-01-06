using ChinaTtlWifi.Base;
using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using MqUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
 
using Wims.Common.MongoDBUtil;
namespace ChinaTtlWifi
{
    public partial class FormMain : Form
    {
        private static LogBll log = LogBll.GenLogBll("Master");
        private XmlLoader xmlLoader = XmlLoader.GetInst();
        private TaskEngineCore core;
        private Action<Log, string> ShowMessage;
        public delegate void changeStatus(out int stepId, out string status);
        /// <summary>
        /// 是否加载了任务，用来控制按钮
        /// </summary>
        private bool IsContainTask = false;

        public Task CurrentTask { get; set; }

        private Case TestCase;

        private static FormMain inst;

        public static FormMain GetInst()
        {
            if (inst == null)
                inst = new FormMain();
            return inst;
        }

        private MongoUtil<Case> scriptBll = new MongoUtil<Case>();
        private FormMain()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            //       this.webBrowser1.Navigate(@"D:\C#Program\wifi\trunk\csharp\ChinaTtlWifi\ChinaTtlWifi\bin\Debug\result.html");
        }


        private void SetTaskView()
        {

            this.dataGridView1.Rows.Clear();
            List<Case> scriptList = xmlLoader.Load();
            if (this.CurrentTask != null)
            {
                string scriptName = this.CurrentTask.ScriptName;
                TestCase = scriptList.Where(s => s.Name == scriptName).FirstOrDefault();
                if (TestCase != null)
                {
                    for (int i = 0; i < TestCase.StepList.Count; i++)
                    {
                        this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[i].Cells[0].Value = TestCase.StepList[i].Id;
                        this.dataGridView1.Rows[i].Cells[1].Value = TestCase.StepList[i].Name;
                        this.dataGridView1.Rows[i].Cells[2].Value = "未开始";
                    }
                }
            }
        }


        private void ThreadStart()
        {
            //    TaskEngineCore.GetInst().Init(this.task);
            //   Thread.Sleep(1000);
            this.core.Run();
            MessageBox.Show("测试完成");
        }

        /// <summary>
        /// 启动任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开始测试前，请保证测试设备已经连接成功。");
            if (this.TestCase == null)
            {
                MessageBox.Show("在开始前请先选择任务！");
                return;
            }
            string taskId = this.CurrentTask.Id;
            List<Log> taskLogList = log.SelectBy("TaskId", taskId);
            if (taskLogList.Count > 0)
            {
                if (MessageBox.Show("此任务存在测试数据，是否删除测试数据重新测试?", "确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    foreach (var inst in taskLogList)
                    {
                        log.Delete(inst.Id);
                    }
                }
            }

            this.core.Init(this.TestCase);
            Thread t2 = new Thread(() => ChangeStatusView());
            t2.IsBackground = true;
            t2.Start();

            Thread t1 = new Thread(() => ThreadStart());
            t1.Start();

            ShowMessage += this.SetToUI;
            Thread t = new Thread(() => this.ShowLog());
            t.IsBackground = true;
            t.Start();


        }
        private void ShowLog()
        {
            DateTime dt = new DateTime();
            for (; ; )
            {
                if (this.CurrentTask != null)
                {
                    dt = this.CurrentTask.CreateTime;
                    break;
                }
            }
            for (; ; )
            {
                Thread.Sleep(1000);

                if (true)//不是暂停状态
                {
                    List<Log> logList = log.SelectGT("CreateTime", dt).Where(s => s.TaskId == this.CurrentTask.Id).ToList();
                    if (logList.Count > 0)
                    {
                        dt = logList.Max(s => s.CreateTime);
                        foreach (var inst in logList)
                        {
                            string text = inst.CreateTime.ToString() + ": " + inst.Author + ": " + inst.Content + "\r\n";
                            ShowMessage.Invoke(inst, text);
                        }
                    }
                }
            }
        }

        private void SetToUI(Log inst, string text)
        {
            this.richTextBox1.AppendText(text);
            this.richTextBox1.ScrollToCaret();
            //if (inst.Content.Contains("result"))
            //{
            //    var p = this.webBrowser1.Document.CreateElement("p");
            //    p.InnerHtml = text;
            //    this.webBrowser1.Document.Body.AppendChild(p);
            //}
        }
        private void ChangeStatusView()
        {
            for (; ; )
            {
                //changeStatus changeStatus = new changeStatus(this.core.CheckStatus);
                //changeStatus.Invoke(out stepId, out status);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    object stepIdString = dataGridView1.Rows[i].Cells[0].Value;
                    if (stepIdString != null && core.currentStep != null && stepIdString.ToString().Equals(core.currentStep.Id.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[2].Value = core.currentStep.StepStatus;
                    }

                }
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            //SetTaskView();
            new FormTask().ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        /// <summary>
        /// 查看结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            new FormResult().ShowDialog();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!this.IsContainTask)
            {
                this.toolStripButton1.Enabled = false;
                this.toolStripButton3.Enabled = false;
            }

        }
        /// <summary>
        /// 打开任务文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "FlowConfig");
        }
        /// <summary>
        /// 被测设备管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            FormEutManage formEutManage = new FormEutManage();
            formEutManage.ShowDialog();
        }
        /// <summary>
        /// 选择任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            FormTask form = new FormTask();
            form.IsSelect = true;
            form.ShowDialog();
            this.SetTaskView();

            this.IsContainTask = this.CurrentTask != null;
            if (this.IsContainTask)
            {
                this.toolStripButton1.Enabled = true;
                this.toolStripButton3.Enabled = true;
                this.core = TaskEngineCore.GetInst(this.CurrentTask);
            }
        }
        /// <summary>
        /// 脚本管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 脚本管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormScript().ShowDialog();
        }

        private void 通道管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormChannel().ShowDialog();
        }

        private void 参数管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormParamM().ShowDialog();
        }

        private void action管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAction().ShowDialog();
        }

        private void 被测设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEutManage formEutManage = new FormEutManage();
            formEutManage.ShowDialog();
        }

        private void 任务管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormTask().ShowDialog();
        }

        private void aaaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello kek");
        }
    }
}
