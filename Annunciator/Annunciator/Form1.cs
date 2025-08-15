using AntdUI;
using HmExtension.Standard.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Annunciator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static readonly byte[] mb = new byte[] { 0x1, 0x3, 0x00, 0x00, 0x00, 0x03 }.AppendModbusCrc();
        public static readonly byte[] mb1 = new byte[] { 0xEF, 0xAA, 0x03, 0xAA, 0x02,0x00, 0xAC, 0xEF,0x55 };
        public static readonly byte[] mb2 = new byte[] { 0xEF, 0xAA, 0x03, 0xAA, 0x04, 0x00, 0xAE, 0xEF, 0x55 };
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            serialPort1.Open();
        }
        public bool b = false;
        //public int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Task.Run(() =>
            {
                this.Invoke(new Action(() =>
                {
                    serialPort1.Write(mb, 0, mb.Length);
                }));
                
            });

            new Thread(() =>
            {
                if (b == false )
                {
                    this.Invoke(new Action(() =>
                    {
                        if (inputNumber1.Value > 1000)
                        {
                            b = true;
                            serialPort1.Write(mb1, 0, mb1.Length);
                            //让报警器响5秒
                            Thread.Sleep(5000);
                            serialPort1.Write(mb2, 0, mb2.Length);
                            
                        }
                    }));
                }
            }).Start();
        }
       
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            inputNumber1.Value = 0;
            
            if (inputNumber1.Value < 1000)
            {
                b = false;
            }

            byte[] bytes = new byte[serialPort1.BytesToRead];
            serialPort1.Read(bytes, 0, bytes.Length);
            if (bytes.Length > 0)
            {
                byte[] values = bytes.Skip(3).Take(6).ToArray();
                ushort light = values.Skip(4).Take(2).ToArray().Reverse().ToArray().ToUShort();
                inputNumber1.Value = light;
            }
        }
    }
}
