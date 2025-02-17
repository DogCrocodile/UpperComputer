using ModbusRTULib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace WindowsFormsApp1
{
    public enum StoreArea
    {
        输出线圈0x,
        输入线圈1x,
        输出寄存器4x,
        输入寄存器3x
    }

    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            InitParam();
        }

        /// <summary>
        /// ModbusRTU对象
        /// </summary>
        private ModbusRTU modbusRTU = new ModbusRTU();

        private bool IsConnected;

        private DataFormat dataFormat = DataFormat.ABCD;

        private void InitParam()
        {
            string[] portList = SerialPort.GetPortNames();
            if(portList.Length > 0)
            {
                this.port_combox.Items.AddRange(portList);
                this.port_combox.SelectedIndex = 0;
            }

            this.baudRateCombox.Items.AddRange(new String[] { "2400", "4800", "9600","19200"});
            this.baudRateCombox.SelectedIndex = 2;

            //校验位
            this.parityCombox.DataSource = Enum.GetNames(typeof(Parity));
            this.parityCombox.SelectedIndex = 0;

            //停止位
            this.StopCombox.DataSource = Enum.GetNames(typeof(StopBits));
            this.StopCombox.SelectedIndex = 1;

            //数据位
            this.DataCombox.Items.AddRange(new String[] { "7", "8" });
            this.DataCombox.SelectedIndex = 0;

            //大小端
            this.DataFormatCombox.DataSource = Enum.GetNames(typeof(DataFormat));
            this.DataFormatCombox.SelectedIndex = 0;

            //存储区
            this.StoreAreaCombox.DataSource = Enum.GetNames(typeof(StoreArea));
            this.StoreAreaCombox.SelectedIndex = 0;

            //数据类型
            this.DataTypeCombox.DataSource = Enum.GetNames(typeof(DataType));
            this.DataTypeCombox.SelectedIndex = 0;

            //动态修改ListView第二列宽度
            this.data_list.Columns[1].Width = this.data_list.Width - this.data_list.Columns[0].Width;
        }

        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                AddLog("已连接。");
                return;
            }
            Parity parity = (Parity)Enum.Parse(typeof(Parity), this.parityCombox.Text, true);
            StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), this.StopCombox.Text, true);
            IsConnected =  modbusRTU.Connect(this.port_combox.Text, Convert.ToInt32(this.baudRateCombox.Text), parity, 
                Convert.ToInt32(this.DataCombox.Text), stopBits);
            if (IsConnected)
            {
                AddLog("Modbus连接成功。");
                return;
            }
            AddLog("Modbus连接失败。");
            return;
        }
        
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            modbusRTU.DisConnect();
            IsConnected = false;
            AddLog("Modbus断开连接。");
        }



        private void AddLog(string info)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            item.SubItems.Add(info);
            this.data_list.Items.Insert(0,item);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!CommonVerify()) return;

            byte salvedId = byte.Parse(this.address.Text.Trim());
            ushort startAddress = ushort.Parse(this.startAddress.Text.Trim());
            ushort textLength = ushort.Parse(this.textLength.Text.Trim());
            DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.DataTypeCombox.Text, true);
            StoreArea storeArea = (StoreArea)Enum.Parse(typeof(StoreArea), this.StoreAreaCombox.Text, true);
            dataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), this.DataFormatCombox.Text, true);

            switch (dataType)
            {
                case DataType.Bool:
                    ReadBool(storeArea, salvedId, startAddress, textLength);
                    break;
                case DataType.Byte:
                    ReadByte(storeArea, salvedId, startAddress, textLength);
                    break;
                case DataType.Short:
                    ReadShort(storeArea, salvedId, startAddress, textLength);
                    break;
                case DataType.UShort:
                    ReadUShort(storeArea, salvedId, startAddress, textLength);
                    break;
                case DataType.Int:
                    ReadInt(storeArea, salvedId, startAddress, textLength);
                    break;
                case DataType.UInt:
                    ReadUInt(storeArea, salvedId, startAddress, textLength);
                    break;
                case DataType.Float:
                    ReadFloat(storeArea, salvedId, startAddress, textLength);
                    break;
                case DataType.Double:
                case DataType.Long:
                case DataType.ULong:
                case DataType.String:
                case DataType.ByteArray:
                case DataType.HexString:
                    break;
            }
        }

        /// <summary>
        /// 读取布尔
        /// </summary>
        /// <param name="storeArea"></param>
        /// <param name="salveId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private void ReadBool(StoreArea storeArea, byte salveId, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                    result = modbusRTU.ReadOutputCoils(salveId, start, length);
                    break;
                case StoreArea.输入线圈1x:
                    result = modbusRTU.ReadInputCoils(salveId, start, length);
                    break;
                case StoreArea.输出寄存器4x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该存储区");
                    break;
            }
            if(result != null && result.Length > 0)
            {
                AddLog(string.Format("读取成功。{0}", StringLib.GetStringFromValueArray(BitLib.GetBitArrayFromByteArray(result, 0, length))));
            }
            else
            {
                AddLog("读取失败，请重试。");
            }
        }

        /// <summary>
        /// 读取字节
        /// </summary>
        /// <param name="storeArea"></param>
        /// <param name="salveId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private void ReadByte(StoreArea storeArea, byte salveId, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                    result = modbusRTU.ReadOutputCoils(salveId, start, length);
                    break;
                case StoreArea.输入线圈1x:
                    result = modbusRTU.ReadInputCoils(salveId, start, length);
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbusRTU.ReadOutputRegisters(salveId, start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbusRTU.ReadInputRegisters(salveId, start, length);
                    break;
            }
            if (result != null && result.Length > 0)
            {
                AddLog(string.Format("读取成功。{0}", result));
            }
            else
            {
                AddLog("读取失败，请重试。");
            }
        }

        /// <summary>
        /// 读取Short
        /// </summary>
        /// <param name="storeArea"></param>
        /// <param name="salveId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private void ReadShort(StoreArea storeArea, byte salveId, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog("不支持该存储区");
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbusRTU.ReadOutputRegisters(salveId, start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbusRTU.ReadInputRegisters(salveId, start, length);
                    break;
            }
            if (result != null && result.Length > 0)
            {
                AddLog(string.Format("读取成功。{0}", StringLib.GetStringFromValueArray(ShortLib.GetShortArrayFromByteArray(result))));
            }
            else
            {
                AddLog("读取失败，请重试。");
            }
        }

        /// <summary>
        /// 读取UShort
        /// </summary>
        /// <param name="storeArea"></param>
        /// <param name="salveId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private void ReadUShort(StoreArea storeArea, byte salveId, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog("不支持该存储区");
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbusRTU.ReadOutputRegisters(salveId, start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbusRTU.ReadInputRegisters(salveId, start, length);
                    break;
            }
            if (result != null && result.Length > 0)
            {
                AddLog(string.Format("读取成功。{0}", StringLib.GetStringFromValueArray(UShortLib.GetUShortArrayFromByteArray(result))));
            }
            else
            {
                AddLog("读取失败，请重试。");
            }
        }

        /// <summary>
        /// 读取Int
        /// </summary>
        /// <param name="storeArea"></param>
        /// <param name="salveId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private void ReadInt(StoreArea storeArea, byte salveId, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog("不支持该存储区");
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbusRTU.ReadOutputRegisters(salveId, start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbusRTU.ReadInputRegisters(salveId, start, (ushort)(length * 2));
                    break;
            }
            if (result != null && result.Length > 0)
            {
                AddLog(string.Format("读取成功。{0}", StringLib.GetStringFromValueArray(IntLib.GetIntArrayFromByteArray(result))));
            }
            else
            {
                AddLog("读取失败，请重试。");
            }
        }

        /// <summary>
        /// 读取UInt
        /// </summary>
        /// <param name="storeArea"></param>
        /// <param name="salveId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private void ReadUInt(StoreArea storeArea, byte salveId, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog("不支持该存储区");
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbusRTU.ReadOutputRegisters(salveId, start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbusRTU.ReadInputRegisters(salveId, start, (ushort)(length * 2));
                    break;
            }
            if (result != null && result.Length > 0)
            {
                AddLog(string.Format("读取成功。{0}", StringLib.GetStringFromValueArray(UIntLib.GetUIntArrayFromByteArray(result))));
            }
            else
            {
                AddLog("读取失败，请重试。");
            }
        }

        /// <summary>
        /// 读取Float
        /// </summary>
        /// <param name="storeArea"></param>
        /// <param name="salveId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private void ReadFloat(StoreArea storeArea, byte salveId, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog("不支持该存储区");
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbusRTU.ReadOutputRegisters(salveId, start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbusRTU.ReadInputRegisters(salveId, start, (ushort)(length * 2));
                    break;
            }
            if (result != null && result.Length > 0)
            {
                AddLog(string.Format("读取成功。{0}", StringLib.GetStringFromValueArray(FloatLib.GetFloatArrayFromByteArray(result))));
            }
            else
            {
                AddLog("读取失败，请重试。");
            }
        }
        #region
        private bool CommonVerify()
        {
            if (!IsConnected)
            {
                AddLog("请确认连接是否正常。");
                return false;
            }
            if(!byte.TryParse(this.address.Text, out _))
            {
                AddLog("请确认站地址是否正确。");
                return false;
            }
            if(!ushort.TryParse(this.startAddress.Text, out _))
            {
                AddLog("请确认起始地址是否正确。");
                return false;
            }
            if (!ushort.TryParse(this.textLength.Text, out _))
            {
                AddLog("请确认长度是否正确。");
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 写入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (!CommonVerify()) return;

            byte salvedId = byte.Parse(this.address.Text.Trim());
            ushort startAddress = ushort.Parse(this.startAddress.Text.Trim());
            //ushort textLength = ushort.Parse(this.textLength.Text.Trim());
            DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.DataTypeCombox.Text, true);
            StoreArea storeArea = (StoreArea)Enum.Parse(typeof(StoreArea), this.StoreAreaCombox.Text, true);
            dataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), this.DataFormatCombox.Text, true);
            String wirteValue = this.text_wirte.Text.Trim();

            switch (dataType)
            {
                case DataType.Bool:
                    WirteBool(storeArea, salvedId, startAddress, wirteValue);
                    break;
                case DataType.Byte:
                    WirteByte(storeArea, salvedId, startAddress, wirteValue);
                    break;
                case DataType.Short:
                    WirteShort(storeArea, salvedId, startAddress, wirteValue);
                    break;
                case DataType.UShort:
                    WirteUShort(storeArea, salvedId, startAddress, wirteValue);
                    break;
                case DataType.Int:
                    WirteInt(storeArea, salvedId, startAddress, wirteValue);
                    break;
                case DataType.UInt:
                    WirteUInt(storeArea, salvedId, startAddress, wirteValue);
                    break;
                case DataType.Float:
                    WirteFloat(storeArea, salvedId, startAddress, wirteValue);
                    break;
                case DataType.Double:
                case DataType.Long:
                case DataType.ULong:
                case DataType.String:
                case DataType.ByteArray:
                case DataType.HexString:
                    break;
            }
        }

        /// <summary>
        /// 写入bool
        /// </summary>
        private bool WirteBool(StoreArea storeArea, byte salveId, ushort start, string setValue)
        {
            bool result = false;
            switch (storeArea)
            {
                case StoreArea.输入线圈1x:
                    bool[] values = BitLib.GetBitArrayFromBitArrayString(setValue);
                    if(values.Length == 1)
                    {
                        result = modbusRTU.PreSetSingleCoil(salveId, start, values[0]);
                    }
                    else
                    {
                        result = modbusRTU.PreSetMultiCoils(salveId, start, values);
                    }
                    break;
                case StoreArea.输出线圈0x:
                case StoreArea.输出寄存器4x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该类型");
                    break;
            }
            if (result)
            {
                AddLog("写入成功");
            }
            else
            {
                AddLog("写入失败");
            }
            return result;
        }

        /// <summary>
        /// 写入字节
        /// </summary>
        private bool WirteByte(StoreArea storeArea, byte salveId, ushort start, string setValue)
        {
            bool result = false;
            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    result = modbusRTU.PreSetMultiRegisters(salveId, start, ByteArrayLib.GetByteArrayFromHexString(setValue));
                    break;
                case StoreArea.输入线圈1x:
                case StoreArea.输出线圈0x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该类型");
                    break;
            }
            if (result)
            {
                AddLog("写入成功");
            }
            else
            {
                AddLog("写入失败");
            }
            return result;
        }

        /// <summary>
        /// 写入Short
        /// </summary>
        private bool WirteShort(StoreArea storeArea, byte salveId, ushort start, string setValue)
        {
            bool result = false;
            short[] values = ShortLib.GetShortArrayFromString(setValue);
            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    if(values.Length == 1)
                    {
                        result = modbusRTU.PreSetSingleRegister(salveId, start, values[0]);
                    }
                    else
                    {
                        result = modbusRTU.PreSetMultiRegisters(salveId, start, ByteArrayLib.GetByteArrayFromShortArray(values));
                    }
                        
                    break;
                case StoreArea.输入线圈1x:
                case StoreArea.输出线圈0x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该类型");
                    break;
            }
            if (result)
            {
                AddLog("写入成功");
            }
            else
            {
                AddLog("写入失败");
            }
            return result;
        }

        /// <summary>
        /// 写入UShort
        /// </summary>
        private bool WirteUShort(StoreArea storeArea, byte salveId, ushort start, string setValue)
        {
            bool result = false;
            ushort[] values = UShortLib.GetUShortArrayFromString(setValue);
            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    if (values.Length == 1)
                    {
                        result = modbusRTU.PreSetSingleRegister(salveId, start, values[0]);
                    }
                    else
                    {
                        result = modbusRTU.PreSetMultiRegisters(salveId, start, ByteArrayLib.GetByteArrayFromUShortArray(values));
                    }

                    break;
                case StoreArea.输入线圈1x:
                case StoreArea.输出线圈0x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该类型");
                    break;
            }
            if (result)
            {
                AddLog("写入成功");
            }
            else
            {
                AddLog("写入失败");
            }
            return result;
        }

        /// <summary>
        /// 写入UShort
        /// </summary>
        private bool WirteInt(StoreArea storeArea, byte salveId, ushort start, string setValue)
        {
            bool result = false;
            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    int[] values = IntLib.GetIntArrayFromString(setValue);
                    result = modbusRTU.PreSetMultiRegisters(salveId, start, ByteArrayLib.GetByteArrayFromIntArray(values));
                    break;
                case StoreArea.输入线圈1x:
                case StoreArea.输出线圈0x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该类型");
                    break;
            }
            if (result)
            {
                AddLog("写入成功");
            }
            else
            {
                AddLog("写入失败");
            }
            return result;
        }

        /// <summary>
        /// 写入UShort
        /// </summary>
        private bool WirteUInt(StoreArea storeArea, byte salveId, ushort start, string setValue)
        {
            bool result = false;
            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    uint[] values = UIntLib.GetUIntArrayFromString(setValue);
                    result = modbusRTU.PreSetMultiRegisters(salveId, start, ByteArrayLib.GetByteArrayFromUIntArray(values));
                    break;
                case StoreArea.输入线圈1x:
                case StoreArea.输出线圈0x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该类型");
                    break;
            }
            if (result)
            {
                AddLog("写入成功");
            }
            else
            {
                AddLog("写入失败");
            }
            return result;
        }

        /// <summary>
        /// 写入UShort
        /// </summary>
        private bool WirteFloat(StoreArea storeArea, byte salveId, ushort start, string setValue)
        {
            bool result = false;
            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    float[] values = FloatLib.GetFloatArrayFromString(setValue);
                    result = modbusRTU.PreSetMultiRegisters(salveId, start, ByteArrayLib.GetByteArrayFromFloatArray(values));
                    break;
                case StoreArea.输入线圈1x:
                case StoreArea.输出线圈0x:
                case StoreArea.输入寄存器3x:
                    AddLog("不支持该类型");
                    break;
            }
            if (result)
            {
                AddLog("写入成功");
            }
            else
            {
                AddLog("写入失败");
            }
            return result;
        }
    }
}