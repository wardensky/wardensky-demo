using System;
using wardensky.zFileDb;
using wardensky.zUI;

namespace zUITest
{
    public partial class FormModelCrud : FormCrud<Model>
    {
        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormModelCrud()
        {
          
            InitializeComponent();
        }
     
    }
}
