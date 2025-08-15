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

namespace 警报器
{
    public partial class Form1 : Form
    {
        private static readonly byte[] mb = new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x03 }.AppendModbusCrc();
        private static readonly byte[] mb1 = new byte[] { 0xEF, 0xAA, 0x03, 0xAA, 0x02, 0x00,0xAC,0xEF,0x55 }.AppendModbusCrc();
        private static readonly byte[] mb2 = new byte[] { 0xEF, 0xAA, 0x03, 0xAA, 0x04, 0x00, 0xAC, 0xEF, 0x55 }.AppendModbusCrc();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write(mb, 0, mb.Length);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[serialPort1.BytesToRead];
            serialPort1 .Read (buffer, 0, buffer.Length);
            if (buffer.Length>0)
            {
                var values = buffer.Skip(3).Take(6).ToArray();
                var light= values.Skip(4).Take(2).ToArray().Reverse().ToArray().ToUShort();
                inputNumber1.Value= light;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Start();
        }
    }
}
