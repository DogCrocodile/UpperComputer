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
            this.TopPannel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MiddlePannel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.naviButton1 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton4 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton3 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton5 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton6 = new Modbus_MTH_Lib.NaviButton();
            this.naviButton2 = new Modbus_MTH_Lib.NaviButton();
            this.CorePannel = new Modbus_MTH_Lib.PanelEx();
            this.MainPannel = new System.Windows.Forms.Panel();
            this.TopPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MiddlePannel.SuspendLayout();
            this.CorePannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPannel
            // 
            this.TopPannel.BackColor = System.Drawing.Color.Transparent;
            this.TopPannel.Controls.Add(this.naviButton1);
            this.TopPannel.Controls.Add(this.naviButton4);
            this.TopPannel.Controls.Add(this.naviButton3);
            this.TopPannel.Controls.Add(this.naviButton5);
            this.TopPannel.Controls.Add(this.naviButton6);
            this.TopPannel.Controls.Add(this.naviButton2);
            this.TopPannel.Controls.Add(this.button1);
            this.TopPannel.Controls.Add(this.label_Title);
            this.TopPannel.Controls.Add(this.label1);
            this.TopPannel.Controls.Add(this.pictureBox1);
            this.TopPannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPannel.Location = new System.Drawing.Point(0, 0);
            this.TopPannel.Name = "TopPannel";
            this.TopPannel.Size = new System.Drawing.Size(1900, 133);
            this.TopPannel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(1004, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label_Title
            // 
            this.label_Title.Font = new System.Drawing.Font("微软雅黑", 23.5F);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(418, 12);
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
            this.label1.Location = new System.Drawing.Point(71, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CodeDog";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Modbus_MTH.Properties.Resources.OIP_C;
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
            this.MiddlePannel.Controls.Add(this.label2);
            this.MiddlePannel.Controls.Add(this.button3);
            this.MiddlePannel.Controls.Add(this.button2);
            this.MiddlePannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MiddlePannel.Location = new System.Drawing.Point(0, 133);
            this.MiddlePannel.Name = "MiddlePannel";
            this.MiddlePannel.Size = new System.Drawing.Size(1900, 65);
            this.MiddlePannel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(569, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "集中监控";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(719, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 28);
            this.button3.TabIndex = 1;
            this.button3.Text = "》";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 31);
            this.button2.TabIndex = 0;
            this.button2.Text = "《";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // naviButton1
            // 
            this.naviButton1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.naviButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton1.IsLeft = true;
            this.naviButton1.IsSelected = false;
            this.naviButton1.Location = new System.Drawing.Point(31, 68);
            this.naviButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton1.Name = "naviButton1";
            this.naviButton1.Size = new System.Drawing.Size(129, 43);
            this.naviButton1.TabIndex = 11;
            this.naviButton1.TitleName = "导航按钮";
            // 
            // naviButton4
            // 
            this.naviButton4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.naviButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton4.IsLeft = true;
            this.naviButton4.IsSelected = false;
            this.naviButton4.Location = new System.Drawing.Point(1040, 71);
            this.naviButton4.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.naviButton4.Name = "naviButton4";
            this.naviButton4.Size = new System.Drawing.Size(129, 43);
            this.naviButton4.TabIndex = 10;
            this.naviButton4.TitleName = "导航按钮";
            // 
            // naviButton3
            // 
            this.naviButton3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.naviButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton3.IsLeft = true;
            this.naviButton3.IsSelected = false;
            this.naviButton3.Location = new System.Drawing.Point(339, 68);
            this.naviButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton3.Name = "naviButton3";
            this.naviButton3.Size = new System.Drawing.Size(129, 43);
            this.naviButton3.TabIndex = 7;
            this.naviButton3.TitleName = "导航按钮";
            // 
            // naviButton5
            // 
            this.naviButton5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.naviButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton5.IsLeft = true;
            this.naviButton5.IsSelected = false;
            this.naviButton5.Location = new System.Drawing.Point(719, 73);
            this.naviButton5.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.naviButton5.Name = "naviButton5";
            this.naviButton5.Size = new System.Drawing.Size(129, 43);
            this.naviButton5.TabIndex = 9;
            this.naviButton5.TitleName = "导航按钮";
            // 
            // naviButton6
            // 
            this.naviButton6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.naviButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton6.IsLeft = true;
            this.naviButton6.IsSelected = false;
            this.naviButton6.Location = new System.Drawing.Point(878, 73);
            this.naviButton6.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.naviButton6.Name = "naviButton6";
            this.naviButton6.Size = new System.Drawing.Size(129, 43);
            this.naviButton6.TabIndex = 8;
            this.naviButton6.TitleName = "导航按钮";
            // 
            // naviButton2
            // 
            this.naviButton2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.naviButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton2.IsLeft = true;
            this.naviButton2.IsSelected = false;
            this.naviButton2.Location = new System.Drawing.Point(184, 68);
            this.naviButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton2.Name = "naviButton2";
            this.naviButton2.Size = new System.Drawing.Size(129, 43);
            this.naviButton2.TabIndex = 5;
            this.naviButton2.TitleName = "导航按钮";
            // 
            // CorePannel
            // 
            this.CorePannel.BackColor = System.Drawing.Color.Transparent;
            this.CorePannel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CorePannel.BorderWidth = 3;
            this.CorePannel.BottomGap = 20;
            this.CorePannel.Controls.Add(this.MainPannel);
            this.CorePannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorePannel.LeftGap = 20;
            this.CorePannel.Location = new System.Drawing.Point(0, 198);
            this.CorePannel.Name = "CorePannel";
            this.CorePannel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.CorePannel.RightGap = 10;
            this.CorePannel.Size = new System.Drawing.Size(1900, 732);
            this.CorePannel.TabIndex = 2;
            this.CorePannel.TopGap = 10;
            // 
            // MainPannel
            // 
            this.MainPannel.BackColor = System.Drawing.Color.Transparent;
            this.MainPannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MainPannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPannel.Cursor = System.Windows.Forms.Cursors.No;
            this.MainPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPannel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainPannel.Location = new System.Drawing.Point(20, 10);
            this.MainPannel.Name = "MainPannel";
            this.MainPannel.Size = new System.Drawing.Size(1860, 712);
            this.MainPannel.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1900, 930);
            this.Controls.Add(this.CorePannel);
            this.Controls.Add(this.MiddlePannel);
            this.Controls.Add(this.TopPannel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private Modbus_MTH_Lib.NaviButton naviButton3;
        private Modbus_MTH_Lib.NaviButton naviButton2;
        private Modbus_MTH_Lib.NaviButton naviButton4;
        private Modbus_MTH_Lib.NaviButton naviButton5;
        private Modbus_MTH_Lib.NaviButton naviButton6;
        private Modbus_MTH_Lib.NaviButton naviButton1;
        private Modbus_MTH_Lib.PanelEx CorePannel;
        private System.Windows.Forms.Panel MainPannel;
    }
}

