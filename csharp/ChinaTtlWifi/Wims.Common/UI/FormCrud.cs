using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Wims.Common.Entity;
using Wims.Common.MongoDBUtil;
namespace Wims.Common.UI
{
    public abstract class FormCrud<T> : FormBase where T : BaseEntity
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected Wims.Common.UI.WimsToolStrip myToolStrip1;
        protected Wims.Common.UI.WimsGridView myGridView1;
        protected System.ComponentModel.IContainer components = null;
        protected UCSearch<T> ucSearch;
        public static MongoUtil<T> bll = new MongoUtil<T>(GlobalValues.MONGO_URL);
        protected FormBaseNew<T> formNew;
        public Action<object, EventArgs> ActionClickCustom1 { get; set; }

        public string TextCustom1 { get; set; }
        public bool ShowCustom1 { get; set; }
        public T SelectEntity { get; set; }
        public Type EnumType { get; set; }
        public string OrderProperty { get; set; }

        private bool showSelect = false;

        public bool ShowSelect
        {
            get { return showSelect; }
            set { showSelect = value; }
        }


        private bool showDelete = true;

        public bool ShowDelete
        {
            get { return showDelete; }
            set { showDelete = value; }
        }

        private bool showAdd = true;

        public bool ShowAdd
        {
            get { return showAdd; }
            set { showAdd = value; }
        }
        private bool showModify = true;

        public bool ShowModify
        {
            get { return showModify; }
            set { showModify = value; }
        }

        public FormCrud()
        {
            this.Width = 1024;
            this.Height = 633;

        }
        protected virtual void LoadData()
        {
            List<T> dataList = new List<T>();
            if (string.IsNullOrEmpty(this.OrderProperty))
            {
                dataList = bll.SelectAll();
            }
            else
            {
                dataList = bll.SelectAll().AsQueryable().OrderBy(this.OrderProperty).ToList();
            }
            this.myGridView1.LoadData(dataList, base.ignoreFields);
        }


        protected void Search(Expression<Func<T, bool>> expr)
        {
            var data = bll.SelectAll().AsQueryable().Where(expr).ToList();
            this.myGridView1.LoadData(data, base.ignoreFields);
        }
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.myToolStrip1 = new Wims.Common.UI.WimsToolStrip(this.components);
            this.myGridView1 = new Wims.Common.UI.WimsGridView(this.components);

            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.myToolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.myGridView1, 0, 2);

            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1360, 867);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // myToolStrip1
            // 
            this.myToolStrip1.ActionClickAdd = null;
            this.myToolStrip1.ActionClickDelete = null;
            this.myToolStrip1.ActionClickModify = null;
            this.myToolStrip1.ActionClickSelect = null;
            this.myToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.myToolStrip1.Name = "myToolStrip1";
            this.myToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.myToolStrip1.ShowAdd = true;
            this.myToolStrip1.ShowModify = true;
            this.myToolStrip1.ShowSelect = false;
            this.myToolStrip1.Size = new System.Drawing.Size(1360, 58);
            this.myToolStrip1.TabIndex = 0;
            this.myToolStrip1.Text = "myToolStrip1";
            // 
            // myGridView1
            // 6
            this.myGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGridView1.Location = new System.Drawing.Point(6, 64);
            this.myGridView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.myGridView1.Name = "myGridView1";
            this.myGridView1.RowTemplate.Height = 23;
            this.myGridView1.Size = new System.Drawing.Size(388, 67);
            this.myGridView1.TabIndex = 1;



            // 
            // FormProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 867);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Name = "FormProject";
            this.Text = "管理";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ucSearch = new UCSearch<T>();
            this.ucSearch.EnumType = this.EnumType;
            this.ucSearch.ActionSearch = this.Search;
            this.tableLayoutPanel1.Controls.Add(this.ucSearch, 0, 1);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        protected virtual void Form_Load(object sender, EventArgs e)
        {
            this.Width = 1024;
            this.Height = 633;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.myToolStrip1.ActionClickAdd = this.ClickAdd;
            this.myToolStrip1.ActionClickDelete = this.ClickDelete;
            this.myToolStrip1.ActionClickModify = this.ClickModify;
            this.myToolStrip1.ActionClickSelect = this.ClickSelect;
            //this.myToolStrip1.ActionClickSelect = this.myToolStrip1;
            this.myToolStrip1.ShowAdd = this.ShowAdd;
            this.myToolStrip1.ShowModify = this.ShowModify;
            this.myToolStrip1.ShowDelete = this.ShowDelete;
            this.myToolStrip1.ShowSelect = this.ShowSelect;
            this.myToolStrip1.ShowCustom1 = this.ShowCustom1;
            this.myToolStrip1.ActionClickCustom1 = this.ActionClickCustom1;
            this.myToolStrip1.AddEvent();
            this.LoadData();

        }



        protected virtual void ClickModify(object arg1, EventArgs arg2)
        {
            try
            {
                if (this.formNew != null)
                {
                    this.formNew.Entity = this.myGridView1.FindFirstSelect<T>();
                    this.formNew.ShowDialog();
                    this.LoadData();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex + "");
                return;
            }
        }

        protected virtual void ClickAdd(object arg1, EventArgs arg2)
        {
            if (this.formNew != null)
            {
                this.formNew.Entity = null;
                this.formNew.ShowDialog();
                this.LoadData();
            }
        }

        protected virtual void ClickSelect(object arg1, EventArgs arg2)
        {
            this.SelectEntity = this.myGridView1.FindFirstSelect<T>();
            this.Close();
        }

        protected virtual void ClickDelete(object arg1, EventArgs arg2)
        {
            T entity = this.myGridView1.FindFirstSelect<T>();
            if (entity != null)
            {
                if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    bll.Dao.Delete(entity);
                    this.myGridView1.LoadData(bll.SelectAll(), base.ignoreFields);
                }
            }
        }
    }
}
