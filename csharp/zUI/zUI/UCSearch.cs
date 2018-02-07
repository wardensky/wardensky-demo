
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
namespace wardensky.zUI
{
    public partial class UCSearch<T> : UserControl 
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(94, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnSearchClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 21);
            this.textBox1.TabIndex = 0;
            //
            // combobox2
            //
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Location = new System.Drawing.Point(this.textBox1.Location.X, this.textBox1.Location.Y);
            comboBox2.Size = new System.Drawing.Size(this.textBox1.Size.Width, this.textBox1.Size.Width);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 1);

            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 48);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // UCSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCSearch";
            this.Size = new System.Drawing.Size(550, 48);
            this.Load += new System.EventHandler(this.UCSearch_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Action<Expression<Func<T, bool>>> ActionSearch { get; set; }
        private class ComboEntity
        {
            public string Name { get; set; }
            public string Desc { get; set; }
        }
        public List<string> ignoreFields = new List<string>() { "RE1", "RE2", "Id", "id", "MongoId" };

        public Type EnumType { get; set; }
        public UCSearch()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        private void BtnSearchClick(object sender, EventArgs e)
        {
            ComboEntity combo = this.comboBox1.SelectedItem as ComboEntity;
            string name = combo.Name;
            ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
            Type type = Expression.Property(parameter, name).Type;
            Expression left = null;
            Expression p1 = Expression.Property(parameter, name);
            if (type.IsEnum)
            {
                string content = this.comboBox2.SelectedValue.ToString();
                var p3 = Expression.Constant(Enum.Parse(EnumType, content), EnumType);
                left = Expression.Equal(p1, p3);
            }
            else
            {
                string content = this.textBox1.Text.Trim();
                left = Expression.Call(p1, typeof(string).GetMethod("Contains"), Expression.Constant(content));
            }
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(left, parameter);
            if (this.ActionSearch != null)
            {
                this.ActionSearch(lambda);
            }
        }
        private void Init()
        {
            List<ComboEntity> list = new List<ComboEntity>();
            Type type = typeof(T);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (ignoreFields.Contains(pi.Name))
                {
                    continue;
                }
                //if (!pi.PropertyType.Equals(typeof(string)))
                //{
                //    continue;
                //}
                object[] objs = pi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                string descName = objs.Length > 0 ? ((DescriptionAttribute)objs[0]).Description : pi.Name;
                ComboEntity entity = new ComboEntity();
                entity.Desc = descName;
                entity.Name = pi.Name;
                list.Add(entity);
            }
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.DataSource = null;
            this.comboBox1.DataSource = list;
            this.comboBox1.DisplayMember = "Desc";
        }
        private void UCSearch_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboEntity combo = this.comboBox1.SelectedItem as ComboEntity;
            string name = combo.Name;
            Type type = typeof(T).GetProperty(name).PropertyType;
            if (type.IsEnum)
            {
                this.tableLayoutPanel1.Controls.Remove(this.textBox1);
                this.comboBox2.DataSource = Enum.GetNames(type).Select(s => { return (object)s; }).ToList();
                this.tableLayoutPanel1.Controls.Add(comboBox2, 1, 1);
            }
            else
            {
                this.tableLayoutPanel1.Controls.Remove(this.comboBox2);
                this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            }
        }
    }
}