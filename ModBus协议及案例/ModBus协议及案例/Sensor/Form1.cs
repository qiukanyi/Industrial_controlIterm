using HmExtension.Standard.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensor
{
    public partial class Form1 : Form
    {
        private static readonly byte[] mb = new byte[] {0x02,0x03,0x00,0x00,0x00,0x03 }.AppendModbusCrc();

        public Form1()
        {
            InitializeComponent();
        }

        //时钟控件
        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write(mb, 0, mb.Length);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[serialPort1.BytesToRead];
            serialPort1.Read(buffer, 0, buffer.Length);

            //取值
            if (buffer.Length > 0)
            {
                //前三个分别是地址码，功能码和有效字节数，不用取值
                var values = buffer.Skip(3).Take(6).ToArray();
                var humidity = values.Take(2).ToArray().Reverse().ToArray().ToUShort();
                var temperature = values.Skip(2).Take(2).ToArray().Reverse().ToArray().ToUShort();
                var illumination = values.Skip(4).Take(2).ToArray().Reverse().ToArray().ToUShort();
                inputNumber1.Value = (decimal)(humidity / 10.0);
                inputNumber2.Value = (decimal)(temperature / 10.0);
                inputNumber3.Value = illumination;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Start();
        }
    }
}
