using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Wims.Common.Entity;
namespace Wims.Common.UI
{
    public partial class UCBaseNew<T> : UserControl where T : BaseEntity
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 388);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UCBaseNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCBaseNew";
            this.Size = new System.Drawing.Size(408, 388);
            this.ResumeLayout(false);
        }
        #endregion
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public List<string> ignoreFields = new List<string>() { "RE1", "RE2", "Id", "id", "MongoId" };
        //public Dictionary<string, List<object>> comboList { get; set; }



        public T Entity { get; set; }
        public UCBaseNew()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public bool ReadUI()
        {
            List<RowEntity> list = new List<RowEntity>();
            if (this.Entity == null)
            {
                this.Entity = System.Activator.CreateInstance<T>();
            }
            foreach (Control control in this.tableLayoutPanel1.Controls)
            {
                if (control is UCRowTextBox)
                {
                    UCRowTextBox uc = control as UCRowTextBox;
                    RowEntity entity = uc.GetRow();
                    if (entity == null)
                    {
                        return false;
                    }
                    list.Add(entity);
                }
                else if (control is UCRowComboBox)
                {
                    UCRowComboBox uc = control as UCRowComboBox;
                    RowEntity entity = uc.GetRow();
                    if (entity == null)
                    {
                        return false;
                    }
                    list.Add(entity);
                }
                else if (control is UCRowDateTime)
                {
                    UCRowDateTime uc = control as UCRowDateTime;
                    RowEntity entity = uc.GetRow();
                    if (entity == null)
                    {
                        return false;
                    }
                    list.Add(entity);
                }
            }
            Type type = typeof(T);
            foreach (RowEntity inst in list)
            {
                foreach (PropertyInfo pi in type.GetProperties())
                {
                    if (this.ignoreFields.Contains(pi.Name))
                    {
                        continue;
                    }
                    if (inst.Key == pi.Name)
                    {
                        if (inst.DataType.IsEnum)
                        {
                            Type t = inst.DataType;
                            pi.SetValue(this.Entity, (int)(Enum.Parse(t, inst.Value.ToString())), null);
                        }
                        else
                        {
                            pi.SetValue(this.Entity, inst.Value, null);
                        }
                        break;
                    }
                }
            }
            return true;
        }
        private void LoadUI()
        {
            if (this.Entity == null)
            {
                return;
            }
        }
        public void Init()
        {
            List<RowEntity> list = GenReflectElements();
            this.Init(list);
        }
        public List<RowEntity> GenReflectElements()
        {
            List<RowEntity> list = new List<RowEntity>();
            if (this.Entity == null)
            {
                this.Entity = System.Activator.CreateInstance<T>();
            }
            int index = 1;
            Type type = typeof(T);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (this.ignoreFields.Contains(pi.Name))
                {
                    continue;
                }
                RowEntity row = new RowEntity();
                list.Add(row);
                object[] objs = pi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                string descName = objs.Length > 0 ? ((DescriptionAttribute)objs[0]).Description : pi.Name;
                row.Key = pi.Name;
                row.Name = descName;
                row.Value = pi.GetValue(this.Entity, null) ?? string.Empty;
                row.Index = index++;
                row.Type = ControlType.TEXT_BOX;
                if (pi.PropertyType == typeof(DateTime))
                {
                    row.Type = ControlType.DATE_TIME;
                }
                row.DataType = pi.PropertyType;

            }
            return list;
        }
        public void Init(List<RowEntity> list)
        {
            this.Init(list, null);
        }
        public void Init(List<RowEntity> list, Dictionary<string, List<object>> comboList)
        {
            this.Init(list, comboList, null);
        }

        public void Init(List<RowEntity> list, Dictionary<string, List<object>> comboList, Dictionary<string, Action<object, EventArgs>> actionList)
        {
            if (list == null)
            {
                list = new List<RowEntity>();
            }
            if (comboList == null)
            {
                comboList = new Dictionary<string, List<object>>();
            }
            if (actionList == null)
            {
                actionList = new Dictionary<string, Action<object, EventArgs>>();
            }
            float f = 100F / list.Count;
            this.tableLayoutPanel1.RowStyles[0].Height = f;
            this.tableLayoutPanel1.RowCount = list.Count;
            int j = 0;
            for (int i = 1; i < list.Count; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, f));
            }
            foreach (RowEntity inst in list)
            {
                if (inst.Type == ControlType.TEXT_BOX)
                {
                    UCRowTextBox row = new UCRowTextBox(inst);
                    this.tableLayoutPanel1.Controls.Add(row, 0, j++);
                }
                else if (inst.Type == ControlType.COMBO_BOX)
                {
                    if (comboList.ContainsKey(inst.Key))
                    {
                        UCRowComboBox row = new UCRowComboBox(inst, comboList[inst.Key]);
                        if (actionList.ContainsKey(inst.Key))
                        {
                            row.SelectChanged = actionList[inst.Key];
                        }
                        this.tableLayoutPanel1.Controls.Add(row, 0, j++);
                    }
                }
                else if (inst.Type == ControlType.DATE_TIME)
                {
                    UCRowDateTime row = new UCRowDateTime(inst);
                    this.tableLayoutPanel1.Controls.Add(row, 0, j++);
                }
            }
        }
    }
}