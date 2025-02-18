using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;

namespace Modbus_MTH_Lib
{
    [DefaultEvent("Click")]
    public partial class NaviButton: UserControl
    {
        public NaviButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private bool _isSelected;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示导航按钮是否选中")]
        public bool IsSelected
        {
            get { return _isSelected; }
            set 
            { 
                _isSelected = value;
                UpdateImage();
            }
        }


        private bool _isLeft = true;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示导航按钮是否左边")]
        public bool IsLeft
        {
            get { return _isLeft; }
            set 
            { 
                _isLeft = value;
                UpdateImage();
            }
        }

        private string _titleName = "导航按钮";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示导航按钮内容")]
        public string TitleName
        {
            get { return _titleName = "导航按钮"; }
            set 
            { 
                _titleName = value;
                this.lable_titleName.Text = _titleName;
            }
        }


        /// <summary>
        /// 统一更新图片内容
        /// </summary>
        private void UpdateImage()
        {
            if (_isLeft)
            {
                //this.BackgroundImage = this._isSelected ? Properties.Resources. : Properties.Resources.;
            }
            else
            {
                //this.BackgroundImage = this._isSelected ? Properties.Resources. : Properties.Resources.;
            }
        }

        [Browsable(true)]
        [Category("自定义事件")]
        [Description("设置或显示导航按钮内容")]
        public new EventHandler Click;
        private void lable_titleName_Click(object sender, EventArgs e)
        {
            if(this.Click != null)
            {
                this.Click.Invoke(this, e);
            }
        }
    }
}
