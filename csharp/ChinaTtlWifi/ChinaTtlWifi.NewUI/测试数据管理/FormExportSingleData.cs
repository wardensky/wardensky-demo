using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wims.Common;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;
using Wisdombud.BLL;

namespace ChinaTtlWifi.NewUI
{
    public partial class FormExportSingleData : FormBase
    {
        public FormExportSingleData()
        {
            InitializeComponent();
            InitEvent();
            loadData();
        }

        private void loadData()
        {
            //command
            List<Command> commandList = new List<Command>();
            commandList = DbFactory.CommandBll.SelectAll();
            this.myGridView1.LoadData(commandList, base.ignoreFields);
            //Dut
            List<Dut> DutList = new List<Dut>();
            DutList = DbFactory.DutBll.SelectAll();
            this.DutGridView1.LoadData(DutList, base.ignoreFields);
            //Project
            List<Project> ProjectList = new List<Project>();
            ProjectList = DbFactory.ProjectBll.SelectAll();
            this.ProjectGridView2.LoadData(ProjectList, base.ignoreFields);
            //TestCase
            List<TestCase> TestCaseList = new List<TestCase>();
            TestCaseList = DbFactory.TestCaseBll.SelectAll();
            this.TestCaseGridView3.LoadData(TestCaseList, base.ignoreFields);
            //TestDevice
            List<TestDevice> TestDeviceList = new List<TestDevice>();
            TestDeviceList = DbFactory.TestDeviceBll.SelectAll();
            this.TestDeviceGridView4.LoadData(TestDeviceList, base.ignoreFields);
            //TestParams
            List<TestParams> TestParamsList = new List<TestParams>();
            TestParamsList = DbFactory.TestParamsBll.SelectAll();
            this.TestParamsGridView5.LoadData(TestParamsList, base.ignoreFields);
        }

        private void InitEvent()
        {
            //命令表
            this.devToolStrip1.ShowAdd = false;
            this.devToolStrip1.ShowLook = false;
            this.devToolStrip1.ShowModify = false;
            this.devToolStrip1.ShowDelete = false;
            this.devToolStrip1.ShowCustom2 = true;
            this.devToolStrip1.ShowCustom1 = true;

            this.devToolStrip1.TextCustom1 = "导出单条数据";
            this.devToolStrip1.ActionClickCustom1 = this.InitCommand;
            this.devToolStrip1.TextCustom2 = "导出全部数据";
            this.devToolStrip1.ActionClickCustom2 = this.InitALLCommand;
            this.devToolStrip1.AddEvent();
            //被测设备
            this.wimsToolStrip1.ShowAdd = false;
            this.wimsToolStrip1.ShowLook = false;
            this.wimsToolStrip1.ShowModify = false;
            this.wimsToolStrip1.ShowDelete = false;
            this.wimsToolStrip1.ShowCustom2 = true;
            this.wimsToolStrip1.ShowCustom1 = true;

            this.wimsToolStrip1.TextCustom1 = "导出单条数据";
            this.wimsToolStrip1.ActionClickCustom1 = this.InitSingleDut;
            this.wimsToolStrip1.TextCustom2 = "导出全部数据";
            this.wimsToolStrip1.ActionClickCustom2 = this.InitAllDut;
            this.wimsToolStrip1.AddEvent();
            //测试项目
            this.wimsToolStrip2.ShowAdd = false;
            this.wimsToolStrip2.ShowLook = false;
            this.wimsToolStrip2.ShowModify = false;
            this.wimsToolStrip2.ShowDelete = false;
            this.wimsToolStrip2.ShowCustom2 = true;
            this.wimsToolStrip2.ShowCustom1 = true;

            this.wimsToolStrip2.TextCustom1 = "导出单条数据";
            this.wimsToolStrip2.ActionClickCustom1 = this.InitSingleProject;
            this.wimsToolStrip2.TextCustom2 = "导出全部数据";
            this.wimsToolStrip2.ActionClickCustom2 = this.InitAllProject;
            this.wimsToolStrip2.AddEvent();
            //测试例
            this.wimsToolStrip3.ShowAdd = false;
            this.wimsToolStrip3.ShowLook = false;
            this.wimsToolStrip3.ShowModify = false;
            this.wimsToolStrip3.ShowDelete = false;
            this.wimsToolStrip3.ShowCustom2 = true;
            this.wimsToolStrip3.ShowCustom1 = true;

            this.wimsToolStrip3.TextCustom1 = "导出单条数据";
            this.wimsToolStrip3.ActionClickCustom1 = this.InitSingleTestCase;
            this.wimsToolStrip3.TextCustom2 = "导出全部数据";
            this.wimsToolStrip3.ActionClickCustom2 = this.InitAllTestCase;
            this.wimsToolStrip3.AddEvent();
            //测试设备
            this.wimsToolStrip4.ShowAdd = false;
            this.wimsToolStrip4.ShowLook = false;
            this.wimsToolStrip4.ShowModify = false;
            this.wimsToolStrip4.ShowDelete = false;
            this.wimsToolStrip4.ShowCustom2 = true;
            this.wimsToolStrip4.ShowCustom1 = true;

            this.wimsToolStrip4.TextCustom1 = "导出单条数据";
            this.wimsToolStrip4.ActionClickCustom1 = this.InitSingleTestDevice;
            this.wimsToolStrip4.TextCustom2 = "导出全部数据";
            this.wimsToolStrip4.ActionClickCustom2 = this.InitAllTestDevice;
            this.wimsToolStrip4.AddEvent();
            //测试参数
            this.wimsToolStrip5.ShowAdd = false;
            this.wimsToolStrip5.ShowLook = false;
            this.wimsToolStrip5.ShowModify = false;
            this.wimsToolStrip5.ShowDelete = false;
            this.wimsToolStrip5.ShowCustom2 = true;
            this.wimsToolStrip5.ShowCustom1 = true;

            this.wimsToolStrip5.TextCustom1 = "导出单条数据";
            this.wimsToolStrip5.ActionClickCustom1 = this.InitSingleTestParams;
            this.wimsToolStrip5.TextCustom2 = "导出全部数据";
            this.wimsToolStrip5.ActionClickCustom2 = this.InitAllTestParams;
            this.wimsToolStrip5.AddEvent();
        }

