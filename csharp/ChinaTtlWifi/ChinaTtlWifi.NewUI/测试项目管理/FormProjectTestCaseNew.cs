using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;
using Wims.Common;

namespace ChinaTtlWifi.NewUI
{
    public partial class FormProjectTestCaseNew : FormBase
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TestCase Entity { get; set; }
        public Project Project { get; set; }
        private List<Step> stepList;
        private static MongoUtil<TestCase> bll = DbFactory.TestCaseBll;
        private static MongoUtil<TestDevice> testDevbll = DbFactory.TestDeviceBll;
        private static MongoUtil<Project> projectBll = DbFactory.ProjectBll;
        private List<TestDevice> devList = new List<TestDevice>();
        private List<string> devStrList = new List<string>();
        public FormProjectTestCaseNew()
        {
            this.ignoreFields.Add("Status");
            this.ignoreFields.Add("Condition");
            this.ignoreFields.Add("TestDeviceId");
            this.ignoreFields.Add("TestDeviceModel");
            this.stepList = new List<Step>();
            InitializeComponent();
        }

        private void FormTestCase_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Entity == null)
                {
                    this.Entity = new TestCase();
                }
                if (this.Entity.StepList == null)
                {
                    this.Entity.StepList = new LinkedList<Step>();

                }
                if (this.Entity.StepList.Count == 0)
                {
                    //         this.stepList.Add(Step.GenEndStep());
                }
                else
                {
                    this.stepList.AddRange(this.Entity.StepList);
                }

                if (testDevbll.SelectAll() == null)
                {
                    logger.Info("测试项配置添加功能， TestDev表里 数据为空，或者TestDev表里的Model为空，下拉框不显示数据");
                }
                var devList = testDevbll.SelectAll().Where(p => !string.IsNullOrEmpty(p.Model));
                this.myToolStrip1.ActionClickAdd = this.ClickAdd;
                this.myToolStrip1.ActionClickDelete = this.ClickDelete;
                this.myToolStrip1.ActionClickModify = this.ClickModify;
                this.myToolStrip1.ActionClickCustom1 = this.ClickModifyParams;
                this.myToolStrip1.TextCustom1 = "修改步骤参数";
                this.myToolStrip1.ShowCustom1 = true;

                this.myToolStrip1.AddEvent();
                this.Sort();
                this.myTestStepGridView.LoadData(this.stepList, base.ignoreFields);

                this.txtName.Text = this.Entity.Name;
                this.texCode.Text = this.Entity.Code;
                this.textDesc.Text = this.Entity.Desc;
                if (this.Entity.LimitList != null)
                {
                    foreach (var item in this.Entity.LimitList)
                    {
                        string dout = item + ";";
                        this.txtLimit.Text += dout;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex + "");
                return;
            }

        }
        private void ClickModify(object arg1, EventArgs arg2)
        {
            this.isModify = true;
            FormProjectStepNew form = new FormProjectStepNew();
            form.Entity = this.myTestStepGridView.FindFirstSelect<Step>();
            form.ShowDialog();
            if (this.Entity == null)
            {
                logger.Info("测试项配置新增和修改界面，测试配置修改功能，没有选中一条信息");
                return;
            }
            this.Sort();
            this.myTestStepGridView.LoadData(this.stepList, base.ignoreFields);
        }

        private bool isModify = false;

        private void ClickModifyParams(object arg1, EventArgs arg2)
        {
            FormProjectParam form = new FormProjectParam();
            Step step = this.myTestStepGridView.FindFirstSelect<Step>();
            form.step = step;
            form.testCase = Entity;
            form.project = this.Project;
            form.Entity = this.Project.CaseList.Where(s => s.Id == this.Entity.Id).FirstOrDefault().StepList.Where(p => p.Id == step.Id).FirstOrDefault().Params;
            form.ShowDialog();
            if (this.Entity == null)
            {
                logger.Info("测试项配置新增和修改界面，测试配置修改功能，没有选中一条信息");
                return;
            }
            this.Sort();
            this.myTestStepGridView.LoadData(this.stepList, base.ignoreFields);
        }

        private void Sort()
        {
            this.stepList = this.stepList.OrderBy(a => a.Index).ToList();
        }

        private void ClickDelete(object arg1, EventArgs arg2)
        {
            Step entity = this.myTestStepGridView.FindFirstSelect<Step>();
            if (this.Entity == null)
            {
                logger.Info("测试项配置新增和修改界面、测试步骤删除时无选中信息");
                return;
            }
            if (entity != null)
            {
                this.isModify = true;
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.stepList.Remove(entity);
                    this.Entity.StepList.Remove(entity);
                    if (isModify)
                    {
                        this.Project.CaseList.Where(s => s.Id == this.Entity.Id).FirstOrDefault().StepList.Remove(entity);
                        projectBll.Dao.Save(this.Project);
                    }
                    this.Sort();
                    this.myTestStepGridView.LoadData(this.stepList, base.ignoreFields);
                }
            }
        }

        private void ClickAdd(object arg1, EventArgs arg2)
        {
            FormStepNew form = new FormStepNew();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (form.Entity != null)
                {
                    this.stepList.Add(form.Entity);
                }
            }
            this.Sort();

            this.myTestStepGridView.LoadData(this.stepList, base.ignoreFields);
        }

        private void myTestStepGridView_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private bool ReadUI()
        {
            if (this.Entity == null)
            {
                this.Entity = new TestCase();
                this.Entity.Id = Guid.NewGuid().ToString();
            }
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBox.Show("测试例名称不能为空");
                return false;
            }
            this.Entity.Name = this.txtName.Text.Trim();
            this.Entity.Code = this.texCode.Text.Trim();
            this.Entity.Desc = this.textDesc.Text.Trim();
            string limitStr = this.txtLimit.Text.Trim();
            if (string.IsNullOrEmpty(limitStr))
            {
                MessageBox.Show("限值不能为空");
                return false;
            }
            var limitStrList = limitStr.Split(';').ToList();
            List<double> limitList = new List<double>();
            foreach (var inst in limitStrList)
            {
                if (string.IsNullOrEmpty(inst))
                {
                    continue;
                }
                try
                {
                    double limit = double.Parse(inst);
                    limitList.Add(limit);
                }
                catch (Exception)
                {
                    this.labTiShi.Text = "*注：限值输入不合法（除了英文状态下“;”和整数或者小数）";
                    this.labTiShi.ForeColor = Color.Red;
                    return false;
                }
            }

            this.Entity.LimitList = new List<double>();
            this.Entity.LimitList.AddRange(limitList);

            return true;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (!this.Check())
            {
                return;
            }
            if (!this.ReadUI())
            {
                return;
            }
            this.Entity.StepList.Clear();
            this.Sort();
            foreach (var inst in this.stepList)
            {
                this.Entity.StepList.AddLast(inst);
            }
            TestCase tc = this.Project.CaseList.Where(s => s.Id == this.Entity.Id).FirstOrDefault();
            if (tc == null)
            {
                this.Project.CaseList.AddLast(tc);
            }
            else
            {
                tc = this.Entity;
            }
            projectBll.Dao.Save(this.Project);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.devList = new List<TestDevice>();
                this.devStrList = new List<string>();
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex + "");
                return;
            }
        }
        /// <summary>
        /// 检测测试步骤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Check();

        }

        private bool Check()
        {
            if (this.stepList.Count == 0)
            {
                MessageBox.Show("无步骤");
                return false;
            }
            var sortData = this.stepList.AsQueryable().OrderBy("Index");
            var indexs = sortData.Select(a => a.Index);
            if (indexs.Count() != indexs.Distinct().Count())
            {
                MessageBox.Show("步骤id有重复，请检查");
                return false;
            }

            MessageBox.Show("步骤符合标准");
            return true;
        }


    }
}
