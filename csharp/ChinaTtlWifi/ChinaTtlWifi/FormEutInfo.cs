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
    public partial class FormEutInfo : FormBase
    {
        private EutBll bll = EutBll.GetInst();
        public Eut eut { get; set; }
        public FormEutInfo()
        {
            InitializeComponent();

        }
        public FormEutInfo(Eut entity)
        {
            InitializeComponent();
            this.SetUI(entity);
            this.eut = entity;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.eut != null)
            {
                SetEut(this.eut);
                bll.UpdateById(this.eut);
            }
            else
            {
                this.eut = new Eut();
                eut.Id = Guid.NewGuid().ToString();
                SetEut(this.eut);
                bll.Insert(this.eut);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetEut(Eut entity)
        {
            entity.Model = this.txtModel.Text.Trim();
            entity.Name = this.txtName.Text.Trim();
            entity.Producer = this.txtProducer.Text.Trim();
            entity.Contract = this.txtContract.Text.Trim();
            entity.Mobile = this.txtMobile.Text.Trim();
            entity.Address = this.txtAddress.Text.Trim();
        }
        private void SetUI(Eut entity)
        {

            this.txtModel.Text = entity.Model;
            this.txtName.Text = entity.Name;
            this.txtProducer.Text = entity.Producer;
            this.txtContract.Text = entity.Contract;
            this.txtMobile.Text = entity.Mobile;
            this.txtAddress.Text = entity.Address;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
