using HmExtension.Standard.Extensions;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 环境监测
{
    public partial class Form1 : Form
    {
        private  DigitalTubeHelper digital;
        private static  EnvironmentHelper environment;
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateHumidity()
        {
            inputNumber1 .Value = (decimal)environment .Humidity;
            ucMeter1 .Value = (decimal)environment.Humidity;
        }
        private void UpdateTemperature()
        {
            inputNumber2 .Value = (decimal)environment .Temperature;
            ucThermometer1 .Value= (decimal)environment.Temperature;
        }
        private void UpdateLight() {
            inputNumber3.Value = (decimal)environment.Light;
           ucMeter2.Value = (decimal)environment.Light;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            environment.Update();
            this.Invoke(() =>
             {
                 UpdateHumidity();
                 UpdateTemperature();
                 UpdateLight();

             });

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1 .Open();
            ModbusMaster master = ModbusSerialMaster.CreateRtu(serialPort1 );
            environment=new EnvironmentHelper(master,2);
            digital =new DigitalTubeHelper(master,2);
        }


        private int index;
        private char[] prefixs = {'H','C','L' };
        private Func<double>[] actions = {
         ()=>environment.Humidity,
         ()=>environment.Temperature,
         ()=>environment.Light

        };
        private void timer2_Tick(object sender, EventArgs e)
        {
            digital.SetValue(actions[index](), prefixs[index]);
            index++;
            if (index >=actions .Length)
            {
                index = 0;
            }
        }
    }
}
