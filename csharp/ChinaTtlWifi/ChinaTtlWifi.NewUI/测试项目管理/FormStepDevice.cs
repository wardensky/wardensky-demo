using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wims.Common.Entity;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;

namespace ChinaTtlWifi.NewUI
{
    public partial class FormStepDevice : FormBase
    {
        private static MongoUtil<Step> testStepBll = DbFactory.StepBll;
        private static MongoUtil<TestDevice> testDeviceBll = DbFactory.TestDeviceBll;
        private static MongoUtil<TestCase> testCaseBll = DbFactory.TestCaseBll;
        private TestCase testCase { get; set; }
        private Project project { get; set; }
        private List<TestDevice> deviceList = testDeviceBll.SelectAll();
        private int rowHeght = 40;
        private int firstHeight = 100;
        public FormStepDevice()
        {
            InitializeComponent();
        }

        public FormStepDevice(TestCase testCase)
        {
            this.testCase = testCase;
            InitializeComponent();
            this.Text = testCase.Name;
        }

        public void Form_Load(object sender, EventArgs e)
        {
          
            List<RowEntity> rowList = new List<RowEntity>();
            int j = 0;
            float f = 100F / this.testCase.StepList.Count;
            this.tableLayoutPanel2.RowStyles[0].Height = f;
            this.Height = this.firstHeight + rowHeght * this.testCase.StepList.Count;
            this.tableLayoutPanel2.RowCount = this.testCase.StepList.Count;
            for (int i = 1; i < this.testCase.StepList.Count; i++)
            {
                this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, f));
            }
            int index = 1;
            foreach (var step in this.testCase.StepList)
            {
                RowEntity rowEntity = new RowEntity();
                rowEntity.DisplayMember = "Model";
                rowEntity.Name = step.Name;
                List<object> stepDevList = this.deviceList.Where(s => s.AgentType.Equals(step.AgentType)).ToList<object>();
                UCRowComboBox row = new UCRowComboBox(rowEntity, stepDevList);
                row.IsHideThirdRow = true;
                if (this.testCase.StepList.Count == index)
                {
                    row.ComBoxDockStyle = DockStyle.Top;
                }
                else
                {
                    row.ComBoxDockStyle = DockStyle.Bottom;
                }
                index++;
                this.tableLayoutPanel2.Controls.Add(row, 0, j++);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetStepDevice(this);
            this.testCase.Assign = EquipmentStatus.已指定;
            testCaseBll.UpdateById(this.testCase);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GetStepDevice(Control control)
        {
            if (control is UCRowComboBox)
            {
                UCRowComboBox row = control as UCRowComboBox;
                RowEntity entity = row.GetRow();
                if (entity.Value != null)
                {
                    Step step = this.testCase.StepList.Where(s => s.Name == entity.Name).FirstOrDefault();
                    if (step != null)
                    {
                        TestDevice testDevice = (TestDevice)entity.Value;
                        step.TestDeviceId = testDevice.Id;
                        step.TestDeviceModel = testDevice.Model;
                    }
                }
            }
            else if (control.HasChildren)
            {
                foreach (Control item in control.Controls)
                {
                    GetStepDevice(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
