﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace wardensky.zUI
{
    public class UCNew<T> : UCSingleModel<T>
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

        public UCNew()
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
            List<RowEntity> list = GenricReflectToolkit.GenReflectElements<T>(this.Entity, this.ignoreFields);
            this.Init(list);
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