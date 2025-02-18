namespace Modbus_MTH_Lib
{
    partial class NaviButton
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lable_titleName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lable_titleName
            // 
            this.lable_titleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lable_titleName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable_titleName.ForeColor = System.Drawing.Color.White;
            this.lable_titleName.Location = new System.Drawing.Point(0, 0);
            this.lable_titleName.Name = "lable_titleName";
            this.lable_titleName.Size = new System.Drawing.Size(129, 43);
            this.lable_titleName.TabIndex = 0;
            this.lable_titleName.Text = "导航按钮";
            this.lable_titleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lable_titleName.Click += new System.EventHandler(this.lable_titleName_Click);
            // 
            // NaviButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lable_titleName);
            this.Name = "NaviButton";
            this.Size = new System.Drawing.Size(129, 43);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lable_titleName;
    }
}
