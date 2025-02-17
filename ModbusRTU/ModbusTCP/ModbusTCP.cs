using ModbusTCPLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModbusTCPLib
{
    public class ModbusTCP
    {

        public Socket socket;

        /// <summary>
        /// 发送超时时间
        /// </summary>
        public int SendTimeOut { get; set; } = 2000;

        /// <summary>
        /// 接收超时时间
        /// </summary>
        public int ReceiveTimeOut { get; set; } = 2000;

        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public bool Connect(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.SendTimeout = SendTimeOut;
            socket.ReceiveTimeout = ReceiveTimeOut;

            try
            {
                if(IPAddress.TryParse(ip, out IPAddress iPAddress))
                {
                    socket.Connect(iPAddress, port);
                }
                else
                {
                    socket.Connect(ip, port);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;        
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnet()
        {
            this.socket?.Close();
        }

        private SimpleHyBirdLock simpleHyBirdLock = new SimpleHyBirdLock();

        /// <summary>
        /// 延时时间
        /// </summary>
        public int SleepTime { get; set; } = 1;

        /// <summary>
        /// 尝试次数
        /// </summary>
        public int MaxWaitTime { get; set; } = 10;

        /// <summary>
        /// 单元标识符
        /// </summary>
        public byte slavedId { get; set; } = 0x01;

        #region 发送接收方法
        /// <summary>
        /// 发送接收方法
        /// </summary>
        /// <param name="send">发送内容</param>
        /// <param name="receive">接收内容</param>
        /// <returns></returns>
        private bool SendAndReceive(byte[] send, ref byte[] receive) 
        {
            simpleHyBirdLock.Enter();

            byte[] buffer = new byte[1024];
            MemoryStream ms = new MemoryStream();
            try
            {
                socket.Send(send, send.Length, SocketFlags.None);
                int timer = 0;

                while (true)
                {
                    Thread.Sleep(SleepTime);

                    if (socket.Available > 0)
                    {
                        int count = socket.Receive(buffer, SocketFlags.None);
                        ms.Write(buffer, 0, count);
                    }
                    else
                    {
                        timer++;
                        if (ms.Length > 0)
                        {
                            break;
                        }
                        else if (timer > MaxWaitTime)
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
        #endregion

        #region 01H读取输出线圈
        /// <summary>
        /// 读取输出线圈
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadOutputCoils(ushort start, ushort length)
        {
            //拼接报文
            ByteArray sendCommand = new ByteArray();
            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始线圈 +线圈长度
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度 +单元标识符
            sendCommand.Add(0x00, 0x06, slavedId, 0x01);
            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add(length);

            byte[] receive = null;
            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;
            
            if(SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == slavedId && receive[7] == 0x01 && receive[8] == byteLength)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return receive;
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
        public byte[] ReadInputCoils(ushort start, ushort length)
        {
            //拼接报文
            ByteArray sendCommand = new ByteArray();
            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始线圈 +线圈长度
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度 +单元标识符
            sendCommand.Add(0x00, 0x06, slavedId, 0x02);
            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add(length);

            byte[] receive = null;
            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;

            if (SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == slavedId && receive[7] == 0x02 && receive[8] == byteLength)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return receive;
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
        public byte[] ReadOutputRegisters(ushort start, ushort length)
        {
            //拼接报文
            ByteArray sendCommand = new ByteArray();
            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始寄存器地址 +寄存器长度
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度 +单元标识符
            sendCommand.Add(0x00, 0x06, slavedId, 0x03);
            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add(length);

            //2.发送报文
            //3.接受报文
            int byteLength = length * 2;
            byte[] receive = null;
            if (SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == slavedId && receive[7] == 0x03 && receive[8] == byteLength)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 04H读取输入寄存器
        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadInputRegisters(ushort start, ushort length)
        {
            //拼接报文
            ByteArray sendCommand = new ByteArray();
            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始寄存器地址 +寄存器长度
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度 +单元标识符
            sendCommand.Add(0x00, 0x06, slavedId, 0x04);
            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add(length);

            //2.发送报文
            //3.接受报文
            int byteLength = length * 2;
            byte[] receive = null;
            if (SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == slavedId && receive[7] == 0x04 && receive[8] == byteLength)
                    {
                        //5.解析报文
                        byte[] result = new byte[byteLength];
                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 05H预置单线圈
        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public bool PreSetSingleCoil(ushort start, bool value)
        {
            //拼接报文
            ByteArray sendCommand = new ByteArray();
            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始线圈地址 +线圈值
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度 +单元标识符
            sendCommand.Add(0x00, 0x06, slavedId, 0x05);
            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add((byte)(value? 0xFF:0x00));
            sendCommand.Add((byte)(0x00));

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                if (receive.Length == 12)
                {
                    return ByteArrayEquals(sendCommand.Array, receive);
                }
            }
            return false;
        }
        #endregion

        #region 06H预置单寄存器
        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public bool PreSetSingleRegister(ushort start, byte[] value)
        {
            //拼接报文
            ByteArray sendCommand = new ByteArray();
            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始寄存器地址 +寄存器值
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度 +单元标识符
            sendCommand.Add(0x00, 0x06, slavedId, 0x06);
            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add(value);

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                if (receive.Length == 12)
                {
                    return ByteArrayEquals(sendCommand.Array, receive);
                }
            }
            return false;
        }

        public bool PreSetSingleRegister(ushort start, short value)
        {
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }

        public bool PreSetSingleRegister(ushort start, ushort value)
        {
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }
        #endregion

        #region 0FH预置多线圈
        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public bool PreSetMultiCoils(ushort start, bool[] values)
        {
            //拼接报文
            ByteArray sendCommand = new ByteArray();

            byte[] setArray = GetByteArrayFromBoolArray(values);
            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始线圈地址+ 线圈数量 +字节计数 + 值
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度
            sendCommand.Add((short)(7+setArray.Length));
            //单元标识符 + 功能码
            sendCommand.Add(slavedId, 0xFf);

            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add((short)(values.Length));
            sendCommand.Add((short)(setArray.Length));
            sendCommand.Add(setArray);

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                byte[] send = new byte[12];
                Array.Copy(sendCommand.Array, 0, send, 0, 12);
                send[4] = 0x00;
                send[5] = 0x06;

                return ByteArrayEquals(send, receive);
            }
            return false;
        }
        #endregion

        #region 0FH预置多寄存器
        /// <summary>
        /// 预置多寄存器
        /// </summary>
        /// <param name="slaveId">站地址</param>
        /// <param name="start">起始地址</param>
        /// <param name="length">读取长度</param>
        /// <returns>返回数据</returns>
        public bool PreSetMultiRegisters(ushort start, byte[] values)
        {
            if (values?.Length % 2 == 1) return false;
            //拼接报文
            ByteArray sendCommand = new ByteArray();

            //事务处理标识符 +协议标识符 +长度+ 单元标识符 +功能码 +起始线圈地址+ 线圈数量 +字节计数 + 值
            sendCommand.Add(0x00, 0x00, 0x00, 0x00);
            //长度
            sendCommand.Add((short)(7 + values.Length));
            //单元标识符 + 功能码
            sendCommand.Add(slavedId, 0x10);

            //起始线圈 +线圈长度
            sendCommand.Add(start);
            sendCommand.Add((short)(values.Length/2));
            sendCommand.Add((short)(values.Length));
            sendCommand.Add(values);

            //2.发送报文
            //3.接受报文
            byte[] receive = null;
            if (SendAndReceive(sendCommand.Array, ref receive))
            {
                //4.验证报文
                byte[] send = new byte[12];
                Array.Copy(sendCommand.Array, 0, send, 0, 12);
                send[4] = 0x00;
                send[5] = 0x06;

                return ByteArrayEquals(send, receive);
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
            if (b1 == null || b2 == null)
            {
                return false;
            }
            if (b1.Length != b2.Length) return false;

            return BitConverter.ToString(b1) == BitConverter.ToString(b2);
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
            for (int i = 0; i < result.Length; i++)
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
