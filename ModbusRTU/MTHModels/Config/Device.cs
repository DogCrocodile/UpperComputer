using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHModels
{
    /// <summary>
    /// 通信设备实体类
    /// </summary>
    public class Device
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 当前配方
        /// </summary>
        public string CurrentRecipe { get; set; }

        /// <summary>
        /// 通讯组集合
        /// </summary>
        public List<Group> GroupList { get; set; }

        /// <summary>
        /// 通信状态标志位
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// 重连时间
        /// </summary>
        public int ReConnectTime { get; set; } = 10;

        /// <summary>
        /// 重连标志位
        /// </summary>
        public bool ReConnectSign { get; set; }

        /// <summary>
        /// 所有变量的键值对，键使用变量的名称，值是变量的实际值
        /// </summary>
        public Dictionary<string, object> CurrentValue = new Dictionary<string, object>();

        /// <summary>
        /// 定义报警触发和消除的事件
        /// </summary>
        public event Action<bool, Variable> AlarmTrigEvent; 

        /// <summary>
        /// 更新变量
        /// </summary>
        /// <param name="variable"></param>
        public void UpdateVariable(Variable variable)
        {
            if(CurrentValue.ContainsKey(variable.VarName))
            {
                CurrentValue[variable.VarName] = variable.VarValue;
            }
            else
            {
                CurrentValue.Add(variable.VarName, variable.VarValue);
            }

            //报警检测
            CheckAlarm(variable);
        }

        private void CheckAlarm(Variable variable)
        {
            //上升沿报警检测
            if(variable.PosAlarm)
            {
                bool currentValue = variable.VarValue.ToString() == "True";

                if(variable.PosCacheValue == false && currentValue == true)
                {
                    //检测到了报警
                    AlarmTrigEvent?.Invoke(true, variable);
                }

                if (variable.PosCacheValue == true && currentValue == false)
                {
                    //检测到了报警消除
                    AlarmTrigEvent?.Invoke(false, variable);
                }
                variable.PosCacheValue = currentValue;               
            }

            //下降沿报警检测
            if (variable.NegAlarm)
            {
                bool currentValue = variable.VarValue.ToString() == "True";

                if (variable.NegCacheValue == true && currentValue == false)
                {
                    //检测到了报警
                    AlarmTrigEvent?.Invoke(true, variable);
                }

                if (variable.NegCacheValue == false && currentValue == true)
                {
                    //检测到了报警消除
                    AlarmTrigEvent?.Invoke(false, variable);
                }
                variable.NegCacheValue = currentValue;
            }
        }

        /// <summary>
        /// 索引器，获取变量当前的值,根据变量名称
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if(CurrentValue.ContainsKey(key))
                {
                    return CurrentValue[key];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
