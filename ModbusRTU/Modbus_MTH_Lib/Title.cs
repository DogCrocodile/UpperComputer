using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_MTH_Lib
{
    public partial class Title: UserControl
    {
        public Title()
        {
            InitializeComponent();
            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string titleName = "标题名称";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取标题名称")]
        public string TitleName
        {
            get { return titleName; }
            set
            { 
                titleName = value;
                this.label_title.Text = titleName;
            }
        }

    }
}
