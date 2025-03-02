using ModbusTCPLib;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace MTHProject
{
    public class CommonMethods
    {
        //创建一个设备对象
        public static Device Device { get; set; }

        /// <summary>
        /// 创建一个静态的系统委托对象
        /// </summary>
        public static Action<int, string> AddLog;

        /// <summary>
        /// ModbusTCP通信对象
        /// </summary>
        public static ModbusTCP modbus { get; set; }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        //public static SysAdmin CurrentAdmin { get; set; }

        /// <summary>
        /// 确定大小端
        /// </summary>
        public static DataFormat dataFormat = DataFormat.ABCD;

        /// <summary>
        /// 通过标签名称找相对于的Variable对象
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        private static Variable FindVariable(string varName)
        {
            foreach (var item in Device.GroupList)
            {
                var res = item.VarList.Find(c => c.VarName == varName);

                if(res != null)
                {
                    return res;
                }              
            }
            return null;
        }

        /// <summary>
        /// 通用写入的方法
        /// </summary>
        /// <param name="varName">变量名称</param>
        /// <param name="varValue">变量值</param>
        /// <returns>写入是否成功</returns>
        public static bool CommonWrite(string varName, string varValue)
        {
            var variable = FindVariable(varName);

            //第一步:先找到变量对象
            if (variable != null)
            {
                //第二步：获取变量类型
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType,true);

                //第三步：获取写入的数据
                var result = MigrationLib.SetMigrationValue(varValue,dataType,variable.Scale.ToString(),variable.Offset.ToString());

                if (result.IsSuccess)
                {
                    //第四步:写入数据
                    try
                    {
                        switch (dataType)
                        {
                            case DataType.Bool:
                                return modbus.PreSetSingleCoil(variable.Start, Convert.ToBoolean(result.Content));
                            case DataType.Short:
                                return modbus.PreSetSingleRegister(variable.Start, Convert.ToInt16(result.Content));
                            case DataType.UShort:
                                return modbus.PreSetSingleRegister(variable.Start, Convert.ToUInt16(result.Content));
                            case DataType.Int:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromInt(Convert.ToInt32(result.Content), dataFormat));
                            case DataType.UInt:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromUInt(Convert.ToUInt32(result.Content), dataFormat));
                            case DataType.Float:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromFloat(Convert.ToSingle(result.Content), dataFormat));
                            case DataType.Double:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromDouble(Convert.ToDouble(result.Content), dataFormat));
                            case DataType.Long:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromLong(Convert.ToInt64(result.Content), dataFormat));
                            case DataType.ULong:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromULong(Convert.ToUInt64(result.Content), dataFormat));
                            case DataType.String:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromString(result.Content, Encoding.ASCII));
                            case DataType.ByteArray:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromHexString(result.Content));
                            case DataType.HexString:
                                return modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromHexString(result.Content));
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

            }
            return false;
        }

    }
}
