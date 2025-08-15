using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm_system
{
    public partial class Form1 : Form
    {
        private static sensor sensor1;
      private    AlarmHelper alarmHelper;
        public Form1()
        {
            InitializeComponent();
        }
        public static readonly byte[]open =new byte[] {0xEF,0xAA,0x03,0xAA,0x02,0x00,0xAC,0xEF,0x55}; 
        public static readonly byte[]close = new byte[] { 0xEF, 0xAA, 0x03, 0xAA, 0x04, 0x00, 0xAE, 0xEF, 0x55 };
        //读数据
        //湿度：
        private void UpdateHumidity()
        {
            inputNumber1.Value = (decimal)sensor1.Humidity;
            ucMeter1.Value = (decimal)sensor1.Humidity;
        }

        //温度：
        private void UpdateTemperature()
        {
            inputNumber2.Value = (decimal)sensor1.Temperature;
            ucThermometer1.Value = (decimal)sensor1.Temperature;
        }
        //光照度
        private void UpdateLight()
        {
            inputNumber3.Value = (decimal)sensor1.Light;
            ucMeter2.Value = (decimal)sensor1.Light;
        }

        private void ucThermometer1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //调用获取数据的方法
            sensor1.Update();
            //主线程
            this.Invoke((Action)(() => {//强转一下
                UpdateHumidity();
                UpdateTemperature();
                UpdateLight();
            }));
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            ModbusMaster modbus = ModbusSerialMaster.CreateRtu(serialPort1);
            sensor1 = new sensor(modbus, 2);//串口号，从机地址  传感器的地址
            alarmHelper=new AlarmHelper(modbus ,1);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (inputNumber3.Value < 1000)
            {
                sensor1.judgment = false;
            }
            else if (inputNumber3.Value >= 1000)
            {
                sensor1.judgment = true;

                // 调用报警器
                alarmHelper.RaiseAlarm(); // 假设有一个方法来触发报警器

                // 如果需要发送开启信号，可以参考你的现有代码进行修改
                serialPort1.Write(open, 0, open.Length);
                Thread.Sleep(8000); // 等待一段时间后再关闭信号，根据需要调整
                serialPort1.Write(close, 0, close.Length); // 发送关闭信号
            }


        }
    }
}
