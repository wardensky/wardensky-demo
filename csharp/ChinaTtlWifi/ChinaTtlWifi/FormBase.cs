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
    public partial class FormBase : Form
    {
        public List<string> ignoreFields = new List<string>() { "RE1", "RE2", "Id", "id", "MongoId" };
        public FormBase()
        {
            InitializeComponent();
        }
    }
}
