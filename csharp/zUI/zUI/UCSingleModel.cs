using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wardensky.zUI
{
    public class UCSingleModel<T> : UserControl
    {
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public List<string> ignoreFields = new List<string>() { "RE1", "RE2", "Id", "id", "MongoId" };
        //public Dictionary<string, List<object>> comboList { get; set; }



        public T Entity { get; set; }

     
    }
}
