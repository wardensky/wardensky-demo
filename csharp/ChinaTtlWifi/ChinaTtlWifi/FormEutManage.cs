using ChinaTtlWifi.Bll;
using ChinaTtlWifi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChinaTtlWifi
{
    public partial class FormEutManage : FormBase
    {
        private EutBll bll = EutBll.GetInst();
        public FormEutManage()
        {
            InitializeComponent();
            this.SetUI();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormEutInfo formEutInfo = new FormEutInfo();
            formEutInfo.ShowDialog();
            if (formEutInfo.DialogResult == DialogResult.OK && formEutInfo.eut != null)
            {
                SetUI(formEutInfo.eut);
            }
        }

        private void SetUI()
        {
            List<Eut> eutList = bll.SelectAll();
            this.myGridView1.LoadData<Eut>(eutList, base.ignoreFields);
        }

        private void SetUI(Eut eut)
        {
            //        this.SetRow(eut);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("是否删除数据?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Eut eut = FindEut();
                if (eut != null)
                {
                    bll.Delete(eut.Id);
                    this.SetUI();
                }
            }

        }

        private Eut FindEut()
        {
            Eut eut = bll.SelectAll().Where(p => p.Model == this.myGridView1.SelectedRows[0].Cells[1].Value.ToString() && p.Producer == this.myGridView1.SelectedRows[0].Cells[2].Value.ToString()).FirstOrDefault();
            return eut;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Eut eut = FindEut();
            FormEutInfo formEutInfo = new FormEutInfo(eut);
            formEutInfo.ShowDialog();
            if (formEutInfo.DialogResult == DialogResult.OK)
            {
                SetUI();
            }
        }
    }
}
