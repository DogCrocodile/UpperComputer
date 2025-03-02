using Modbus_MTH_Lib;
using MTHProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_MTH
{
    public partial class FormMointor: Form
    {
        public FormMointor()
        {
            InitializeComponent();
            this.lst_Info.Columns[1].Width = this.lst_Info.Width - this.lst_Info.Columns[0].Width - 25;

            SetChart();

            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += UpdateTimer_Tick;
            this.updateTimer.Start();

            this.FormClosing += (sender, e) =>
            {
                this.updateTimer.Stop();
            };
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.MainPanel.Controls.OfType<THMControl>())
                {
                    UpdateTHMControl(item);
                }

                List<double> ydata = new List<double>();
                for (int i = 1; i <= 6; i++)
                {
                    ydata.Add(Convert.ToDouble(CommonMethods.Device[$"模块{i}温度"]));
                    ydata.Add(Convert.ToDouble(CommonMethods.Device[$"模块{i}湿度"]));
                }
                this.chart_ActuralTrend.PlotSingle(ydata.ToArray());
            }
        }

        private void UpdateTHMControl(THMControl tHMControl)
        {
            if (CommonMethods.Device[tHMControl.TempVarName] != null)
            {
                tHMControl.Temp = CommonMethods.Device[tHMControl.TempVarName].ToString();
            }

            if (CommonMethods.Device[tHMControl.HumidityVarName] != null)
            {
                tHMControl.Humidity = CommonMethods.Device[tHMControl.HumidityVarName].ToString();
            }

            if (CommonMethods.Device[tHMControl.StateVarName] != null)
            {
                tHMControl.ModuleError = CommonMethods.Device[tHMControl.StateVarName].ToString() == "True";
            }
        }

        private Timer updateTimer = new Timer();

        private string CurrentTime
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 实现通用日志记录的方法
        /// </summary>
        /// <param name="level"></param>
        /// <param name="log"></param>
        public void AddLog(int level, string log)
        {
            if (level > 2)
            {
                level = 2;
            }
            if (level < 0)
            {
                level = 0;
            }

            if (this.lst_Info.InvokeRequired)
            {
                this.lst_Info.Invoke(new Action<int, string>(AddLog), level, log);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem("  " + CurrentTime, level);
                listViewItem.SubItems.Add(log);

                this.lst_Info.Items.Add(listViewItem);

                //让最新的日志显示在最下面
                this.lst_Info.Items[this.lst_Info.Items.Count - 1].EnsureVisible();

            }
        }

        private void SetChart()
        {
            //设置x轴数据类型及格式
            this.chart_ActuralTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.chart_ActuralTrend.TimeStampFormat = "HH:mm:ss";
            //设置图例
            this.chart_ActuralTrend.LegendVisible = true;
            //设置显示数据点
            this.chart_ActuralTrend.DisplayPoints = 4000;
            //Y轴范围
            this.chart_ActuralTrend.AxisY.Minimum = 0.0f;
            this.chart_ActuralTrend.AxisY.Maximum = 100.0f;
            this.chart_ActuralTrend.AxisY.AutoScale = false;
            //清除曲线
            this.chart_ActuralTrend.Series.Clear();
            //设置曲线数量
            this.chart_ActuralTrend.SeriesCount = 12;
            //设置曲线
            for (int i = 0; i < 12; i++)
            {
                //设置曲线名称
                this.chart_ActuralTrend.Series[i].Name = i % 2 == 0 ? $"{i / 2 + 1}#站点温度" : $"{i / 2 + 1}#站点湿度";
                //设置曲线不可见
                this.chart_ActuralTrend.Series[i].Visible = false;
                //设置曲线的粗细
                this.chart_ActuralTrend.Series[i].Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                //设置曲线的Y轴
                this.chart_ActuralTrend.Series[i].YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            }
            this.chk_Temp1.Checked = true;
            this.chk_Humidity1.Checked = true;
        }

        private void chk_Common_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBoxEx checkBox)
            {
                if (checkBox.Tag != null && checkBox.Tag.ToString().Length > 0)
                {
                    int index = Convert.ToInt32(checkBox.Tag.ToString());

                    this.chart_ActuralTrend.Series[index].Visible = checkBox.Checked;
                }
            }
        }
    }
}
