using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmExtension.Standard.Extensions;
using Modbus.Device;
using Modbus.Extensions.Enron;

namespace WindowsFormsApp1
{
    internal class Class1
    {
        private ModbusMaster modbusMaster;

        private byte salve;

        public Class1(SerialPort serialPort, byte salve)
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

    }
}
