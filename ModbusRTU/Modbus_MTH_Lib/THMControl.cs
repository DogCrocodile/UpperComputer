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
            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string title = "1#站点";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示标题名称")]
        public string Title
        {
            get { return title; }
            set 
            { 
                title = value;
                lbl_Title.Text = title;
            }
        }

        private string _temp = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示温度值")]
        public string Temp
        {
            get { return _temp; }
            set 
            {
                if (_temp != value)
                {
                    _temp = value;
                    this.lbl_Temp.Text = _temp;
                    if (float.TryParse(_temp, out float val))
                    {
                        this.dialPlate.Temp = val;
                    }
                    else
                    {
                        this.dialPlate.Temp = 0.0f;
                    }
                }

            }
        }

        private string _humidity = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示湿度值")]
        public string Humidity
        {
            get { return _humidity; }
            set 
            {
                if(_humidity != value)
                {
                    _humidity = value;
                    this.lbl_Humidity.Text = _humidity;
                    if(float.TryParse(_humidity, out float val))
                    {
                        this.dialPlate.Humidity = val;
                    }
                    else
                    {
                        this.dialPlate.Humidity = 0.0f;
                    }
                }
            }
        }

        private bool _moduleError = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示状态异常")]
        public bool ModuleError
        {
            get { return _moduleError; }
            set 
            { 
                _moduleError = value;
                lbl_Title.BackColor = _moduleError ? Color.Red : Color.FromArgb(36, 184, 196);
            }
        }

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示温度绑定变量名称")]
        public string TempVarName { get; set; } = string.Empty;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示湿度绑定变量名称")]
        public string HumidityVarName { get; set; } = string.Empty;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示状态绑定变量名称")]
        public string StateVarName { get; set; } = string.Empty;
    }
}
