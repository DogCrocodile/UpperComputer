namespace WindowsFormsApp1
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DataFormatCombox = new System.Windows.Forms.ComboBox();
            this.DataFormatName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.data_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.text_wirte = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textLength = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.startAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DataTypeCombox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.StoreAreaCombox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.IpText = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.portText);
            this.groupBox1.Controls.Add(this.IpText);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.DataFormatCombox);
            this.groupBox1.Controls.Add(this.DataFormatName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(31, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通讯参数";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(571, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 13;
            this.button2.Text = "断开连接";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "建立连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataFormatCombox
            // 
            this.DataFormatCombox.FormattingEnabled = true;
            this.DataFormatCombox.Location = new System.Drawing.Point(84, 73);
            this.DataFormatCombox.Name = "DataFormatCombox";
            this.DataFormatCombox.Size = new System.Drawing.Size(121, 22);
            this.DataFormatCombox.TabIndex = 11;
            // 
            // DataFormatName
            // 
            this.DataFormatName.AutoSize = true;
            this.DataFormatName.Location = new System.Drawing.Point(29, 73);
            this.DataFormatName.Name = "DataFormatName";
            this.DataFormatName.Size = new System.Drawing.Size(49, 14);
            this.DataFormatName.TabIndex = 10;
            this.DataFormatName.Text = "大小端";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "端口号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.data_list);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.text_wirte);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textLength);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.startAddress);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.DataTypeCombox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.StoreAreaCombox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.address);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(32, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(808, 429);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读写测试";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 17;
            this.label17.Text = "读取信息";
            // 
            // data_list
            // 
            this.data_list.BackColor = System.Drawing.SystemColors.Control;
            this.data_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.data_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.data_list.HideSelection = false;
            this.data_list.Location = new System.Drawing.Point(17, 183);
            this.data_list.MultiSelect = false;
            this.data_list.Name = "data_list";
            this.data_list.Size = new System.Drawing.Size(732, 240);
            this.data_list.TabIndex = 16;
            this.data_list.UseCompatibleStateImageBehavior = false;
            this.data_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日期时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "信息内容";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(662, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 35);
            this.button3.TabIndex = 15;
            this.button3.Text = "写入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(528, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 35);
            this.button4.TabIndex = 14;
            this.button4.Text = "读取";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // text_wirte
            // 
            this.text_wirte.Location = new System.Drawing.Point(83, 115);
            this.text_wirte.Name = "text_wirte";
            this.text_wirte.Size = new System.Drawing.Size(406, 23);
            this.text_wirte.TabIndex = 13;
            this.text_wirte.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 118);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 14);
            this.label16.TabIndex = 12;
            this.label16.Text = "写入数据";
            // 
            // textLength
            // 
            this.textLength.Location = new System.Drawing.Point(291, 70);
            this.textLength.Name = "textLength";
            this.textLength.Size = new System.Drawing.Size(121, 23);
            this.textLength.TabIndex = 11;
            this.textLength.Text = "10";
            this.textLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(222, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 10;
            this.label15.Text = "读写长度";
            // 
            // startAddress
            // 
            this.startAddress.Location = new System.Drawing.Point(83, 70);
            this.startAddress.Name = "startAddress";
            this.startAddress.Size = new System.Drawing.Size(121, 23);
            this.startAddress.TabIndex = 9;
            this.startAddress.Text = "0";
            this.startAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 8;
            this.label14.Text = "起始地址";
            // 
            // DataTypeCombox
            // 
            this.DataTypeCombox.FormattingEnabled = true;
            this.DataTypeCombox.Location = new System.Drawing.Point(495, 28);
            this.DataTypeCombox.Name = "DataTypeCombox";
            this.DataTypeCombox.Size = new System.Drawing.Size(121, 22);
            this.DataTypeCombox.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(426, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 6;
            this.label13.Text = "数据类型";
            // 
            // StoreAreaCombox
            // 
            this.StoreAreaCombox.FormattingEnabled = true;
            this.StoreAreaCombox.Location = new System.Drawing.Point(277, 28);
            this.StoreAreaCombox.Name = "StoreAreaCombox";
            this.StoreAreaCombox.Size = new System.Drawing.Size(121, 22);
            this.StoreAreaCombox.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 4;
            this.label12.Text = "存储区";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(83, 28);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(121, 23);
            this.address.TabIndex = 2;
            this.address.Text = "1";
            this.address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "从站地址";
            // 
            // IpText
            // 
            this.IpText.Location = new System.Drawing.Point(84, 28);
            this.IpText.Name = "IpText";
            this.IpText.Size = new System.Drawing.Size(121, 23);
            this.IpText.TabIndex = 14;
            this.IpText.Text = "127.0.0.1";
            this.IpText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(278, 28);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(121, 23);
            this.portText.TabIndex = 15;
            this.portText.Text = "502";
            this.portText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(853, 674);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "ModbusTCP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox DataFormatCombox;
        private System.Windows.Forms.Label DataFormatName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox DataTypeCombox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox StoreAreaCombox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox startAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox text_wirte;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textLength;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListView data_list;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox IpText;
        private System.Windows.Forms.TextBox portText;
    }
}

