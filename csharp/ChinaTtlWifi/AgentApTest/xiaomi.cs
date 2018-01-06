using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AgentApTest
{
    public partial class xiaomi : Component
    {
        public xiaomi()
        {
            InitializeComponent();
        }

        public xiaomi(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
