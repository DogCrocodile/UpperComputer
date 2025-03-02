namespace Modbus_MTH
{
    partial class FormMointor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries14 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMointor));
            this.chart_ActuralTrend = new SeeSharpTools.JY.GUI.StripChartX();
            this.lst_Info = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chk_Humidity6 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Humidity4 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Temp6 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Humidity2 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Temp4 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Humidity5 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Humidity3 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Temp5 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Temp2 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Temp3 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Humidity1 = new Modbus_MTH_Lib.CheckBoxEx();
            this.chk_Temp1 = new Modbus_MTH_Lib.CheckBoxEx();
            this.title2 = new Modbus_MTH_Lib.Title();
            this.title1 = new Modbus_MTH_Lib.Title();
            this.thmControl6 = new Modbus_MTH_Lib.THMControl();
            this.thmControl4 = new Modbus_MTH_Lib.THMControl();
            this.thmControl2 = new Modbus_MTH_Lib.THMControl();
            this.thmControl5 = new Modbus_MTH_Lib.THMControl();
            this.thmControl3 = new Modbus_MTH_Lib.THMControl();
            this.thmControl1 = new Modbus_MTH_Lib.THMControl();
            this.MainPanel = new Modbus_MTH_Lib.PanelEnhanced();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_ActuralTrend
            // 
            this.chart_ActuralTrend.AxisX.AutoScale = false;
            this.chart_ActuralTrend.AxisX.AutoZoomReset = false;
            this.chart_ActuralTrend.AxisX.Color = System.Drawing.Color.White;
            this.chart_ActuralTrend.AxisX.InitWithScaleView = false;
            this.chart_ActuralTrend.AxisX.IsLogarithmic = false;
            this.chart_ActuralTrend.AxisX.LabelAngle = 0;
            this.chart_ActuralTrend.AxisX.LabelEnabled = true;
            this.chart_ActuralTrend.AxisX.LabelFormat = null;
            this.chart_ActuralTrend.AxisX.MajorGridColor = System.Drawing.Color.White;
            this.chart_ActuralTrend.AxisX.MajorGridCount = 4;
            this.chart_ActuralTrend.AxisX.MajorGridEnabled = true;
            this.chart_ActuralTrend.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActuralTrend.AxisX.Maximum = 1000D;
            this.chart_ActuralTrend.AxisX.Minimum = 0D;
            this.chart_ActuralTrend.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisX.MinorGridEnabled = false;
            this.chart_ActuralTrend.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActuralTrend.AxisX.TickWidth = 1F;
            this.chart_ActuralTrend.AxisX.Title = "";
            this.chart_ActuralTrend.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActuralTrend.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActuralTrend.AxisX.ViewMaximum = 1000D;
            this.chart_ActuralTrend.AxisX.ViewMinimum = 0D;
            this.chart_ActuralTrend.AxisX2.AutoScale = false;
            this.chart_ActuralTrend.AxisX2.AutoZoomReset = false;
            this.chart_ActuralTrend.AxisX2.Color = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisX2.InitWithScaleView = false;
            this.chart_ActuralTrend.AxisX2.IsLogarithmic = false;
            this.chart_ActuralTrend.AxisX2.LabelAngle = 0;
            this.chart_ActuralTrend.AxisX2.LabelEnabled = true;
            this.chart_ActuralTrend.AxisX2.LabelFormat = null;
            this.chart_ActuralTrend.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisX2.MajorGridCount = 6;
            this.chart_ActuralTrend.AxisX2.MajorGridEnabled = true;
            this.chart_ActuralTrend.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActuralTrend.AxisX2.Maximum = 1000D;
            this.chart_ActuralTrend.AxisX2.Minimum = 0D;
            this.chart_ActuralTrend.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisX2.MinorGridEnabled = false;
            this.chart_ActuralTrend.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActuralTrend.AxisX2.TickWidth = 1F;
            this.chart_ActuralTrend.AxisX2.Title = "";
            this.chart_ActuralTrend.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActuralTrend.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActuralTrend.AxisX2.ViewMaximum = 1000D;
            this.chart_ActuralTrend.AxisX2.ViewMinimum = 0D;
            this.chart_ActuralTrend.AxisY.AutoScale = true;
            this.chart_ActuralTrend.AxisY.AutoZoomReset = false;
            this.chart_ActuralTrend.AxisY.Color = System.Drawing.Color.White;
            this.chart_ActuralTrend.AxisY.InitWithScaleView = false;
            this.chart_ActuralTrend.AxisY.IsLogarithmic = false;
            this.chart_ActuralTrend.AxisY.LabelAngle = 0;
            this.chart_ActuralTrend.AxisY.LabelEnabled = true;
            this.chart_ActuralTrend.AxisY.LabelFormat = null;
            this.chart_ActuralTrend.AxisY.MajorGridColor = System.Drawing.Color.White;
            this.chart_ActuralTrend.AxisY.MajorGridCount = 6;
            this.chart_ActuralTrend.AxisY.MajorGridEnabled = true;
            this.chart_ActuralTrend.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActuralTrend.AxisY.Maximum = 3.5D;
            this.chart_ActuralTrend.AxisY.Minimum = 0.5D;
            this.chart_ActuralTrend.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisY.MinorGridEnabled = false;
            this.chart_ActuralTrend.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActuralTrend.AxisY.TickWidth = 1F;
            this.chart_ActuralTrend.AxisY.Title = "";
            this.chart_ActuralTrend.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActuralTrend.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActuralTrend.AxisY.ViewMaximum = 3.5D;
            this.chart_ActuralTrend.AxisY.ViewMinimum = 0.5D;
            this.chart_ActuralTrend.AxisY2.AutoScale = true;
            this.chart_ActuralTrend.AxisY2.AutoZoomReset = false;
            this.chart_ActuralTrend.AxisY2.Color = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisY2.InitWithScaleView = false;
            this.chart_ActuralTrend.AxisY2.IsLogarithmic = false;
            this.chart_ActuralTrend.AxisY2.LabelAngle = 0;
            this.chart_ActuralTrend.AxisY2.LabelEnabled = true;
            this.chart_ActuralTrend.AxisY2.LabelFormat = null;
            this.chart_ActuralTrend.AxisY2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisY2.MajorGridCount = 6;
            this.chart_ActuralTrend.AxisY2.MajorGridEnabled = true;
            this.chart_ActuralTrend.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActuralTrend.AxisY2.Maximum = 3.5D;
            this.chart_ActuralTrend.AxisY2.Minimum = 0.5D;
            this.chart_ActuralTrend.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActuralTrend.AxisY2.MinorGridEnabled = false;
            this.chart_ActuralTrend.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActuralTrend.AxisY2.TickWidth = 1F;
            this.chart_ActuralTrend.AxisY2.Title = "";
            this.chart_ActuralTrend.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActuralTrend.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActuralTrend.AxisY2.ViewMaximum = 3.5D;
            this.chart_ActuralTrend.AxisY2.ViewMinimum = 0.5D;
            this.chart_ActuralTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.chart_ActuralTrend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chart_ActuralTrend.ChartAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.chart_ActuralTrend.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.chart_ActuralTrend.DisplayPoints = 4000;
            this.chart_ActuralTrend.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_ActuralTrend.ForeColor = System.Drawing.Color.White;
            this.chart_ActuralTrend.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.chart_ActuralTrend.LegendBackColor = System.Drawing.Color.Transparent;
            this.chart_ActuralTrend.LegendFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_ActuralTrend.LegendForeColor = System.Drawing.Color.White;
            this.chart_ActuralTrend.LegendVisible = true;
            stripChartXSeries14.Color = System.Drawing.Color.Red;
            stripChartXSeries14.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries14.Name = "1#站点的温度";
            stripChartXSeries14.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries14.Visible = true;
            stripChartXSeries14.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries14.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries14.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            this.chart_ActuralTrend.LineSeries.Add(stripChartXSeries14);
            this.chart_ActuralTrend.Location = new System.Drawing.Point(838, 55);
            this.chart_ActuralTrend.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chart_ActuralTrend.Miscellaneous.CheckInfinity = false;
            this.chart_ActuralTrend.Miscellaneous.CheckNaN = false;
            this.chart_ActuralTrend.Miscellaneous.CheckNegtiveOrZero = false;
            this.chart_ActuralTrend.Miscellaneous.DirectionChartCount = 3;
            this.chart_ActuralTrend.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.chart_ActuralTrend.Miscellaneous.MaxSeriesCount = 32;
            this.chart_ActuralTrend.Miscellaneous.MaxSeriesPointCount = 4000;
            this.chart_ActuralTrend.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.chart_ActuralTrend.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.chart_ActuralTrend.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.chart_ActuralTrend.Miscellaneous.SplitViewAutoLayout = true;
            this.chart_ActuralTrend.Name = "chart_ActuralTrend";
            this.chart_ActuralTrend.NextTimeStamp = new System.DateTime(((long)(0)));
            this.chart_ActuralTrend.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.chart_ActuralTrend.SeriesCount = 1;
            this.chart_ActuralTrend.Size = new System.Drawing.Size(578, 393);
            this.chart_ActuralTrend.SplitView = false;
            this.chart_ActuralTrend.StartIndex = 0;
            this.chart_ActuralTrend.TabIndex = 4;
            this.chart_ActuralTrend.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.chart_ActuralTrend.TimeStampFormat = null;
            this.chart_ActuralTrend.XCursor.AutoInterval = true;
            this.chart_ActuralTrend.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActuralTrend.XCursor.Interval = 0.001D;
            this.chart_ActuralTrend.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.chart_ActuralTrend.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActuralTrend.XCursor.Value = double.NaN;
            this.chart_ActuralTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.chart_ActuralTrend.YCursor.AutoInterval = true;
            this.chart_ActuralTrend.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActuralTrend.YCursor.Interval = 0.001D;
            this.chart_ActuralTrend.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.chart_ActuralTrend.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActuralTrend.YCursor.Value = double.NaN;
            // 
            // lst_Info
            // 
            this.lst_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.lst_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lst_Info.ForeColor = System.Drawing.Color.White;
            this.lst_Info.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_Info.HideSelection = false;
            this.lst_Info.Location = new System.Drawing.Point(827, 633);
            this.lst_Info.Name = "lst_Info";
            this.lst_Info.ShowItemToolTips = true;
            this.lst_Info.Size = new System.Drawing.Size(589, 193);
            this.lst_Info.SmallImageList = this.imageList1;
            this.lst_Info.TabIndex = 6;
            this.lst_Info.UseCompatibleStateImageBehavior = false;
            this.lst_Info.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日志时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日志内容";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "info.png");
            this.imageList1.Images.SetKeyName(1, "warning.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
            // 
            // chk_Humidity6
            // 
            this.chk_Humidity6.BackColor = System.Drawing.Color.Transparent;
            this.chk_Humidity6.CheckBackColor = System.Drawing.Color.White;
            this.chk_Humidity6.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity6.DefaultCheckButtonWidth = 20;
            this.chk_Humidity6.ForeColor = System.Drawing.Color.White;
            this.chk_Humidity6.Location = new System.Drawing.Point(1246, 528);
            this.chk_Humidity6.Name = "chk_Humidity6";
            this.chk_Humidity6.Size = new System.Drawing.Size(120, 24);
            this.chk_Humidity6.TabIndex = 5;
            this.chk_Humidity6.Tag = "11";
            this.chk_Humidity6.Text = "6#站点湿度";
            this.chk_Humidity6.UseVisualStyleBackColor = false;
            this.chk_Humidity6.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Humidity4
            // 
            this.chk_Humidity4.BackColor = System.Drawing.Color.Transparent;
            this.chk_Humidity4.CheckBackColor = System.Drawing.Color.White;
            this.chk_Humidity4.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity4.DefaultCheckButtonWidth = 20;
            this.chk_Humidity4.ForeColor = System.Drawing.Color.White;
            this.chk_Humidity4.Location = new System.Drawing.Point(1246, 498);
            this.chk_Humidity4.Name = "chk_Humidity4";
            this.chk_Humidity4.Size = new System.Drawing.Size(120, 24);
            this.chk_Humidity4.TabIndex = 5;
            this.chk_Humidity4.Tag = "7";
            this.chk_Humidity4.Text = "4#站点温度";
            this.chk_Humidity4.UseVisualStyleBackColor = false;
            this.chk_Humidity4.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp6
            // 
            this.chk_Temp6.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp6.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp6.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp6.DefaultCheckButtonWidth = 20;
            this.chk_Temp6.ForeColor = System.Drawing.Color.White;
            this.chk_Temp6.Location = new System.Drawing.Point(1107, 528);
            this.chk_Temp6.Name = "chk_Temp6";
            this.chk_Temp6.Size = new System.Drawing.Size(120, 24);
            this.chk_Temp6.TabIndex = 5;
            this.chk_Temp6.Tag = "10";
            this.chk_Temp6.Text = "6#站点温度";
            this.chk_Temp6.UseVisualStyleBackColor = false;
            this.chk_Temp6.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Humidity2
            // 
            this.chk_Humidity2.BackColor = System.Drawing.Color.Transparent;
            this.chk_Humidity2.CheckBackColor = System.Drawing.Color.White;
            this.chk_Humidity2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity2.DefaultCheckButtonWidth = 20;
            this.chk_Humidity2.ForeColor = System.Drawing.Color.White;
            this.chk_Humidity2.Location = new System.Drawing.Point(1246, 468);
            this.chk_Humidity2.Name = "chk_Humidity2";
            this.chk_Humidity2.Size = new System.Drawing.Size(120, 24);
            this.chk_Humidity2.TabIndex = 5;
            this.chk_Humidity2.Tag = "3";
            this.chk_Humidity2.Text = "2#站点湿度";
            this.chk_Humidity2.UseVisualStyleBackColor = false;
            this.chk_Humidity2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp4
            // 
            this.chk_Temp4.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp4.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp4.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp4.DefaultCheckButtonWidth = 20;
            this.chk_Temp4.ForeColor = System.Drawing.Color.White;
            this.chk_Temp4.Location = new System.Drawing.Point(1107, 498);
            this.chk_Temp4.Name = "chk_Temp4";
            this.chk_Temp4.Size = new System.Drawing.Size(120, 24);
            this.chk_Temp4.TabIndex = 5;
            this.chk_Temp4.Tag = "6";
            this.chk_Temp4.Text = "4#站点温度";
            this.chk_Temp4.UseVisualStyleBackColor = false;
            this.chk_Temp4.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Humidity5
            // 
            this.chk_Humidity5.BackColor = System.Drawing.Color.Transparent;
            this.chk_Humidity5.CheckBackColor = System.Drawing.Color.White;
            this.chk_Humidity5.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity5.DefaultCheckButtonWidth = 20;
            this.chk_Humidity5.ForeColor = System.Drawing.Color.White;
            this.chk_Humidity5.Location = new System.Drawing.Point(980, 528);
            this.chk_Humidity5.Name = "chk_Humidity5";
            this.chk_Humidity5.Size = new System.Drawing.Size(120, 24);
            this.chk_Humidity5.TabIndex = 5;
            this.chk_Humidity5.Tag = "9";
            this.chk_Humidity5.Text = "5#站点湿度";
            this.chk_Humidity5.UseVisualStyleBackColor = false;
            this.chk_Humidity5.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Humidity3
            // 
            this.chk_Humidity3.BackColor = System.Drawing.Color.Transparent;
            this.chk_Humidity3.CheckBackColor = System.Drawing.Color.White;
            this.chk_Humidity3.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity3.DefaultCheckButtonWidth = 20;
            this.chk_Humidity3.ForeColor = System.Drawing.Color.White;
            this.chk_Humidity3.Location = new System.Drawing.Point(980, 498);
            this.chk_Humidity3.Name = "chk_Humidity3";
            this.chk_Humidity3.Size = new System.Drawing.Size(120, 24);
            this.chk_Humidity3.TabIndex = 5;
            this.chk_Humidity3.Tag = "5";
            this.chk_Humidity3.Text = "3#站点湿度";
            this.chk_Humidity3.UseVisualStyleBackColor = false;
            this.chk_Humidity3.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp5
            // 
            this.chk_Temp5.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp5.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp5.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp5.DefaultCheckButtonWidth = 20;
            this.chk_Temp5.ForeColor = System.Drawing.Color.White;
            this.chk_Temp5.Location = new System.Drawing.Point(838, 528);
            this.chk_Temp5.Name = "chk_Temp5";
            this.chk_Temp5.Size = new System.Drawing.Size(120, 24);
            this.chk_Temp5.TabIndex = 5;
            this.chk_Temp5.Tag = "8";
            this.chk_Temp5.Text = "5#站点温度";
            this.chk_Temp5.UseVisualStyleBackColor = false;
            this.chk_Temp5.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp2
            // 
            this.chk_Temp2.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp2.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp2.DefaultCheckButtonWidth = 20;
            this.chk_Temp2.ForeColor = System.Drawing.Color.White;
            this.chk_Temp2.Location = new System.Drawing.Point(1107, 468);
            this.chk_Temp2.Name = "chk_Temp2";
            this.chk_Temp2.Size = new System.Drawing.Size(120, 24);
            this.chk_Temp2.TabIndex = 5;
            this.chk_Temp2.Tag = "2";
            this.chk_Temp2.Text = "2#站点温度";
            this.chk_Temp2.UseVisualStyleBackColor = false;
            this.chk_Temp2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp3
            // 
            this.chk_Temp3.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp3.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp3.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp3.DefaultCheckButtonWidth = 20;
            this.chk_Temp3.ForeColor = System.Drawing.Color.White;
            this.chk_Temp3.Location = new System.Drawing.Point(838, 498);
            this.chk_Temp3.Name = "chk_Temp3";
            this.chk_Temp3.Size = new System.Drawing.Size(120, 24);
            this.chk_Temp3.TabIndex = 5;
            this.chk_Temp3.Tag = "4";
            this.chk_Temp3.Text = "3#站点温度";
            this.chk_Temp3.UseVisualStyleBackColor = false;
            this.chk_Temp3.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Humidity1
            // 
            this.chk_Humidity1.BackColor = System.Drawing.Color.Transparent;
            this.chk_Humidity1.CheckBackColor = System.Drawing.Color.White;
            this.chk_Humidity1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity1.DefaultCheckButtonWidth = 20;
            this.chk_Humidity1.ForeColor = System.Drawing.Color.White;
            this.chk_Humidity1.Location = new System.Drawing.Point(980, 468);
            this.chk_Humidity1.Name = "chk_Humidity1";
            this.chk_Humidity1.Size = new System.Drawing.Size(120, 24);
            this.chk_Humidity1.TabIndex = 5;
            this.chk_Humidity1.Tag = "1";
            this.chk_Humidity1.Text = "1#站点湿度";
            this.chk_Humidity1.UseVisualStyleBackColor = false;
            this.chk_Humidity1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp1
            // 
            this.chk_Temp1.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp1.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp1.DefaultCheckButtonWidth = 20;
            this.chk_Temp1.ForeColor = System.Drawing.Color.White;
            this.chk_Temp1.Location = new System.Drawing.Point(838, 468);
            this.chk_Temp1.Name = "chk_Temp1";
            this.chk_Temp1.Size = new System.Drawing.Size(120, 24);
            this.chk_Temp1.TabIndex = 5;
            this.chk_Temp1.Tag = "0";
            this.chk_Temp1.Text = "1#站点温度";
            this.chk_Temp1.UseVisualStyleBackColor = false;
            this.chk_Temp1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // title2
            // 
            this.title2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.title2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title2.BackgroundImage")));
            this.title2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(839, 584);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(109, 31);
            this.title2.TabIndex = 3;
            this.title2.TitleName = "系统日志";
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(838, 14);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(109, 31);
            this.title1.TabIndex = 2;
            this.title1.TitleName = "实时趋势";
            // 
            // thmControl6
            // 
            this.thmControl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl6.Humidity = "0.0";
            this.thmControl6.HumidityVarName = "模块6湿度";
            this.thmControl6.Location = new System.Drawing.Point(431, 584);
            this.thmControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl6.ModuleError = false;
            this.thmControl6.Name = "thmControl6";
            this.thmControl6.Size = new System.Drawing.Size(365, 256);
            this.thmControl6.StateVarName = "模块6异常";
            this.thmControl6.TabIndex = 1;
            this.thmControl6.Temp = "0.0";
            this.thmControl6.TempVarName = "模块6温度";
            this.thmControl6.Title = "6#站点";
            // 
            // thmControl4
            // 
            this.thmControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl4.Humidity = "0.0";
            this.thmControl4.HumidityVarName = "模块4湿度";
            this.thmControl4.Location = new System.Drawing.Point(430, 296);
            this.thmControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl4.ModuleError = false;
            this.thmControl4.Name = "thmControl4";
            this.thmControl4.Size = new System.Drawing.Size(365, 256);
            this.thmControl4.StateVarName = "模块4异常";
            this.thmControl4.TabIndex = 1;
            this.thmControl4.Temp = "0.0";
            this.thmControl4.TempVarName = "模块4温度";
            this.thmControl4.Title = "4#站点";
            // 
            // thmControl2
            // 
            this.thmControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl2.Humidity = "0.0";
            this.thmControl2.HumidityVarName = "模块2湿度";
            this.thmControl2.Location = new System.Drawing.Point(430, 15);
            this.thmControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl2.ModuleError = false;
            this.thmControl2.Name = "thmControl2";
            this.thmControl2.Size = new System.Drawing.Size(365, 256);
            this.thmControl2.StateVarName = "模块2异常";
            this.thmControl2.TabIndex = 1;
            this.thmControl2.Temp = "0.0";
            this.thmControl2.TempVarName = "模块2温度";
            this.thmControl2.Title = "2#站点";
            // 
            // thmControl5
            // 
            this.thmControl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl5.Humidity = "0.0";
            this.thmControl5.HumidityVarName = "模块5湿度";
            this.thmControl5.Location = new System.Drawing.Point(13, 584);
            this.thmControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl5.ModuleError = false;
            this.thmControl5.Name = "thmControl5";
            this.thmControl5.Size = new System.Drawing.Size(365, 256);
            this.thmControl5.StateVarName = "模块5异常";
            this.thmControl5.TabIndex = 0;
            this.thmControl5.Temp = "0.0";
            this.thmControl5.TempVarName = "模块5温度";
            this.thmControl5.Title = "5#站点";
            // 
            // thmControl3
            // 
            this.thmControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl3.Humidity = "0.0";
            this.thmControl3.HumidityVarName = "模块3湿度";
            this.thmControl3.Location = new System.Drawing.Point(12, 296);
            this.thmControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl3.ModuleError = false;
            this.thmControl3.Name = "thmControl3";
            this.thmControl3.Size = new System.Drawing.Size(365, 256);
            this.thmControl3.StateVarName = "模块3异常";
            this.thmControl3.TabIndex = 0;
            this.thmControl3.Temp = "0.0";
            this.thmControl3.TempVarName = "模块3温度";
            this.thmControl3.Title = "3#站点";
            // 
            // thmControl1
            // 
            this.thmControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl1.Humidity = "0.0";
            this.thmControl1.HumidityVarName = "模块1湿度";
            this.thmControl1.Location = new System.Drawing.Point(13, 14);
            this.thmControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl1.ModuleError = false;
            this.thmControl1.Name = "thmControl1";
            this.thmControl1.Size = new System.Drawing.Size(365, 256);
            this.thmControl1.StateVarName = "模块1异常";
            this.thmControl1.TabIndex = 0;
            this.thmControl1.Temp = "0.0";
            this.thmControl1.TempVarName = "模块1温度";
            this.thmControl1.Title = "1#站点";
            // 
            // MainPanel
            // 
            this.MainPanel.BackgroundImage = global::Modbus_MTH.Properties.Resources.BackGround;
            this.MainPanel.Controls.Add(this.lst_Info);
            this.MainPanel.Controls.Add(this.title1);
            this.MainPanel.Controls.Add(this.thmControl4);
            this.MainPanel.Controls.Add(this.thmControl2);
            this.MainPanel.Controls.Add(this.chk_Temp5);
            this.MainPanel.Controls.Add(this.chk_Humidity6);
            this.MainPanel.Controls.Add(this.thmControl3);
            this.MainPanel.Controls.Add(this.chart_ActuralTrend);
            this.MainPanel.Controls.Add(this.chk_Humidity4);
            this.MainPanel.Controls.Add(this.chk_Temp1);
            this.MainPanel.Controls.Add(this.chk_Temp6);
            this.MainPanel.Controls.Add(this.chk_Humidity1);
            this.MainPanel.Controls.Add(this.chk_Humidity2);
            this.MainPanel.Controls.Add(this.chk_Temp3);
            this.MainPanel.Controls.Add(this.chk_Temp4);
            this.MainPanel.Controls.Add(this.chk_Temp2);
            this.MainPanel.Controls.Add(this.chk_Humidity5);
            this.MainPanel.Controls.Add(this.chk_Humidity3);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1837, 1061);
            this.MainPanel.TabIndex = 7;
            // 
            // FormMointor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1837, 1061);
            this.Controls.Add(this.title2);
            this.Controls.Add(this.thmControl6);
            this.Controls.Add(this.thmControl5);
            this.Controls.Add(this.thmControl1);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMointor";
            this.Text = "集中监控";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Modbus_MTH_Lib.THMControl thmControl1;
        private Modbus_MTH_Lib.THMControl thmControl2;
        private Modbus_MTH_Lib.THMControl thmControl3;
        private Modbus_MTH_Lib.THMControl thmControl4;
        private Modbus_MTH_Lib.THMControl thmControl5;
        private Modbus_MTH_Lib.THMControl thmControl6;
        private Modbus_MTH_Lib.Title title1;
        private Modbus_MTH_Lib.Title title2;
        private SeeSharpTools.JY.GUI.StripChartX chart_ActuralTrend;
        private Modbus_MTH_Lib.CheckBoxEx chk_Temp1;
        private Modbus_MTH_Lib.CheckBoxEx chk_Humidity1;
        private Modbus_MTH_Lib.CheckBoxEx chk_Temp2;
        private Modbus_MTH_Lib.CheckBoxEx chk_Humidity2;
        private Modbus_MTH_Lib.CheckBoxEx chk_Temp3;
        private Modbus_MTH_Lib.CheckBoxEx chk_Humidity3;
        private Modbus_MTH_Lib.CheckBoxEx chk_Temp4;
        private Modbus_MTH_Lib.CheckBoxEx chk_Humidity4;
        private Modbus_MTH_Lib.CheckBoxEx chk_Temp5;
        private Modbus_MTH_Lib.CheckBoxEx chk_Humidity5;
        private Modbus_MTH_Lib.CheckBoxEx chk_Temp6;
        private Modbus_MTH_Lib.CheckBoxEx chk_Humidity6;
        private System.Windows.Forms.ListView lst_Info;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private Modbus_MTH_Lib.PanelEnhanced MainPanel;
    }
}