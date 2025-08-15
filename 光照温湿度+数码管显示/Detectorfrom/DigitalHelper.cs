using HmExtension.Standard.Extensions;
using HZH_Controls;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Modbus.Extensions.Enron;

namespace Detectorfrom
{
    public  class DigitalHelper
    {

        private ModbusMaster _modbusMaster;
        private byte _salve;

        public DigitalHelper(SerialPort serialPort, byte salve)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            //ModbusSerialMaster表示串口主机
            //CreateRtu表示创建RTU模式的ModBus协议
            _modbusMaster = ModbusSerialMaster.CreateRtu(serialPort);
            this._salve = salve;//从机地址
        }

        //索引器
        public char this[ushort index]
        {
            get => GetDigitalvalue(index);
        }


        public char GetDigitalvalue(ushort index)
        {
            //读取寄存器
            var value = _modbusMaster.ReadHoldingRegisters(_salve, index, 1).FirstOrDefault();
            return (char)BitConverter.GetBytes(value)[0];
        }

        //获取小数点
        public int GetDot()
        {
            return _modbusMaster.ReadHoldingRegisters(_salve, 16, 1).FirstOrDefault();
        }
        #region 写数据
        //写数据
        public void SetNumber(double number)//一次不能写入多个寄存器，所以要分批去写
        {
            //符号
            var symbol = number < 0 ? 1 : 0;//=>0000_0001

            //小数点
            var dot = new string($"{number}".Reverse().ToArray()).IndexOf(".");
            if (dot == -1) dot = 0;


            //值
            var value = $"{number}".Replace(".", "").Replace("-", "").ToInt();//新版本的那个转记得

            var v = 0;

            v |= symbol << 28;
            v |= dot << 24;
            v |= value;
           
            var bytes = BitConverter.GetBytes(v).Reverse().ToArray();
            #region 分批次写入
            //定义每次写入寄存器的数量
            const int maxRegistersPerwrite = 127 / 2;
            //分批写入
            for (int i = 0; i < bytes.Length; i += maxRegistersPerwrite * 2)

            {
                int end = Math.Min(i + maxRegistersPerwrite * 2, bytes.Length);
                List<ushort> registerValues = new List<ushort>();
                for (int j = i; j < end; j += 2)
                {
                    byte[] shortBytes = new byte[2] { bytes[j], bytes[j + 1] };
                    registerValues.Add(BitConverter.ToUInt16(shortBytes, 0));
                }
                //写入当前批次的数据
                _modbusMaster.WriteMultipleRegisters(_salve, (ushort)(6 + i / 2), registerValues.ToArray());


            }
            #endregion


            #region 旧版本的写数据

            /*  _modbusMaster.WriteMultipleRegisters(_salve, 6, new ushort[]
              {

                      bytes.Take(2).Reverse().ToUShort(),
                  bytes.Skip(2).Take(2).Reverse().ToUShort()
              });*/
            #endregion

        }
        #endregion

    }
}
