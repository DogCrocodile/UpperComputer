using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_MTH_Lib
{
    public partial class PanelEx: Panel
    {    
        public PanelEx()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private int _topGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示上方间隔")]
        public int TopGap
        {
            get { return _topGap; }
            set 
            { 
                _topGap = value; 
                this.Invalidate(); 
            }
        }

        private int _bottomGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示下方间隔")]
        public int BottomGap
        {
            get { return _bottomGap; }
            set 
            { 
                _bottomGap = value; 
                this.Invalidate(); 
            }
        }

        private int _leftGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示左边间隔")]
        public int LeftGap
        {
            get { return _leftGap; }
            set 
            { 
                _leftGap = value; 
                this.Invalidate(); 
            }
        }

        private int _rightGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示右边间隔")]
        public int RightGap
        {
            get { return _rightGap; }
            set 
            { 
                _rightGap = value; 
                this.Invalidate(); 
            }
        }

        private int _borderWidth = 2;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示边框宽度")]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set 
            { 
                _borderWidth = value; 
                this.Invalidate(); 
            }
        }

        private Color _borderColor = Color.FromArgb(35,255,253);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示边框颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set 
            { 
                _borderColor = value; 
                this.Invalidate(); //每次修改后立刻生效
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //准备画布
            Graphics graphics = e.Graphics;
            //准备笔
            Pen pen = new Pen(_borderColor, _borderWidth);
            //参数
            float x = _leftGap + BorderWidth * 0.5f;
            float y = _rightGap + BorderWidth * 0.5f;
            float width = this.Width - _leftGap - _rightGap - BorderWidth;
            float height = this.Height - _topGap - _bottomGap - BorderWidth;
            //绘制
            graphics.DrawRectangle(pen, x, y, width, height);
        }
    }
}
