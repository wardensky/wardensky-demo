
using ChinaTtlWifi.NewBll;
using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wims.Common.MongoDBUtil;
using Wims.Common.UI;
using System.Linq;

namespace ChinaTtlWifi.NewUI
{
    public class FormHelper
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static MongoUtil<Project> taskBll = DbFactory.ProjectBll;
        public static void LoadTask2Grid(WimsGridView grid, bool isResult, Project project)
        {
            try
            {
                grid.Rows.Clear();
                if (project == null)
                {
                    logger.Info("FormHelper LoadTask2Grid  project is null");
                    return;
                }
                foreach (TestCase t in project.CaseList)
                {
                    int index = grid.Rows.Add();
                    grid.Rows[index].Cells[0].Value = t.Id; 

                    grid.Rows[index].Cells[1].Value = t.Name;

                    var testStep = t.StepList.FirstOrDefault();
                    if (t.StepList != null && t.StepList.FirstOrDefault() != null)
                    {
                        grid.Rows[index].Cells[2].Value = t.StepList.FirstOrDefault().Status;
                    }
                    else
                    {
                        grid.Rows[index].Cells[2].Value = "";
                    }
                    if (project.ResultList != null && project.ResultList.FirstOrDefault() != null)
                    {
                        grid.Rows[index].Cells[3].Value = project.ResultList.FirstOrDefault().IsPass;
                    }
                    else
                    {
                        grid.Rows[index].Cells[3].Value = "";
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Info("FormHelper LoadTask2Grid is problem:" + ex);
            }

        }


        public static void InitTaskGrid(WimsGridView grid, bool isResult)
        {
            try
            {
                DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
                c11.Name = "测试例ID";
                c11.HeaderText = "测试例ID";
                grid.Columns.Add(c11);
                grid.Columns[0].Visible = false;

                DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
                c1.Name = "测试例名";
                c1.HeaderText = "测试例名";
                grid.Columns.Add(c1);
                DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
                c2.Name = "测试状态";
                c2.HeaderText = "被测状态";
                grid.Columns.Add(c2);
                DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
                c3.Name = "是否通过";
                c3.HeaderText = "是否通过";
                grid.Columns.Add(c3);
            }
            catch (Exception ex)
            {
                logger.Info("FormHelper InitTaskGrid is problem:" + ex);
            } 
        }
        public static void InitTaskToGrid(WimsGridView grid, bool isResult)
        {
            try
            {
                DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
                c1.Name = "测试人";
                c1.HeaderText = "测试人";
                grid.Columns.Add(c1);
                DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
                c2.Name = "测试内容";
                c2.HeaderText = "被测内容";
                grid.Columns.Add(c2);
                DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
                c3.Name = "测试等级";
                c3.HeaderText = "测试等级";
                grid.Columns.Add(c3);
                DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
                c4.Name = "测试时间";
                c4.HeaderText = "测试时间";
                grid.Columns.Add(c4);
            }
            catch (Exception ex)
            {
                logger.Info("FormHelper InitTaskToGrid is problem:" + ex);
            }

        }

        public static void LoadTestLogGrid(WimsGridView grid, bool isResult, Project project)
        {
            try
            {
                grid.Rows.Clear();
                if (project == null)
                {
                    logger.Info("FormHelper LoadTestLogGrid  project is null");
                    return;
                }
                foreach (TestCase t in project.CaseList)
                {
                    foreach (var inst in t.LogList)
                    {
                        int index = grid.Rows.Add();
                        grid.Rows[index].Cells[0].Value = inst.Author;
                        grid.Rows[index].Cells[1].Value = inst.Content;
                        grid.Rows[index].Cells[2].Value = inst.Level;
                        grid.Rows[index].Cells[3].Value = inst.CreateTime;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info("FormHelper LoadTask2Grid is problem:" + ex);
            }

        }

    }
}
