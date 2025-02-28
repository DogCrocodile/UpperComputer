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
    public partial class DialPlate : UserControl
    {
        public DialPlate()
        {
            InitializeComponent();
            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region 外环设计
        private Color _alarmColor = Color.FromArgb(36,184,196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取报警颜色")]
        public Color AlarmColor
        {
            get { return _alarmColor; }
            set 
            {
                _alarmColor = value;
                this.Invalidate();
            }
        }

        private Color _ringColor = Color.FromArgb(187, 187, 187);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取圆环整体颜色")]
        public Color RingColor
        {
            get { return _ringColor; }
            set
            {
                _ringColor = value;
                this.Invalidate();
            }
        }

        private float _alarmAngle = 120.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取报警角度")]
        public float AlarmAngle
        {
            get { return _alarmAngle; }
            set
            {
                _alarmAngle = value;
                this.Invalidate();
            }
        }

        private int _outThinkness = 8;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取外环宽度")]
        public int OutThinkness
        {
            get { return _outThinkness; }
            set
            {
                _outThinkness = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 内环设计
        private float _tempScale = 0.65f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取温度环比例，默认低于1.0")]
        public float TempScale
        {
            get { return _tempScale; }
            set
            {
                if (value > 1.0f) return;
                _tempScale = value;
                this.Invalidate();
            }
        }

        private Color _tempColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取温度环颜色")]
        public Color TempColor
        {
            get { return _tempColor; }
            set
            {
                _tempColor = value;
                this.Invalidate();
            }
        }

        private float _humidityScale = 0.35f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取湿度环比例，默认低于1.0")]
        public float HumidityScale
        {
            get { return _humidityScale; }
            set
            {
                if (value > 1.0f) return;
                _humidityScale = value;
                this.Invalidate();
            }
        }

        private Color _humidityColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取湿度环颜色")]
        public Color HumidityColor
        {
            get { return _humidityColor; }
            set
            {
                _humidityColor = value;
                this.Invalidate();
            }
        }

        private int _inThinkness = 16;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取内环宽度")]
        public int InThinkness
        {
            get { return _inThinkness; }
            set
            {
                _inThinkness = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 刻度环设计
        private float _textScale = 0.85f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取刻度环比例，默认低于1.0")]
        public float TextScale
        {
            get { return _textScale; }
            set
            {
                if (value > 1.0f) return;
                _textScale = value;
                this.Invalidate();
            }
        }

        private float _rangeMin = 0.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取量程低限")]
        public float RangeMin
        {
            get { return _rangeMin; }
            set
            {
                if (value > _rangeMax) return;
                _rangeMin = value;
                this.Invalidate();
            }
        }

        private float _rangeMax = 90.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取量程高限")]
        public float RangeMax
        {
            get { return _rangeMax; }
            set
            {
                if (value < _rangeMin) return;
                _rangeMax = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 实时值
        private float _temp = 10.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取温度实时值")]
        public float Temp
        {
            get { return _temp; }
            set
            {
                if (value < _rangeMin)
                {
                    value = _rangeMin;
                }
                if (value > _rangeMax)
                {
                    value = _rangeMax;
                }
                _temp = value;
                this.Invalidate();
            }
        }

        private float _humidity = 10.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取湿度实时值")]
        public float Humidity
        {
            get { return _humidity; }
            set
            {
                if (value < _rangeMin)
                {
                    value = _rangeMin;
                }
                if (value > _rangeMax)
                {
                    value = _rangeMax;
                }
                _humidity = value;
                this.Invalidate();
            }
        }
        #endregion

        private StringFormat stringFormat = new StringFormat();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            //异常情况处理
            if (this.Width <= 20 || this.Height <= 20) return;
            if (this.Height < this.Width / 2) return;

            //画外环
            Pen pen = new Pen(_alarmColor, _outThinkness);
            graphics.DrawArc(pen, new RectangleF(10, 10, this.Width - 20, this.Width - 20), 180, _alarmAngle);

            pen = new Pen(_ringColor, OutThinkness);
            graphics.DrawArc(pen, new RectangleF(10, 10, this.Width - 20, this.Width - 20), 180 + _alarmAngle, 180 - _alarmAngle);

            //转移坐标系
            graphics.TranslateTransform(this.Width * 0.5f, this.Width * 0.5f);

            //旋转坐标系
            graphics.RotateTransform(-90);

            SolidBrush solidBrush;
            for (int i = 0; i < 7; i++)
            {
                if (30 * i <= _alarmAngle)
                {
                    solidBrush = new SolidBrush(_alarmColor);
                }
                else
                {
                    solidBrush = new SolidBrush(_ringColor);
                }
                float x = -3.0f;
                float width = 6.0f;
                float height = _outThinkness + 4;
                float y = (this.Width * 0.5f - 10 + height * 0.5f) * (-1.0f);

                graphics.FillRectangle(solidBrush, new RectangleF(x, y, width, height));

                graphics.RotateTransform(30);
            }

            //坐标系旋转回去
            graphics.RotateTransform(-210);
            graphics.RotateTransform(90);

            //绘制刻度
            float rangeAvg = ((_rangeMax - _rangeMin) % 6 == 0) ? Convert.ToSingle((_rangeMax - _rangeMin) / 6) : Convert.ToSingle(((_rangeMax - _rangeMin) / 6).ToString("f1"));

            for (int i = 0; i < 7; i++)
            {
                float angle = -180f + i * 30.0f;
                float pointX = Convert.ToSingle(this.Width * _textScale * 0.5f * Math.Cos(angle * Math.PI / 180.0f));
                float pointY = Convert.ToSingle(this.Width * _textScale * 0.5f * Math.Sin(angle * Math.PI / 180.0f));

                string text = (_rangeMin + rangeAvg * i).ToString();

                SizeF size = graphics.MeasureString(text, this.Font);
                RectangleF rectangle = new RectangleF(pointX - size.Width * 0.5f, pointY, size.Width, size.Height);

                graphics.DrawString(text, this.Font, new SolidBrush(this.ForeColor), rectangle, stringFormat);

            }

            //绘制实际温度湿度环
            pen = new Pen(_tempColor, _inThinkness);

            float sweepAngle = (_temp - _rangeMin) / (_rangeMax - _rangeMin) * 180.0f;

            float xx = this.Width * _tempScale * 0.5f * (-1.0f);
            float yy = this.Width * _tempScale * 0.5f * (-1.0f);

            graphics.DrawArc(pen, new RectangleF(xx, yy, this.Width * _tempScale, this.Width * _tempScale), -180.0f, sweepAngle);


            pen = new Pen(_humidityColor, _inThinkness);

            sweepAngle = (_humidity - _rangeMin) / (_rangeMax - _rangeMin) * 180.0f;

            xx = this.Width * _humidityScale * 0.5f * (-1.0f);
            yy = this.Width * _humidityScale * 0.5f * (-1.0f);

            graphics.DrawArc(pen, new RectangleF(xx, yy, this.Width * _humidityScale, this.Width * _humidityScale), -180.0f, sweepAngle);
        }
    }
}
