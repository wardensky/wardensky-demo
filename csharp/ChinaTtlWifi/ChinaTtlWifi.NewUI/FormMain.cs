using Apache.NMS;
using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Wims.Common.ActiveMQUtil;
using Wims.Common.MongoDBUtil;
using System.Linq;
using ProjectStatus = ChinaTtlWifi.NewEntity.TestStatus;
using System.Diagnostics;
using Wisdombud.BLL;
using System.Text.RegularExpressions;
using MqUtil;

namespace ChinaTtlWifi.NewUI
{
    public partial class FormMain : Form
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormMain()
        {
            InitializeComponent();

            StartAgentManual();
        }

        private void StartAgentManual()
        {
            Thread t = new Thread(() => startListen());
            t.Start();
        }

        private static void startListen()
        {
            MqConsumerQueue.GetInst(consumer_Listener, "AGENT_MANUAL", "");
            for (; ; )
            {
                //log.HeartBeat("I'm alive");
                Thread.Sleep(1000 * 20);
            }
            //log.Info(AGENT_NAME + "开始监听");
        }
        private static void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            string projectId = string.Empty;
            string caseId = string.Empty;
            string stepId = string.Empty;
            try
            {
                Dictionary<string, object> param = MqConsumerBase.ReadMapFromJson(msg.Text);
                projectId = param["projectId"].ToString();
                caseId = param["caseId"].ToString();
                stepId = param["stepId"].ToString();
                string dev = param["deviceModel"].ToString();
                param.Remove("projectId");
                param.Remove("deviceModel");
                param.Remove("caseId");
                param.Remove("stepId");

                FormAgentManual form = new FormAgentManual(dev, param);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    //发送成功消息
                    MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试通过, "AGENT_MANUAL完成测试,测试通过", projectId, caseId, stepId);
                }
                else
                {
                    MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试未通过, "AGENT_MANUAL完成测试,测试未通过", projectId, caseId, stepId);
                }

            }
            catch (Exception ex)
            {
                MqAgentProducer.SendResponse(msg.NMSMessageId, StepTestStatus.测试异常, ex.ToString(), projectId, caseId, stepId);
            }
        }

        private void 被测设备管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormDutCrud().ShowDialog();
        }

        private void 测试项目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjectCrud form = new FormProjectCrud();
            form.IsSelect = false;
            form.ShowDialog();
        }

        private void 测试环境管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormTestRoomCrud().ShowDialog();
        }

        private void 参数管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormParamCrud().ShowDialog();
        }

        private void 命令管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormCommandCrud().ShowDialog();
        }

        private void 测试例管理ToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            new FormTestCaseCrud().ShowDialog();
        }



        private void 测试设备管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormTestDeviceCrud().ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }

        private void 帮助手册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未找到帮助手册");

        }

        private void 测试报告管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 测试结果管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new FormTestResult().ShowDialog();
            }
            catch (Exception ex)
            {
                logger.Info(ex + "");
            }

        }
        /// <summary>
        /// 选择任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            FormProjectCrud form = new FormProjectCrud();
            form.IsSelect = true;
            form.ShowDialog();
            if (form.SelectEntity == null)
            {
                return;
            }
            if (form.SelectEntity.CaseList.Count() == 0)
            {
                MessageBox.Show("该项目尚未选择测试例，请先选择测试例后再进行测试！");
                return;
            }
            string projectId = form.SelectEntity.Id;
            this.ucTestCaseStatus1.AddGridView(form.SelectEntity);
            this.currentProject = form.SelectEntity;
            this.uCTestResult1.ProjectId = projectId;
            this.uCTestLog1.ProjectId = projectId;
            this.uCTestResult1.LoadData();
            this.uCTestLog1.LoadData();
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.ucTestCaseStatus1.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(this.ucTestCaseStatus1);
            this.groupBox1.Controls.Clear();
            this.groupBox2.Controls.Clear();
            this.groupBox1.Controls.Add(this.uCTestResult1);
            this.groupBox2.Controls.Add(this.uCTestLog1);
        }


        /// <summary>
        /// 开始任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.currentProject != null)
            {
                if (this.currentProject.Status == ProjectStatus.测试中)
                {
                    MessageBox.Show("任务正在进行中，请勿重复开始！");
                }
                else if (this.currentProject.CaseList.Where(s => s.Assign == EquipmentStatus.未指定).Count() > 0)
                {
                    MessageBox.Show("未对当前case配置设备，请先配置设备后再开始！");
                }
                else
                {
                    this.engine = TestEngineCore.GetInst(this.currentProject);
                    this.engine.Init();
                    Thread t = new Thread(() =>
                    {
                        this.engine.Run();
                    });
                    t.Start();
                }
            }
        }


        private TestEngineCore engine;
        private Project currentProject;

        private TestLogBll log = TestLogBll.GetInst();
        private UCTestCaseStatus ucTestCaseStatus1;
        private UCTestLog uCTestLog1;
        private UCTestResult uCTestResult1;
        private MongoUtil<Project> projectBll = DbFactory.ProjectBll;

        private void 导入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 导入全部数据
        /// </summary>
        private void AddAllData()
        {
            string path = string.Empty;
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.ShowNewFolderButton = false;
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                path = browserDialog.SelectedPath;
            }
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show(this, "未选择导入文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            if (files == null || files.Count() == 0)
            {
                MessageBox.Show(this, string.Format(directory.Name + "文件夹中没有文件，无法导入！"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool boo = true;

            using (var ssm = new SplashScreenManager(this, typeof(SysWaitForm), true, true))
            {
                ssm.ShowWaitForm();
                ssm.SetWaitFormDescription("正在导入...");
                //遍历所有文件
                try
                {
                    foreach (var file in files)
                    {
                        if (file.Length == 0)
                        {
                            continue;
                        }
                        if (file.Name.Contains("Command"))
                        {
                            var personFileList = FormatterSerializerBll<Command>.ImportData(file.FullName);
                            var commandList = DbFactory.CommandBll.SelectAll();
                            foreach (var o in personFileList)
                            {
                                var oCount = commandList.Where(p => p.Cmd.Equals(o.Cmd) || p.Cmd.StartsWith(o.Cmd + "(")).ToList().Count();
                                o.Cmd = oCount == 0 ? o.Cmd : o.Cmd + "(" + oCount + ")";
                                o.Id = null;
                                DbFactory.CommandBll.Insert(o);
                            }
                            continue;
                        }
                        else if (file.Name.Contains("Dut"))
                        {
                            var personFileList = FormatterSerializerBll<Dut>.ImportData(file.FullName);
                            var DutList = DbFactory.DutBll.SelectAll();
                            foreach (var o in personFileList)
                            {
                                var oCount = DutList.Where(p => p.Name.Equals(o.Name) || p.Name.StartsWith(o.Name + "(")).ToList().Count();
                                o.Name = oCount == 0 ? o.Name : o.Name + "(" + oCount + ")";
                                o.Id = null;
                                DbFactory.DutBll.Insert(o);
                            }
                            continue;
                        }

                        else if (file.Name.Contains("Project"))
                        {
                            var personFileList = FormatterSerializerBll<Project>.ImportData(file.FullName);
                            var ProjectList = DbFactory.ProjectBll.SelectAll();
                            foreach (var o in personFileList)
                            {
                                var oCount = ProjectList.Where(p => p.Name.Equals(o.Name) || p.Name.StartsWith(o.Name + "(")).ToList().Count();
                                o.Name = oCount == 0 ? o.Name : o.Name + "(" + oCount + ")";

                                o.Id = null;
                                DbFactory.ProjectBll.Insert(o);
                            }
                            continue;
                        }
                        else if (file.Name.Contains("TestCase"))
                        {
                            var personFileList = FormatterSerializerBll<TestCase>.ImportData(file.FullName);
                            var TestCaseList = DbFactory.TestCaseBll.SelectAll();
                            foreach (var o in personFileList)
                            {
                                var oCount = TestCaseList.Where(p => p.Name.Equals(o.Name) || p.Name.StartsWith(o.Name + "(")).ToList().Count();
                                o.Name = oCount == 0 ? o.Name : o.Name + "(" + oCount + ")";

                                o.Id = null;
                                DbFactory.TestCaseBll.Insert(o);
                            }
                            continue;
                        }
                        else if (file.Name.Contains("TestDevice"))
                        {
                            var personFileList = FormatterSerializerBll<TestDevice>.ImportData(file.FullName);
                            var TestDeviceList = DbFactory.TestDeviceBll.SelectAll();
                            foreach (var o in personFileList)
                            {
                                var oCount = TestDeviceList.Where(p => p.DeviceCode.Equals(o.DeviceCode) || p.DeviceCode.StartsWith(o.DeviceCode + "(")).ToList().Count();
                                o.DeviceCode = oCount == 0 ? o.DeviceCode : o.DeviceCode + "(" + oCount + ")";
                                o.Id = null;
                                DbFactory.TestDeviceBll.Insert(o);
                            }
                            continue;
                        }
                        else if (file.Name.Contains("TestParams"))
                        {
                            var personFileList = FormatterSerializerBll<TestParams>.ImportData(file.FullName);
                            var TestParamsList = DbFactory.TestParamsBll.SelectAll();
                            foreach (var o in personFileList)
                            {
                                var oCount = TestParamsList.Where(p => p.Name.Equals(o.Name) || p.Name.StartsWith(o.Name + "(")).ToList().Count();
                                o.Name = oCount == 0 ? o.Name : o.Name + "(" + oCount + ")";
                                o.Id = null;
                                DbFactory.TestParamsBll.Insert(o);
                            }
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (boo == true)
                    {
                        ssm.CloseWaitForm();
                        MessageBox.Show(this, "数据导入完毕！", "提示", MessageBoxButtons.OK);
                    }
                }
                catch (Exception)
                {
                    ssm.CloseWaitForm();
                    MessageBox.Show(this, "导入的数据格式不正确！", "提示", MessageBoxButtons.OK);
                    boo = false;
                }
            }
        }

        private void ExportAllData(string text)
        {
            string selectedPath = string.Empty;
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedPath = fileDialog.SelectedPath;
            }

            if (string.IsNullOrEmpty(selectedPath) == true)
            {
                return;
            }
            string folderPath = string.Empty;
            using (var ssm = new SplashScreenManager(this, typeof(SysWaitForm), true, true))
            {
                ssm.ShowWaitForm();
                ssm.SetWaitFormDescription("正在" + text + "保存...");
                folderPath = Path.Combine(selectedPath, "ExportpData");
                this.ExportDataToPath(folderPath);
                ssm.CloseWaitForm();
                MessageBox.Show(this, "全部数据" + text + "成功！文件夹名：ExportpData", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Process.Start(folderPath);
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="folderPath"></param>
        private void ExportDataToPath(string folderPath)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
            Directory.CreateDirectory(folderPath);
            //Command
            BackupDataBll<Command>.ExportData(folderPath);
            //Dut
            BackupDataBll<Dut>.ExportData(folderPath);
            //Project
            BackupDataBll<Project>.ExportData(folderPath);
            //Step
            BackupDataBll<Step>.ExportData(folderPath);
            //TestCase
            BackupDataBll<TestCase>.ExportData(folderPath);
            //TestDevice
            BackupDataBll<TestDevice>.ExportData(folderPath);
            //TestParams
            BackupDataBll<TestParams>.ExportData(folderPath);
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.engine == null)
            {
                MessageBox.Show("项目尚未运行！");
                return;
            }
            this.engine.IsZhongZhi = true;
            MessageBox.Show("项目已终止！");
        }

        private void 全部数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddAllData();
        }

        private void 全部数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ExportAllData("导出");
        }

        private void 单个数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExportSingleData formExportSingleData = new FormExportSingleData();
            formExportSingleData.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.uCTestLog1.clear();
        }
    }
}
