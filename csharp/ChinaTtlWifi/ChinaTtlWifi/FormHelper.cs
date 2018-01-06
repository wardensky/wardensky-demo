using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public static class FormHelper
    {
        private static TaskBll taskBll = TaskBll.GetInst();
        public static void LoadTask2Grid(MyGridView grid, bool isResult)
        {
            List<Task> taskList = taskBll.SelectAll();
            grid.Rows.Clear();
            foreach (Task t in taskList)
            {
                int index = grid.Rows.Add();
                grid.Rows[index].Cells[0].Value = t.Name;
                grid.Rows[index].Cells[1].Value = t.EutModel;
                grid.Rows[index].Cells[2].Value = t.ScriptName;
                if (isResult == false)
                {
                    grid.Rows[index].Cells[3].Value = t.Desc;
                    grid.Rows[index].Cells[4].Value = t.CreateTime;
                    grid.Rows[index].Cells[5].Value = t.Status;
                }
            }
        }


        public static void InitTaskGrid(MyGridView grid, bool isResult)
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "任务名称";
            c1.HeaderText = "任务名称";
            grid.Columns.Add(c1);
            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "被测型号";
            c2.HeaderText = "被测型号";
            grid.Columns.Add(c2);
            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "脚本名称";
            c3.HeaderText = "脚本名称";
            grid.Columns.Add(c3);
            if (isResult == false)
            {
                DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
                c4.Name = "任务描述";
                c4.HeaderText = "任务描述";
                grid.Columns.Add(c4);

                DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
                c5.Name = "创建时间";
                c5.HeaderText = "创建时间";
                grid.Columns.Add(c5);

                DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
                c6.Name = "任务状态";
                c6.HeaderText = "任务状态";
                grid.Columns.Add(c6);
            }
        }

    }
}
