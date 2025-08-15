using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmExtension.Standard.Extensions;
using System.Threading;


namespace alarm_system
{
    public  class DigitalTubeHelper
    {
        private     ModbusMaster ModbusMaster;//主站对象

        public byte Slave { get; set; }

        //构造函数，初始化modbus主站和从站的地址
        public DigitalTubeHelper(ModbusMaster modbusMaster, byte slave)
        {
            ModbusMaster = modbusMaster;//赋值modbus主站
            Slave = slave;//赋值从站地址
        }
        //设置显示值的方法
        public void SetValue(double value, char perfix)
        {
            //查找小数点在字符串中的索引
            var dotIndex = value.ToString().Reverse().IndexOf('.');
            if (dotIndex == -1)
            {
                dotIndex = 0;
            }
            var sign=value <0?1:0;
            ushort intValue = value.ToString().Replace(".", "").ToUShort();
            byte[] bytes = new byte[4];
            bytes[1]= (byte)((sign << 4) | dotIndex);
            var b =BitConverter .GetBytes(intValue);//只有俩个字节
            bytes[2]= b[0];
            bytes[3]=b[1];
            ModbusMaster.WriteMultipleRegisters(Slave, 6, new ushort[]
            {
            bytes.ToUShort(),
            bytes.ToUShort (2),
            });
            Thread .Sleep (4);//等待400ms
            ModbusMaster.WriteSingleRegister (Slave,0, perfix);
        }
    }
}
