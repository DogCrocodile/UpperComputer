using Modbus_MTH_Helper;
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
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace Modbus_MTH
{
    public partial class FrmParamSet : Form
    {
        public FrmParamSet(string devPath)
        {
            InitializeComponent();
            this.devPath = devPath;

            updateTimer.Interval = 500;
            updateTimer.Tick += updateTimer_Tick;

            InitParam();

            CommonBindEvent();

            this.FormClosing += (sender, e) =>
            {
               this.updateTimer.Stop();
            };

            this.updateTimer.Start();
            //updateTimer.Enabled = true;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            GetLimitParam();
        }

        private string devPath = string.Empty;

        private Timer updateTimer = new Timer();

        /// <summary>
        /// 通用事件绑定方法
        /// </summary>
        private void CommonBindEvent()
        {
            foreach (var item in this.PanelMain.Controls.OfType<TextSet>())
            {
                if (item.BindVarName != null && item.BindVarName.ToString().Length > 0)
                {
                    item.ControlDoubleClick += Common_ControlDoubleClick;
                }
            }

            foreach (var item in this.PanelMain.Controls.OfType<CheckBoxEx>())
            {
                if (item.Tag != null && item.Tag.ToString().Length > 0)
                {
                    item.CheckedChanged += Common_CheckedChanged;
                }
            }
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitParam()
        {
            this.txt_IP.Text = CommonMethods.Device.IPAddress;
            this.txt_Port.Text = CommonMethods.Device.Port.ToString();

            GetLimitParam() ;

            GetAlarmParam();
        }

        /// <summary>
        /// 实时读取限值数据
        /// </summary>
        private void GetLimitParam()
        {
            if (CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.PanelMain.Controls.OfType<TextSet>())
                {
                    string s1 = CommonMethods.Device[item.BindVarName.ToString()].ToString();

                    if (item.BindVarName != null && item.BindVarName.ToString().Length > 0)
                    {
                        item.CurrentValue = CommonMethods.Device[item.BindVarName.ToString()].ToString();
                    }
                    if (item.AlarmVarName != null && item.AlarmVarName.ToString().Length > 0)
                    {
                        item.IsAlarm = CommonMethods.Device[item.AlarmVarName].ToString() == "True";
                    }
                }
            }
        }

        /// <summary>
        /// 实时读取和启用状态数据
        /// </summary>
        private void GetAlarmParam()
        {
            if (CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.PanelMain.Controls.OfType<CheckBoxEx>())
                {
                    if (item.Tag != null && item.Tag.ToString().Length > 0)
                    {
                        item.Checked = CommonMethods.Device[item.Tag.ToString()].ToString() == "1";
                    }
                }
            }
        }

        private void btn_GroupConfig_Click(object sender, EventArgs e)
        {
            new FrmGroupConfig().ShowDialog();
        }

        private void btn_VarConfig_Click(object sender, EventArgs e)
        {
            new FrmVariableConfig().ShowDialog();
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            bool result = IniConfigHelper.WriteIniData("设备参数", "IP地址", this.txt_IP.Text.Trim(), devPath);

            result &= IniConfigHelper.WriteIniData("设备参数", "端口号", this.txt_Port.Text.Trim(), devPath);
            if (result)
            {
                CommonMethods.Device.IPAddress = this.txt_IP.Text.Trim();

                CommonMethods.Device.Port = Convert.ToInt32(this.txt_Port.Text.Trim());

                DialogResult dialogResult = new FrmMsgBoxWithAck("通信参数配置成功,是否立即重连?", "通信设置").ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    CommonMethods.Device.IsConnected = false;
                }
            }
            else
            {
                new FrmMsgBoxWithoutAck("通信参数配置失败", "通信设置").Show();
            }
        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
            this.txt_IP.Text = CommonMethods.Device.IPAddress;
            this.txt_Port.Text = CommonMethods.Device.Port.ToString();
        }

        private void Common_ControlDoubleClick(object sender, EventArgs e)
        {
            if (sender is TextSet textset)
            {
                if (textset.BindVarName != null && textset.BindVarName.ToString().Length > 0)
                {
                    FrmModify frmModify = new FrmModify(textset.TitleName, textset.BindVarName, textset.CurrentValue);

                    frmModify.ShowDialog();
                }
            }
        }

        private void Common_CheckedChanged(object sender, EventArgs e)
        {
            if(sender is CheckBoxEx checkbox)
            {
                if(checkbox.Tag != null && checkbox.Tag.ToString().Length > 0)
                {
                    bool result = CommonMethods.CommonWrite(checkbox.Tag.ToString(), checkbox.Checked ? "1" : "0");

                    if (result == false)
                    {
                        checkbox.CheckedChanged -= Common_CheckedChanged;
                        checkbox.Checked = !checkbox.Checked;
                        checkbox.CheckedChanged += Common_CheckedChanged;
                    }
                }
            }
        }
    }
}