        private void InitALLCommand(object arg1, EventArgs arg2)
        {
            ExportAllData("导出", "Command");
        }

        private void InitAllTestParams(object arg1, EventArgs arg2)
        {
            ExportAllData("导出", "TestParams");
        }

        private void InitSingleTestParams(object arg1, EventArgs arg2)
        {
            ExportSingleData("导出", "TestParams", this.TestParamsGridView5);
        }

        private void InitAllTestDevice(object arg1, EventArgs arg2)
        {
            ExportAllData("导出", "TestDevice");

        }

        private void InitSingleTestDevice(object arg1, EventArgs arg2)
        {
            ExportSingleData("导出", "TestDevice", this.TestDeviceGridView4);
        }

        private void InitAllTestCase(object arg1, EventArgs arg2)
        {
            ExportAllData("导出", "TestCase");

        }

        private void InitSingleTestCase(object arg1, EventArgs arg2)
        {
            ExportSingleData("导出", "TestCase", this.TestCaseGridView3);
        }

        private void InitAllProject(object arg1, EventArgs arg2)
        {
            ExportAllData("导出", "Project");

        }

        private void InitSingleProject(object arg1, EventArgs arg2)
        {
            ExportSingleData("导出", "Project", this.ProjectGridView2);
        }

        private void InitSingleDut(object arg1, EventArgs arg2)
        {
            ExportSingleData("导出", "Dut", this.DutGridView1);
        }

        private void InitAllDut(object arg1, EventArgs arg2)
        {
            ExportAllData("导出", "Dut");
        }

        private void InitCommand(object arg1, EventArgs arg2)
        {
            ExportSingleData("导出", "Command", this.myGridView1);
        }

        private void FormExportSingleData_Load(object sender, EventArgs e)
        {

        }

        private void ExportAllData(string text, string dataBaseName)
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
                this.ExportDataToPath(folderPath, dataBaseName);
                ssm.CloseWaitForm();
                MessageBox.Show(this, "全部数据" + text + "成功！文件夹名：ExportpData", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Process.Start(folderPath);
        }
        //导出
        private void ExportDataToPath(string folderPath, string dataBaseName)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
            Directory.CreateDirectory(folderPath);
            switch (dataBaseName)
            {
                case "Command":
                    BackupDataBll<Command>.ExportData(folderPath);
                    break;
                case "Dut":
                    BackupDataBll<Dut>.ExportData(folderPath);
                    break;
                case "Project":
                    BackupDataBll<Project>.ExportData(folderPath);
                    break;
                case "TestCase":
                    BackupDataBll<TestCase>.ExportData(folderPath);
                    break;
                case "TestDevice":
                    BackupDataBll<TestDevice>.ExportData(folderPath);
                    break;
                case "TestParams":
                    BackupDataBll<TestParams>.ExportData(folderPath);
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void ExportSingleData(string text, string dataBaseName, WimsGridView wimsGridView)
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
                this.ExportSingleDataToPath(folderPath, dataBaseName, wimsGridView);
                ssm.CloseWaitForm();
                MessageBox.Show(this, "单条数据" + text + "成功！文件夹名：ExportpData", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Process.Start(folderPath);
        }
        //导出单条数据
        private void ExportSingleDataToPath(string folderPath, string dataBaseName, WimsGridView wimsGridView)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
            Directory.CreateDirectory(folderPath);
            switch (dataBaseName)
            {
                case "Command":
                    Command Entity = wimsGridView.FindFirstSelect<Command>();
                    List<Command> commandList = new List<Command>();
                    commandList.Add(Entity);
                    BackupDataBll<Command>.ExportSingleData(folderPath, commandList);
                    break;
                case "Dut":
                    Dut dutEntity = wimsGridView.FindFirstSelect<Dut>();
                    List<Dut> dutList = new List<Dut>();
                    dutList.Add(dutEntity);
                    BackupDataBll<Dut>.ExportSingleData(folderPath, dutList);
                    break;
                case "Project":
                    Project projectEntity = wimsGridView.FindFirstSelect<Project>();
                    List<Project> projectList = new List<Project>();
                    projectList.Add(projectEntity);
                    BackupDataBll<Project>.ExportSingleData(folderPath, projectList);
                    break;
                case "TestCase":
                    TestCase testCaseEntity = wimsGridView.FindFirstSelect<TestCase>();
                    List<TestCase> testCaseList = new List<TestCase>();
                    testCaseList.Add(testCaseEntity);
                    BackupDataBll<TestCase>.ExportSingleData(folderPath, testCaseList);
                    break;
                case "TestDevice":
                    TestDevice testDeviceEntity = wimsGridView.FindFirstSelect<TestDevice>();
                    List<TestDevice> testDeviceList = new List<TestDevice>();
                    testDeviceList.Add(testDeviceEntity);
                    BackupDataBll<TestDevice>.ExportSingleData(folderPath, testDeviceList);
                    break;
                case "TestParams":
                    TestParams testParamsEntity = wimsGridView.FindFirstSelect<TestParams>();
                    List<TestParams> testParamsList = new List<TestParams>();
                    testParamsList.Add(testParamsEntity);
                    BackupDataBll<TestParams>.ExportSingleData(folderPath, testParamsList);
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

    }
}
