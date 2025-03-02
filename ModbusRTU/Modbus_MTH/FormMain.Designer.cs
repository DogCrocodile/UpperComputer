using System.Drawing;

namespace Modbus_MTH
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TopPannel = new System.Windows.Forms.Panel();
            this.nav_Monitor = new Modbus_MTH_Lib.NaviButton();
            this.naviButton4 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton3 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton5 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton6 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton2 = new Modbus_MTH_Lib.NaviButton();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MiddlePannel = new System.Windows.Forms.Panel();
            this.scrollingText1 = new SeeSharpTools.JY.GUI.ScrollingText();
            this.lbl_CurrentTime = new System.Windows.Forms.Label();
            this.lbl_User = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Right = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.CorePannel = new Modbus_MTH_Lib.PanelEx();
            this.scrollingAlarm = new System.Windows.Forms.Panel();
            this.TopPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MiddlePannel.SuspendLayout();
            this.CorePannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPannel
            // 
            this.TopPannel.BackColor = System.Drawing.Color.Transparent;
            this.TopPannel.Controls.Add(this.nav_Monitor);
            this.TopPannel.Controls.Add(this.naviButton4);
            this.TopPannel.Controls.Add(this.naviButton3);
            this.TopPannel.Controls.Add(this.naviButton5);
            this.TopPannel.Controls.Add(this.naviButton6);
            this.TopPannel.Controls.Add(this.naviButton2);
            this.TopPannel.Controls.Add(this.btn_Exit);
            this.TopPannel.Controls.Add(this.label_Title);
            this.TopPannel.Controls.Add(this.label1);
            this.TopPannel.Controls.Add(this.pictureBox1);
            this.TopPannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPannel.ForeColor = System.Drawing.Color.Black;
            this.TopPannel.Location = new System.Drawing.Point(0, 0);
            this.TopPannel.Name = "TopPannel";
            this.TopPannel.Size = new System.Drawing.Size(1837, 133);
            this.TopPannel.TabIndex = 0;
            // 
            // nav_Monitor
            // 
            this.nav_Monitor.BackColor = System.Drawing.Color.Transparent;
            this.nav_Monitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nav_Monitor.BackgroundImage")));
            this.nav_Monitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nav_Monitor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nav_Monitor.IsLeft = true;
            this.nav_Monitor.IsSelected = false;
            this.nav_Monitor.Location = new System.Drawing.Point(31, 68);
            this.nav_Monitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nav_Monitor.Name = "nav_Monitor";
            this.nav_Monitor.Size = new System.Drawing.Size(129, 43);
            this.nav_Monitor.TabIndex = 11;
            this.nav_Monitor.TitleName = "集中监控";
            this.nav_Monitor.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // naviButton4
            // 
            this.naviButton4.BackColor = System.Drawing.Color.Transparent;
            this.naviButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton4.BackgroundImage")));
            this.naviButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton4.IsLeft = false;
            this.naviButton4.IsSelected = false;
            this.naviButton4.Location = new System.Drawing.Point(1297, 68);
            this.naviButton4.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.naviButton4.Name = "naviButton4";
            this.naviButton4.Size = new System.Drawing.Size(129, 43);
            this.naviButton4.TabIndex = 10;
            this.naviButton4.TitleName = "用户管理";
            // 
            // naviButton3
            // 
            this.naviButton3.BackColor = System.Drawing.Color.Transparent;
            this.naviButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton3.BackgroundImage")));
            this.naviButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton3.IsLeft = true;
            this.naviButton3.IsSelected = false;
            this.naviButton3.Location = new System.Drawing.Point(339, 68);
            this.naviButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton3.Name = "naviButton3";
            this.naviButton3.Size = new System.Drawing.Size(129, 43);
            this.naviButton3.TabIndex = 7;
            this.naviButton3.TitleName = "报警追溯";
            // 
            // naviButton5
            // 
            this.naviButton5.BackColor = System.Drawing.Color.Transparent;
            this.naviButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton5.BackgroundImage")));
            this.naviButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton5.IsLeft = false;
            this.naviButton5.IsSelected = false;
            this.naviButton5.Location = new System.Drawing.Point(976, 70);
            this.naviButton5.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.naviButton5.Name = "naviButton5";
            this.naviButton5.Size = new System.Drawing.Size(129, 43);
            this.naviButton5.TabIndex = 9;
            this.naviButton5.TitleName = "配方管理";
            // 
            // naviButton6
            // 
            this.naviButton6.BackColor = System.Drawing.Color.Transparent;
            this.naviButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton6.BackgroundImage")));
            this.naviButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton6.IsLeft = false;
            this.naviButton6.IsSelected = false;
            this.naviButton6.Location = new System.Drawing.Point(1135, 70);
            this.naviButton6.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.naviButton6.Name = "naviButton6";
            this.naviButton6.Size = new System.Drawing.Size(129, 43);
            this.naviButton6.TabIndex = 8;
            this.naviButton6.TitleName = "历史趋势";
            // 
            // naviButton2
            // 
            this.naviButton2.BackColor = System.Drawing.Color.Transparent;
            this.naviButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton2.BackgroundImage")));
            this.naviButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton2.IsLeft = true;
            this.naviButton2.IsSelected = false;
            this.naviButton2.Location = new System.Drawing.Point(184, 68);
            this.naviButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton2.Name = "naviButton2";
            this.naviButton2.Size = new System.Drawing.Size(129, 43);
            this.naviButton2.TabIndex = 5;
            this.naviButton2.TitleName = "参数设置";
            this.naviButton2.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Black;
            this.btn_Exit.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Exit.Image = global::Modbus_MTH.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(1455, 16);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(98, 42);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label_Title
            // 
            this.label_Title.Font = new System.Drawing.Font("微软雅黑", 23.5F);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(539, 21);
            this.label_Title.Name = "label_Title";
            this.label_Title.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_Title.Size = new System.Drawing.Size(371, 51);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "多温湿度采集系统";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CodeDog";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Modbus_MTH.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MiddlePannel
            // 
            this.MiddlePannel.BackColor = System.Drawing.Color.Transparent;
            this.MiddlePannel.Controls.Add(this.scrollingText1);
            this.MiddlePannel.Controls.Add(this.lbl_CurrentTime);
            this.MiddlePannel.Controls.Add(this.lbl_User);
            this.MiddlePannel.Controls.Add(this.label2);
            this.MiddlePannel.Controls.Add(this.btn_Right);
            this.MiddlePannel.Controls.Add(this.btn_Left);
            this.MiddlePannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MiddlePannel.Location = new System.Drawing.Point(0, 133);
            this.MiddlePannel.Name = "MiddlePannel";
            this.MiddlePannel.Size = new System.Drawing.Size(1837, 65);
            this.MiddlePannel.TabIndex = 1;
            // 
            // scrollingText1
            // 
            this.scrollingText1.BorderColor = System.Drawing.Color.Black;
            this.scrollingText1.BorderVisible = true;
            this.scrollingText1.Cursor = System.Windows.Forms.Cursors.Default;
            this.scrollingText1.Location = new System.Drawing.Point(933, 12);
            this.scrollingText1.Name = "scrollingText1";
            this.scrollingText1.ScrollDirection = SeeSharpTools.JY.GUI.ScrollingText.TextDirection.RightToLeft;
            this.scrollingText1.ScrollSpeed = 25;
            this.scrollingText1.Size = new System.Drawing.Size(216, 40);
            this.scrollingText1.TabIndex = 0;
            this.scrollingText1.Text = "ScrollingText";
            this.scrollingText1.VerticleAligment = SeeSharpTools.JY.GUI.ScrollingText.TextVerticalAlignment.Center;
            // 
            // lbl_CurrentTime
            // 
            this.lbl_CurrentTime.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.lbl_CurrentTime.Location = new System.Drawing.Point(278, 23);
            this.lbl_CurrentTime.Name = "lbl_CurrentTime";
            this.lbl_CurrentTime.Size = new System.Drawing.Size(268, 25);
            this.lbl_CurrentTime.TabIndex = 1;
            this.lbl_CurrentTime.Text = "2025年02月19日 09:00:00 星期一";
            this.lbl_CurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_User
            // 
            this.lbl_User.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_User.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.lbl_User.Location = new System.Drawing.Point(56, 22);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(63, 25);
            this.lbl_User.TabIndex = 1;
            this.lbl_User.Text = "管理员";
            this.lbl_User.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(682, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "集中监控";
            // 
            // btn_Right
            // 
            this.btn_Right.BackColor = System.Drawing.Color.Transparent;
            this.btn_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Right.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Right.FlatAppearance.BorderSize = 0;
            this.btn_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Right.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Right.ForeColor = System.Drawing.Color.White;
            this.btn_Right.Image = global::Modbus_MTH.Properties.Resources.right;
            this.btn_Right.Location = new System.Drawing.Point(791, 2);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(25, 60);
            this.btn_Right.TabIndex = 2;
            this.btn_Right.UseVisualStyleBackColor = false;
            // 
            // btn_Left
            // 
            this.btn_Left.BackColor = System.Drawing.Color.Transparent;
            this.btn_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Left.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Left.FlatAppearance.BorderSize = 0;
            this.btn_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Left.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Left.ForeColor = System.Drawing.Color.White;
            this.btn_Left.Image = global::Modbus_MTH.Properties.Resources.left;
            this.btn_Left.Location = new System.Drawing.Point(616, 5);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(24, 54);
            this.btn_Left.TabIndex = 2;
            this.btn_Left.UseVisualStyleBackColor = false;
            // 
            // CorePannel
            // 
            this.CorePannel.BackColor = System.Drawing.Color.Transparent;
            this.CorePannel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CorePannel.BorderWidth = 3;
            this.CorePannel.BottomGap = 20;
            this.CorePannel.Controls.Add(this.scrollingAlarm);
            this.CorePannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorePannel.LeftGap = 20;
            this.CorePannel.Location = new System.Drawing.Point(0, 198);
            this.CorePannel.Name = "CorePannel";
            this.CorePannel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.CorePannel.RightGap = 10;
            this.CorePannel.Size = new System.Drawing.Size(1837, 863);
            this.CorePannel.TabIndex = 2;
            this.CorePannel.TopGap = 10;
            // 
            // scrollingAlarm
            // 
            this.scrollingAlarm.BackColor = System.Drawing.Color.Transparent;
            this.scrollingAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.scrollingAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scrollingAlarm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.scrollingAlarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.scrollingAlarm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scrollingAlarm.Location = new System.Drawing.Point(20, 10);
            this.scrollingAlarm.Name = "scrollingAlarm";
            this.scrollingAlarm.Size = new System.Drawing.Size(1860, 833);
            this.scrollingAlarm.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Modbus_MTH.Properties.Resources.Main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1837, 1061);
            this.Controls.Add(this.CorePannel);
            this.Controls.Add(this.MiddlePannel);
            this.Controls.Add(this.TopPannel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.TopPannel.ResumeLayout(false);
            this.TopPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MiddlePannel.ResumeLayout(false);
            this.MiddlePannel.PerformLayout();
            this.CorePannel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPannel;
        private System.Windows.Forms.Panel MiddlePannel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Label label2;
        private Modbus_MTH_Lib.NaviButton naviButton3;
        private Modbus_MTH_Lib.NaviButton naviButton2;
        private Modbus_MTH_Lib.NaviButton naviButton4;
        private Modbus_MTH_Lib.NaviButton naviButton5;
        private Modbus_MTH_Lib.NaviButton naviButton6;
        private Modbus_MTH_Lib.NaviButton nav_Monitor;
        private Modbus_MTH_Lib.PanelEx CorePannel;
        private System.Windows.Forms.Panel scrollingAlarm;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Label lbl_CurrentTime;
        private SeeSharpTools.JY.GUI.ScrollingText scrollingText1;
    }
}

