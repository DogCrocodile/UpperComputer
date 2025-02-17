using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModbusRTULib
{
    public class ModbusRTU
    {
        //.net提供的串口通信对象
        private SerialPort serialPort;

        /// <summary>
        /// 读取超时时间
        /// </summary>
        private int ReadTimeOut { get; set; } = 2000;

        /// <summary>
        /// 写入超时时间
        /// </summary>
        private int WriteTimeOUt { get; set; } = 3000;

        private bool dtrEnable = false;

        /// <summary>
        /// Dtr使用标识
        /// </summary>
        public bool DtrEnable
        {
            get { return dtrEnable; }
            set
            {
                dtrEnable = value;
                this.serialPort.DtrEnable = dtrEnable;
            }
        }

        private bool rtsEnable;
        /// <summary>
        /// RTS使用标识
        /// </summary>
        public bool RtsEnable
        {
            get { return rtsEnable; }
            set
            {
                rtsEnable = value;
                this.serialPort.RtsEnable = rtsEnable;
            }
        }
        
        /// <summary>
        /// 最大的接受数据等待时间
        /// </summary>
        public int ReceiveTimeOut { get; set; } = 5000;

        public ModbusRTU()
        {
            serialPort = new SerialPort();
        }

        #region
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="portName">串口号</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">校验位</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        /// <returns>是否成功</returns>
        public bool Connect(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            if(serialPort?.IsOpen ?? false)
            {
                serialPort.Close();
            }

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.Parity = parity;
            serialPort.DataBits = dataBits;
            serialPort.StopBits = stopBits;
            serialPort.ReadTimeout = ReadTimeOut;
            serialPort.WriteTimeout = WriteTimeOUt;

            try
            {
                serialPort.Open();
            }
            catch (Exception)
            {
                return false;
            }

            return serialPort.IsOpen;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            if (serialPort?.IsOpen ?? false)
            {
                serialPort.Close();
            }
        }
        #endregion

        #region 01H读取输出线圈
        /// <summary>
        /// 读取输出线圈
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadOutputCoils(byte slaveId, ushort start, ushort length)
        {
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();
            //从站地址 + 功能码 + 起始地址 +读取线圈数据 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X01);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.Add((byte)(length / 256));
            sendCommand.Add((byte)(length % 256));

            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;
            byte[] receive = null;
            if(SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if(CheckCRC(receive) && receive.Length == 5 + byteLength && receive[2] == byteLength)
                {
                    if (receive[0] == slaveId && receive[1] == 0x01)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 3, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 02H读取输入线圈
        /// <summary>
        /// 读取输出线圈
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadInputCoils(byte slaveId, ushort start, ushort length)
        {
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();
            //从站地址 + 功能码 + 起始地址 +读取线圈数据 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X02);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.Add((byte)(length / 256));
            sendCommand.Add((byte)(length % 256));

            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;
            byte[] receive = null;
            if (SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if (CheckCRC(receive) && receive.Length == 5 + byteLength)
                {
                    if (receive[0] == slaveId && receive[1] == 0x02 && receive[2] == byteLength)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 3, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 03H读取保持寄存器
        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadOutputRegisters(byte slaveId, ushort start, ushort length)
        {
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();
            //从站地址 + 功能码 + 起始地址 +读取线圈数据 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X03);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.Add((byte)(length / 256));
            sendCommand.Add((byte)(length % 256));

            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            int byteLength = length * 2;
            byte[] receive = null;
            if (SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if (CheckCRC(receive) && receive.Length == 5 + byteLength)
                {
                    if (receive[0] == slaveId && receive[1] == 0x03 && receive[2] == byteLength)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 3, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 04H读取写入寄存器
        /// <summary>
        /// 读取写入寄存器
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadInputRegisters(byte slaveId, ushort start, ushort length)
        {
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();
            //从站地址 + 功能码 + 起始地址 +读取线圈数据 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X03);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.Add((byte)(length / 256));
            sendCommand.Add((byte)(length % 256));

            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            int byteLength = length * 2;
            byte[] receive = null;
            if (SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if (CheckCRC(receive) && receive.Length == 5 + byteLength)
                {
                    if (receive[0] == slaveId && receive[1] == 0x04 && receive[2] == byteLength)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 3, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 05预置单线圈
        public bool PreSetSingleCoil(byte slaveId, ushort start, bool value)
        {
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();
            //从站地址 + 功能码 + 起始地址 +写入线圈值 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X05);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.Add((byte)(value?0xff:0x00));
            sendCommand.Add(0x00);

            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if (CheckCRC(receive) && receive.Length == 8)
                {
                    return ByteArrayEquals(sendCommand.ToArray(), receive);
                }
            }
            return false;
        }
        #endregion

        #region 06预置单寄存器
        public bool PreSetSingleRegister(byte slaveId, ushort start, byte[] value)
        {
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();
            //从站地址 + 功能码 + 起始地址 +写入寄存器值 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X06);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.AddRange(value);

            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if (CheckCRC(receive) && receive.Length == 8)
                {
                    return ByteArrayEquals(sendCommand.ToArray(), receive);
                }
            }
            return false;
        }

        public bool PreSetSingleRegister(byte slaveId, ushort start, short value)
        {
            return PreSetSingleRegister(slaveId, start, BitConverter.GetBytes(value).Reverse().ToArray());
        }

        public bool PreSetSingleRegister(byte slaveId, ushort start, ushort value)
        {
            return PreSetSingleRegister(slaveId, start, BitConverter.GetBytes(value).Reverse().ToArray());
        }
        #endregion

        #region 0FH预置多线圈
        public bool PreSetMultiCoils(byte slaveId, ushort start, bool[] value)
        {
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();

            byte[] setArray = GetByteArrayFromBoolArray(value);
            //从站地址 + 功能码 + 起始地址 + 数量 + 字节计数 + 写入值 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X0F);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.Add((byte)(value.Length / 256));
            sendCommand.Add((byte)(value.Length % 256));

            sendCommand.Add((byte)(setArray.Length));

            sendCommand.AddRange(setArray);
            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if (CheckCRC(receive) && receive.Length == 8)
                {
                    //验证发送和接收的前6个字节是否相同
                    for (int i = 0; i < 6; i++)
                    {
                        if (receive[i] != sendCommand[i])
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region 10H预置多寄存器
        public bool PreSetMultiRegisters(byte slaveId, ushort start, byte[] values)
        {
            if (values?.Length % 2 == 1) return false;
            //1.拼接报文
            List<byte> sendCommand = new List<byte>();
            int registerLength = values.Length / 2;
            //从站地址 + 功能码 + 起始地址 + 数量 + 字节计数 + 写入值 + CRC验证
            sendCommand.Add(slaveId);
            sendCommand.Add(0X0F);
            //起始地址 占2个字节 需要区分高低位
            sendCommand.Add((byte)(start / 256));
            sendCommand.Add((byte)(start % 256));

            //读取长度 占2个字节 需要区分高低位
            sendCommand.Add((byte)(registerLength / 256));
            sendCommand.Add((byte)(values.Length % 256));

            sendCommand.Add((byte)(values.Length));

            sendCommand.AddRange(values);
            //CRC检验 查表法
            byte[] crc = Crc16(sendCommand.ToArray(), sendCommand.Count);
            sendCommand.AddRange(crc);

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceived(sendCommand.ToArray(), ref receive))
            {
                //4.验证报文
                if (CheckCRC(receive) && receive.Length == 8)
                {
                    //验证发送和接收的前6个字节是否相同
                    for (int i = 0; i < 6; i++)
                    {
                        if (receive[i] != sendCommand[i])
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 判断两个数组是否相同
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        private bool ByteArrayEquals(byte[] b1, byte[] b2)
        {
            if(b1 == null || b2 == null)
            {
                return false;
            }
            if (b1.Length != b2.Length) return false;

            return b1.ToString() == b2.ToString();
        }

        /// <summary>
        /// bool数组转byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private byte[] GetByteArrayFromBoolArray(bool[] value)
        {
            int byteLength = value.Length % 8 == 0 ? value.Length / 8 : value.Length / 8 + 1;
            byte[] result = new byte[byteLength];
            for(int i = 0; i < result.Length; i++)
            {
                int total = value.Length < 8 * (i + 1) ? value.Length - 8 * i : 8;
                for (int j = 0; j < total; j++)
                {
                    result[j] = SetBitValue(result[i], j, value[8 * i + 1]);
                }
            }
            return result;
        }

        /// <summary>
        /// 将某个字节的某个位置位或复位
        /// </summary>
        /// <param name="src"></param>
        /// <param name="bit"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private byte SetBitValue(byte src, int bit, bool value)
        {
            return value ? (byte)(src | (byte)Math.Pow(2, bit)) : (byte)(src & ~(byte)Math.Pow(2, bit));
        }

        private SimpleHyBirdLock simpleHyBirdLock = new SimpleHyBirdLock();
        /// <summary>
        /// 发送并接收
        /// </summary>
        /// <param name="send"></param>
        /// <param name="receive"></param>
        /// <returns></returns>
        private bool SendAndReceived(byte[] send, ref byte[] receive)
        {
            this.serialPort.Write(send, 0, send.Length);
            byte[] buffer = new byte[1024];
            MemoryStream ms = new MemoryStream();

            //超时用
            DateTime start = DateTime.Now;
            simpleHyBirdLock.Enter();
            try
            {
                while (true)
                {
                    Thread.Sleep(10);
                    if(this.serialPort.BytesToRead > 0)
                    {
                        int count = this.serialPort.Read(buffer, 0, buffer.Length);
                        ms.Write(buffer, 0, count);
                    }
                    else
                    {
                        if(ms.Length > 0)
                        {
                            break;
                        }
                        if((DateTime.Now - start).TotalMilliseconds > this.ReceiveTimeOut)
                        {
                            return false;
                        }
                    }
                }
                receive = ms.ToArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                simpleHyBirdLock.Leave();
            }
        }

        //CRC检验
        private static byte[] aucCRCHi = new byte[]//crc高位表  
        {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
            0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
            0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
            0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
            0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40
        };

        private static byte[] aucCRCLo = new byte[]//crc低位表  
        {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06,
            0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD,
            0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A,
            0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4,
            0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3,
            0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4,
            0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29,
            0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED,
            0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60,
            0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67,
            0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68,
            0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E,
            0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71,
            0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92,
            0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B,
            0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B,
            0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42,
            0x43, 0x83, 0x41, 0x81, 0x80, 0x40
        };

        private byte[] Crc16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            byte[] res = new byte[] { 0xff, 0xFF };
            ushort iIndex;
            while (usLen-- > 0)
            {
                iIndex = (ushort)(res[0] ^ pucFrame[i++]);
                res[0] = (byte)(res[1] ^ aucCRCHi[iIndex]);
                res[1] = aucCRCLo[iIndex];
            }
            return res;
        }

        private bool CheckCRC(byte[] value)
        {
            if (value == null) return false;

            if (value.Length <= 2) return false;

            int length = value.Length;
            byte[] buf = new byte[length - 2];
            Array.Copy(value, 0, buf, 0, buf.Length);

            byte[] CRCbuf = Crc16(buf, buf.Length);
            if (CRCbuf[0] == value[length - 2] && CRCbuf[1] == value[length - 1])
            {
                return true;
            }
            return false;
        }
    }
    public sealed class SimpleHyBirdLock : IDisposable
    {
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        private bool disposedValue = false;//检测冗余调用
        public void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //TODO：释放托管状态
                }
                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                m_waiterLock.Close();
                disposedValue = true;
            }

        }

        //基元用户模式构造
        private int m_waiters = 0;
        //基元内核模式构造
        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        public void Enter()
        {
            if (Interlocked.Increment(ref m_waiters) == 1) return;//用户锁可以使用的时候，直接返回，第一次调用时发生
            //当发生锁竞争时，使用内核同步构造锁
            m_waiterLock.WaitOne();
        }

        public void Leave()
        {

            if (Interlocked.Decrement(ref m_waiters) == 0) return;//没有可用的锁的时候
            m_waiterLock.Set();

        }

        /// <summary>
        /// 当前锁是否在线程中
        /// </summary>
        public bool IsWaiting => m_waiters != 0;
    }
}
