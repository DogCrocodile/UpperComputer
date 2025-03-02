using MiniExcelLibs;
using Modbus_MTH_Helper;
using Modbus_MTH_Lib;
using ModbusTCPLib;
using MTHModels;
using MTHProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace Modbus_MTH
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            actualAlarmList.CollectionChanged += ActualAlarmList_CollectionChanged;
        }

        private string devPath = Application.StartupPath + "\\Config\\Device.ini";
        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";
        private string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";
        private CancellationTokenSource cts;
        private ObservableCollection<string> actualAlarmList = new ObservableCollection<string>();

        private void FormMain_Load(object sender, EventArgs e)
        {
            //打开集中监控窗体
            CommonNaviButton_Click(this.nav_Monitor, null);
            //CommonMethods.AddLog(0, "aaa");
            CommonMethods.Device = LoadDevice(devPath, groupPath, variablePath);
            if (CommonMethods.Device != null)
            {
                CommonMethods.AddLog(0, "设备信息加载成功");

                //开启多线程实时通信
                cts = new CancellationTokenSource();

                CommonMethods.Device.AlarmTrigEvent += Device_AlarmTrigEvent;

                Task.Run(new Action(() =>
                {
                    DeviceCommunication(CommonMethods.Device);
                }), cts.Token);
            }
        }

        /// <summary>
        /// 报警触发事件
        /// </summary>
        /// <param name="ackType"></param>
        /// <param name="variable"></param>
        private void Device_AlarmTrigEvent(bool ackType, Variable variable)
        {
            if (ackType)
            {
                CommonMethods.AddLog(1, variable.Remark + "触发");

                //存储
                /* sysLogManage.AddSysLog(new SysLog()
                 {
                     InsertTime = CurrentTime,
                     Note = variable.Remark,
                     AlarmType = "触发",
                     Operator = CommonMethods.CurrentAdmin.LoginName,
                     VarName = variable.VarName
                 });*/

                if (this.actualAlarmList.Contains(variable.Remark))
                {
                    this.actualAlarmList.Add(variable.Remark);
                }
            }
            else
            {
                CommonMethods.AddLog(0, variable.Remark + "消除");

                //存储
                /*sysLogManage.AddSysLog(new SysLog()
                {
                    InsertTime = CurrentTime,
                    Note = variable.Remark,
                    AlarmType = "消除",
                    Operator = CommonMethods.CurrentAdmin.LoginName,
                    VarName = variable.VarName
                });*/

                if (this.actualAlarmList.Contains(variable.Remark))
                {
                    this.actualAlarmList.Remove(variable.Remark);
                }
            }
        }

        private void ActualAlarmList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                //根据集合的数量进行处理
                switch (actualAlarmList.Count)
                {
                    case 0:
                        this.scrollingAlarm.Text = "当前系统无报警";
                        break;
                    default:
                        this.scrollingAlarm.Text = string.Join(" ", actualAlarmList);
                        break;
                }
            }));
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 通用窗体切换
        /// <summary>
        /// 通用窗体切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonNaviButton_Click(object sender, EventArgs e)
        {
            if (sender is NaviButton navi) //一定要有类型
            {
                if (Enum.IsDefined(typeof(FormNames), navi.TitleName))
                {
                    //拿到导航按钮对应的窗体枚举值 formNames(枚举类型)
                    FormNames formNames = (FormNames)Enum.Parse(typeof(FormNames), navi.TitleName, true);

                    //窗体切换
                    OpenForm(this.scrollingAlarm, formNames);
                }
            }
        }
        #endregion

        #region 通用打开窗体
        /// <summary>
        /// 通用打开窗体
        /// </summary>
        /// <param name="mainPanel">容器控件</param>
        /// <param name="formNames">窗体枚举名称</param>
        private void OpenForm(Panel mainPanel, FormNames formNames)
        {
            int total = mainPanel.Controls.Count;

            int closeCount = 0;

            bool isFind = false;

            for (int i = 0; i < total; i++)  //不能用foreach，foreach只能用于长度固定不变的，而这里会关闭窗体
            {
                Control ct = scrollingAlarm.Controls[i - closeCount];

                if (ct is Form frm)
                {
                    //判断当前的Form是不是我们当前需要操作的窗体
                    if (frm.Text == formNames.ToString())
                    {
                        frm.BringToFront(); //置前
                        isFind = true;
                        break;
                    }
                    //如果当前Form不是我们需要操作的窗体,然后判断是否为固定窗体，如果不是，则关闭，如果是，则不做处理
                    else if ((FormNames)Enum.Parse(typeof(FormNames), frm.Text, true) >= FormNames.临界窗体)
                    {                                //枚举的本质是值类型
                        frm.Close();
                        closeCount++;
                    }
                }
            }

            if (isFind == false)  //相当于打开的窗体是一个新的窗体
            {
                Form frm = null;

                switch (formNames)
                {
                    case FormNames.集中监控:
                        frm = new FormMointor();
                        CommonMethods.AddLog = ((FormMointor)frm).AddLog;
                        break;
                    case FormNames.参数设置:
                        frm = new FrmParamSet(devPath);
                        break;
                    case FormNames.配方管理:
                        //frm = new FrmRecipe(devPath);
                        break;
                    case FormNames.报警追溯:
                        //frm = new FrmAlarm();
                        break;
                    case FormNames.历史趋势:
                        //frm = new FrmHistory();
                        break;
                    case FormNames.用户管理:
                        //frm = new FrmUserManage();
                        break;
                    default:
                        break;
                }

                if (frm != null)  //比如说临界窗体
                {
                    //设置非顶层窗体
                    frm.TopLevel = false;

                    //去除边框
                    frm.FormBorderStyle = FormBorderStyle.None;

                    //填充
                    frm.Dock = DockStyle.Fill;

                    //设置父容器为容器控件
                    frm.Parent = mainPanel;

                    //置前
                    frm.BringToFront();

                    //显示
                    frm.Show();
                }
            }
        }
        #endregion

        #region 减少闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 加载设备信息
        private Device LoadDevice(string devicePath, string groupPath, string variablePath)
        {

            //判断文件是否存在
            if (!File.Exists(devicePath))
            {
                CommonMethods.AddLog(1, "设备文件不存在");
                return null;
            }

            List<Group> gpList = LoadGroup(groupPath, variablePath);

            if (gpList != null && gpList.Count > 0)
            {
                try
                {
                    return new Device()
                    {
                        IPAddress = IniConfigHelper.ReadIniData("设备参数", "IP地址", "127.0.0.1", devicePath),
                        Port = Convert.ToInt32(IniConfigHelper.ReadIniData("设备参数", "端口号", "502", devicePath)),
                        CurrentRecipe = IniConfigHelper.ReadIniData("配方参数", "当前配方", "", devicePath),
                        GroupList = gpList
                    };
                }
                catch (Exception ex)
                {
                    // 日志写入
                    CommonMethods.AddLog(1, "设备信息加载失败:" + ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通信组及通信变量的解析
        /// </summary>
        /// <param name="groupPath"></param>
        /// <param name="variablePath"></param>
        /// <returns></returns>
        private List<Group> LoadGroup(string groupPath, string variablePath)
        {
            //判断文件是否存在
            if (!File.Exists(groupPath))
            {
                CommonMethods.AddLog(1, "通信组文件不存在");
                return null;
            }
            if (!File.Exists(variablePath))
            {
                CommonMethods.AddLog(1, "通信变量文件不存在");
                return null;
            }

            //先解析通信组
            List<Group> GpList = null;
            try
            {
                GpList = MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信组加载失败:" + ex.Message);
                return null;
            }

            List<Variable> VarList = null;
            try
            {
                VarList = MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信变量加载失败:" + ex.Message);
                return null;
            }

            if (GpList != null && VarList != null)
            {
                foreach (var group in GpList)
                {
                    group.VarList = VarList.FindAll(c => c.GroupName == group.GroupName).ToList();
                }
                return GpList;
            }
            else
            {
                return null;
            }
        }
        #endregion

        private void DeviceCommunication(Device device)
        {
            while (!cts.IsCancellationRequested)
            {
                if (device.IsConnected)
                {
                    //通信读取
                    foreach (var gp in device.GroupList)
                    {
                        byte[] data = null;

                        //应该返回的字节长度
                        int reqLength = 0;

                        if (gp.StoreArea == "输入线圈" || gp.StoreArea == "输出线圈")
                        {
                            switch (gp.StoreArea)
                            {
                                case "输入线圈":
                                    data = CommonMethods.modbus.ReadInputCoils(gp.Start, gp.Length);
                                    reqLength = ShortLib.GetByteLengthFromBoolLength(gp.Length);
                                    break;
                                case "输出线圈":
                                    data = CommonMethods.modbus.ReadOutputCoils(gp.Start, gp.Length);
                                    reqLength = ShortLib.GetByteLengthFromBoolLength(gp.Length);
                                    break;
                                default:
                                    break;
                            }
                            if (data != null && data.Length == reqLength)
                            {
                                //变量解析
                                foreach (var variable in gp.VarList)
                                {
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);

                                    int start = variable.Start - gp.Start;

                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            variable.VarValue = BitLib.GetBitFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }

                                    //处理
                                    //直接更新
                                    device.UpdateVariable(variable);
                                }
                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                        else
                        {
                            switch (gp.StoreArea)
                            {
                                case "输入寄存器":
                                    data = CommonMethods.modbus.ReadInputRegisters(gp.Start, gp.Length);
                                    reqLength = gp.Length * 2;
                                    break;
                                case "输出寄存器":
                                    data = CommonMethods.modbus.ReadOutputRegisters(gp.Start, gp.Length);
                                    reqLength = gp.Length * 2;
                                    break;
                                default:
                                    break;
                            }
                            if (data != null && data.Length == reqLength)
                            {
                                //变量解析
                                foreach (var variable in gp.VarList)
                                {
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);

                                    int start = variable.Start - gp.Start;

                                    start *= 2;

                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            variable.VarValue = BitLib.GetBitFrom2BytesArray(data, start, variable.OffsetOrLength, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA);
                                            break;
                                        case DataType.Byte:
                                            variable.VarValue = ByteLib.GetByteFromByteArray(data, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA ? start : start + 1);
                                            break;
                                        case DataType.Short:
                                            variable.VarValue = ShortLib.GetShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UShort:
                                            variable.VarValue = UShortLib.GetUShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Int:
                                            variable.VarValue = IntLib.GetIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UInt:
                                            variable.VarValue = UIntLib.GetUIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Float:
                                            variable.VarValue = FloatLib.GetFloatFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Double:
                                            variable.VarValue = DoubleLib.GetDoubleFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Long:
                                            variable.VarValue = LongLib.GetLongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.ULong:
                                            variable.VarValue = ULongLib.GetULongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.String:
                                            variable.VarValue = StringLib.GetStringFromByteArrayByEncoding(data, start, variable.OffsetOrLength, Encoding.ASCII);
                                            break;
                                        case DataType.ByteArray:
                                            variable.VarValue = ByteArrayLib.GetByteArrayFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        case DataType.HexString:
                                            variable.VarName = StringLib.GetHexStringFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }

                                    //处理
                                    //先做线性转换，再更新
                                    variable.VarValue = MigrationLib.GetMigrationValue(variable.VarValue, variable.Scale.ToString(), variable.Offset.ToString()).Content;

                                    device.UpdateVariable(variable);

                                }
                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    //非首次连接，需要延时
                    if (device.ReConnectSign)
                    {
                        CommonMethods.modbus?.DisConnet();
                        Thread.Sleep(device.ReConnectTime);
                    }

                    //通信连接
                    CommonMethods.modbus = new ModbusTCP();

                    device.IsConnected = CommonMethods.modbus.Connect(device.IPAddress, device.Port);

                    if (device.ReConnectSign)
                    {
                        CommonMethods.AddLog(device.IsConnected ? 0 : 1, device.IsConnected ? "控制器重新连接成功" : "控制器重新连接失败");
                    }
                    else
                    {
                        CommonMethods.AddLog(device.IsConnected ? 0 : 1, device.IsConnected ? "初次重连成功" : "初次重连失败");
                        device.ReConnectSign = true;
                    }
                }
            }
        }
    }
}
