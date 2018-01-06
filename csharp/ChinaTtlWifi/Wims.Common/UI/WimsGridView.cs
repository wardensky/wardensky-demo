using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
namespace Wims.Common.UI
{
    public partial class WimsGridView : System.Windows.Forms.DataGridView
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
            components = new System.ComponentModel.Container();
        }
        #endregion
        public WimsGridView()
        {
            InitializeComponent();
        }
        public WimsGridView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.RowTemplate.Height = 23;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoGenerateColumns = true;
        }

        public void LoadData<T>(IList<T> dataList, List<string> hidePros)
        {
            if (dataList == null)
            {
                return;
            }
            this.DataSource = null;
            this.DataSource = dataList;
            T t = System.Activator.CreateInstance<T>();
            if (dataList.Count > 0)
            {
                t = dataList.First();
            }
            Dictionary<string, string> dic = GetProperties<T>(t);
            foreach (string key in dic.Keys)
            {
                if (this.Columns[key] != null)
                {
                    this.Columns[key].HeaderText = dic[key];
                }
            }
            foreach (string inst in hidePros)
            {
                if (dic.Keys.Contains(inst))
                {
                    if (this.Columns[inst] != null)
                    {
                        this.Columns[inst].Visible = false;
                    }
                }
            }
        }
        public T FindFirstSelect<T>()
        {
            if (this.SelectedRows.Count > 0)
            {
                return (T)this.SelectedRows[0].DataBoundItem;
            }
            return System.Activator.CreateInstance<T>();
        }
        public Dictionary<string, string> GetProperties<T>(T t)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string tStr = string.Empty;
            if (t == null)
            {
                return ret;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (properties.Length <= 0)
            {
                return ret;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                string des = name;
                object value = item.GetValue(t, null);
                var attr = ((DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute)));
                if (attr != null)
                {
                    des = attr.Description;
                }
                ret.Add(name, des);
            }
            return ret;
        }
    }
}