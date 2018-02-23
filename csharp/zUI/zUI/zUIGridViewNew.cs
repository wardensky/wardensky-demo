using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace wardensky.zUI
{
    public partial class zUIGridViewNew : System.Windows.Forms.DataGridView
    {
        public zUIGridViewNew()
        {
            InitializeComponent();
        }

        public zUIGridViewNew(IContainer container)
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
            if (dataList == null || dataList.Count == 0)
            {
                return;
            }

            this.DataSource = null;
            this.DataSource = dataList;

            Dictionary<string, string> dic = GetProperties<T>(dataList.First());
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
            return default(T);
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
