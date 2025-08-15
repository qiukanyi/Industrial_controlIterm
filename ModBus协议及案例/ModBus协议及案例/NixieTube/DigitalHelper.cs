using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmExtension.Standard.Extensions;
using Modbus.Device;
using Modbus.Extensions.Enron;

namespace NixieTube
{
    internal class DigitalHelper
    {
        private ModbusMaster modbusMaster;

        private byte salve;

        public DigitalHelper(SerialPort serialPort, byte salve)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }

            //ModbusSerialMaster表示串口主机
            //CreateRtu表示创建RTU模式的ModBus协议
            modbusMaster = ModbusSerialMaster.CreateRtu(serialPort);
            this.salve = salve;
        }

        //索引器，索引对象中的某个成员
        public char this[ushort index]
        {
            get => this.GetDigitaValue(index);
        }

        public char GetDigitaValue(ushort index)
        {
            //ReadHoldingRegisters读取保持寄存器
            var value = modbusMaster.ReadHoldingRegisters(salve, index, 1).FirstOrDefault();
            return (char)BitConverter.GetBytes(value)[0];
        }

        //读取小数点
        public int GetDot()
        {
            return modbusMaster.ReadHoldingRegisters(salve,16,1).FirstOrDefault();
        }

        //向数码管写数据
        public void SetNumber(double number)
        {
            //符号位
            //存储格式 => 0000_0001
            //需要利用位运算存储到高4位去表示正负
            var symbol = number < 0 ? 1 : 0;   

            //小数点
            //$"{number}"是double => string,
            //Reverse().ToArray()反转之后变成了字符数组
            //string($"{number}".Reverse().ToArray())再转为字符串
            var dot = new string($"{number}".Reverse().ToArray()).IndexOf(".");
            if(dot == -1) dot = 0;

            //值
            //Replace是将小数点用空字符串代替，再将空字符串转换为整型
            var value = $"{number}".Replace(".", "").Replace("-","").ToInt();

            var v = 0;

            v |= symbol << 28;
            v |= dot << 24;
            v |= value;
            var bytes = BitConverter.GetBytes(v).Reverse().ToArray();
            modbusMaster.WriteMultipleRegisters(salve, 6, new ushort[] 
            { 
                //因为ushort只能存储两个字节，4个字节必须分开写出
                bytes.Take(2).Reverse().ToUShort(),
                bytes.Skip(2).Take(2).Reverse().ToUShort()
            });
        }

        //控制闪烁
        public void Twinkle(int index,bool value)
        {
            var v = value ? 1 : 0;
            v = v << index;
            Twinkle((ushort)v);
        }

        public void Twinkle(ushort value)
        {
            modbusMaster.WriteSingleRegister(salve, 8, value);
        }
    }
}
