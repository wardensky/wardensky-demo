using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Wims.Common.Entity;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public partial class FormProjectNew : FormBase
    {
        public FormProjectNew()
        {
            InitializeComponent();
            base.ignoreFields.Add("StepList");
            this.devToolStrip1.ActionClickDelete = this.ClickDeleteDev;
            //this.devToolStrip1.ShowModify = false;
            this.devToolStrip1.ActionClickModify = this.ClickModifyCase;
            this.devToolStrip1.ShowAdd = true;
            this.devToolStrip1.ActionClickAdd = this.AddTestCase;
            this.devToolStrip1.ShowCustom1 = true;
            this.devToolStrip1.TextCustom1 = "指定测试设备";
            this.devToolStrip1.ActionClickCustom1 = this.InitStepDevice;
            this.devToolStrip1.AddEvent();




        }

        public FormProjectNew(Project Entity)
            : this()
        {
            this.Entity = Entity;
            this.ucProjectInfo1.Entity = this.Entity;
        }

        private void ClickModifyCase(object arg1, EventArgs arg2)
        {
            FormProjectTestCaseNew ft = new FormProjectTestCaseNew();
            if (this.Entity == null)
            {
                return;
            }
            ft.Project = this.Entity;
            ft.Entity = this.myGridView1.FindFirstSelect<TestCase>();
            ft.ShowDialog();
        }


        private void ClickDeleteDev(object arg1, EventArgs arg2)
        {
            TestCase entity = this.myGridView1.FindFirstSelect<TestCase>();
            if (entity == null)
            {
                logger.Info("项目管理新增和修改界面、测试例删除时无选中信息");
                return;
            }
            if (entity != null)
            {
                this.isModify = true;
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.testCaseList.Remove(entity);
                    this.testCaseStrList.Remove(entity.Name);
                    this.myGridView1.LoadData(testCaseList.ToList(), base.ignoreFields);
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.Entity == null)
                {
                    this.Entity = new Project();
                }
                //this.Entity.DeviceList = new List<TestDevice>();

                //this.Entity.DeviceList.AddRange(devList);
                this.Entity.CaseList = new LinkedList<TestCase>();
                foreach (var inst in testCaseList)
                {
                    this.Entity.CaseList.AddLast(inst);
                }
                if (DicStepDevice == null)
                {
                    MessageBox.Show("未为步骤指定测试设备!");
                    return;
                }
                this.ucProjectInfo1.Entity = this.Entity;
                this.ucProjectInfo1.ReadUI();

                projectBll.Dao.Save(this.Entity);
                var taskCasseList =
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex + "");
                return;
            }

        }



        private void Cancel_Click(object sender, EventArgs e)
        {
            this.testCaseList = new LinkedList<TestCase>();
            this.testCaseStrList = new List<string>();
            this.Close();
        }

        private void FormProjectM_Load(object sender, EventArgs e)
        {
            if (this.Entity != null)
            {
                this.testCaseList = this.Entity.CaseList;
                this.myGridView1.LoadData(testCaseList.ToList(), base.ignoreFields);
            }
        }

        private void AddTestCase(object arg1, EventArgs arg2)
        {
            var testCaseByZhiDingedList = testCaseBll.SelectAll().Where(p => p.Assign.Equals(EquipmentStatus.已指定));
            foreach (var inst in testCaseByZhiDingedList)
            {
                inst.Assign = EquipmentStatus.未指定;
                testCaseBll.UpdateById(inst);
            }
            FormTestCaseSelect form = new FormTestCaseSelect();
            form.ShowDialog();
            if (form.SelectEntity != null)
            {
                if (testCaseList.Where(s => s.Id == form.SelectEntity.Id).Count() != 0)
                {
                    MessageBox.Show("您已经选择了此测试例，不可重复选择");
                    return;
                }
                testCaseList.AddLast(form.SelectEntity);

                this.myGridView1.LoadData(testCaseList.ToList(), base.ignoreFields);
            }

        }

        public void InitStepDevice(object sender, EventArgs e)
        {
            if (this.myGridView1.Rows.Count != 0)
            {
                TestCase testCase = this.myGridView1.FindFirstSelect<TestCase>();
                FormStepDevice form = new FormStepDevice(testCase);
                form.ShowDialog();
                this.myGridView1.LoadData(testCaseList.ToList(), base.ignoreFields);
            }
        }

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private LinkedList<TestCase> testCaseList = new LinkedList<TestCase>();
        private List<string> testCaseStrList = new List<string>();
        private List<TestDevice> devList = new List<TestDevice>();
        private List<string> devStrList = new List<string>();

        private static MongoUtil<TestCase> testCaseBll = DbFactory.TestCaseBll;
        private static MongoUtil<Project> projectBll = DbFactory.ProjectBll;
        private static MongoUtil<Dut> dutBll = DbFactory.DutBll;
        public TestCase TestCaseEntity { get; set; }
        public Project Entity { get; set; }
        private Dictionary<string, string> DicStepDevice = new Dictionary<string, string>();
        private bool isModify = false;
    }
}
