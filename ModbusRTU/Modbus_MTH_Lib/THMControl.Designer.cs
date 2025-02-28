
namespace Modbus_MTH_Lib
{
    partial class THMControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dialPlate = new DialPlate();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Temp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Humidity = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dialPlate
            // 
            this.dialPlate.AlarmAngle = 120F;
            this.dialPlate.AlarmColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.dialPlate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.dialPlate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dialPlate.ForeColor = System.Drawing.Color.White;
            this.dialPlate.Humidity = 10F;
            this.dialPlate.HumidityColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.dialPlate.HumidityScale = 0.35F;
            this.dialPlate.InThinkness = 16;
            this.dialPlate.Location = new System.Drawing.Point(20, 15);
            this.dialPlate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dialPlate.Name = "dialPlate";
            this.dialPlate.OutThinkness = 8;
            this.dialPlate.RangeMax = 90F;
            this.dialPlate.RangeMin = 0F;
            this.dialPlate.RingColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.dialPlate.Size = new System.Drawing.Size(327, 210);
            this.dialPlate.TabIndex = 0;
            this.dialPlate.Temp = 10F;
            this.dialPlate.TempColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.dialPlate.TempScale = 0.65F;
            this.dialPlate.TextScale = 0.85F;
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(3, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(80, 40);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "1#站点";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "温度:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Temp
            // 
            this.lbl_Temp.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Temp.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Temp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.lbl_Temp.Location = new System.Drawing.Point(56, 212);
            this.lbl_Temp.Name = "lbl_Temp";
            this.lbl_Temp.Size = new System.Drawing.Size(74, 40);
            this.lbl_Temp.TabIndex = 1;
            this.lbl_Temp.Text = "0.0";
            this.lbl_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.label3.Location = new System.Drawing.Point(118, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "℃";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(202, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 40);
            this.label4.TabIndex = 1;
            this.label4.Text = "湿度:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Humidity
            // 
            this.lbl_Humidity.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Humidity.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Humidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.lbl_Humidity.Location = new System.Drawing.Point(251, 212);
            this.lbl_Humidity.Name = "lbl_Humidity";
            this.lbl_Humidity.Size = new System.Drawing.Size(74, 40);
            this.lbl_Humidity.TabIndex = 1;
            this.lbl_Humidity.Text = "0.0";
            this.lbl_Humidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.label6.Location = new System.Drawing.Point(313, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "℃";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // THMControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Humidity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Temp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.dialPlate);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "THMControl";
            this.Size = new System.Drawing.Size(365, 256);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DialPlate dialPlate;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Temp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Humidity;
        private System.Windows.Forms.Label label6;
    }
}
