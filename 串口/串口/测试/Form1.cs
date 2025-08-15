using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测试
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;
        private ModbusSerialPort _modbusPort;

        public Form1()
        {
            InitializeComponent();
            _serialPort = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One); // adjust the port and settings according to your RS485 interface
            _serialPort.Open();
            _master = new ModbusSerialPort(_serialPort);
            _master.Baudrate = 9600;
            _master.DataBits = 8;
            _master.Parity = Parity.None;
            _modbusPort.StopBits = StopBits.One;
            _modbusPort.Open();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] response = _modbusPort.ReadHoldingRegisters(0x01, 0x0000, 2); // read 2 registers from address 0x0000
            int lux = BitConverter.ToInt16(response, 0); // convert response to 16-bit integer
            label1.Text = $"Light Intensity: {lux} lux";
            if (lux > 5000)
            {
                // Send command to JR-SG01 alarm device to trigger alarm
                byte[] alarmCommand = new byte[] { 0x01, 0x02, 0x03, 0x04 }; // adjust the command according to the JR-SG01 device's documentation
                _serialPort.Write(alarmCommand, 0, alarmCommand.Length);
            }
        }
    }
    }
}
