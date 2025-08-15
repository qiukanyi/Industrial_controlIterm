using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarm_system
{
    public partial class Form1 : Form
    {

        private  static  sensor sensor1;
        private DigitalTubeHelper digitalTubeHelper;
        public Form1()
        {
            InitializeComponent();
        }
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
        private void ucMeter1_Load(object sender, EventArgs e)
        {

        }
        //时间控件刷新：传感器的
        private void timer1_Tick(object sender, EventArgs e)
        {
            //调用获取数据的方法
            sensor1 .Update();
            //主线程
            this.Invoke((Action)(() => {//强转一下
                UpdateHumidity();
                UpdateTemperature();
                UpdateLight();
            }));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            ModbusMaster modbus = ModbusSerialMaster.CreateRtu(serialPort1);
            sensor1 = new sensor(modbus,2);//串口号，从机地址  传感器的地址
            //还有一个另一个类的
            digitalTubeHelper = new DigitalTubeHelper(modbus, 1);
        }
        //数显管的
        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        private int index;

        private char[] perfixs = { 'H', 'C', 'L', };

        private Func<double>[] actions = {
        ()=>sensor1.Humidity,
        ()=>sensor1.Temperature,
        ()=>sensor1.Light,
        };


        private void timer2_Tick_1(object sender, EventArgs e)
        {
            digitalTubeHelper.SetValue(actions[index](), perfixs[index]);
            index++;
            if (index >=actions.Length)
            {
                index = 0;
            }
          
        }

      
    }
}
