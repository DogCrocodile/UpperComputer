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
    [DefaultEvent("ControlDoubleClick")]
    public partial class TextSetEx : UserControl
    {
        public TextSetEx()
        {
            InitializeComponent();

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string titleName = "1#站点温度的高限";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示标题名称")]
        public string TitleName
        {
            get { return titleName; }
            set
            {
                titleName = value; 
                this.lbl_Title.Text = titleName;
            }
        }

        private string unit = "C";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示单位名称")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.lbl_Unit.Text = unit;
            }
        }

        private float currentValue = 0.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示当前数值")]
        public float CurrentValue
        {
            get 
            {
                currentValue = Convert.ToSingle(this.num_Value.Value);
                return currentValue;
            }
            set
            {
                currentValue = value;
                this.num_Value.Value = Convert.ToDecimal(currentValue);           
            }
        }
    }
}
