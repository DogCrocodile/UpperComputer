using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_MTH_Lib
{
    public partial class THMControl : UserControl
    {
        public THMControl()
        {
            InitializeComponent();
        }

        private string title = "1#站点";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
