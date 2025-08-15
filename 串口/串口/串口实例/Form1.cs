using HmExtension;
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

namespace 串口实例
{
    public partial class 串口助手 : Form
    {
        private SerialPortHelper sph;
        public 串口助手()
        {
            InitializeComponent();
        }


        private void InitComBox(ComboBox box, params string[] items) { 
          box .Items.Clear();   
            box .Items.AddRange(items);
         box.SelectedIndex = 0;
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitComBox(comPortName,SerialPort.GetPortNames());
            InitComBox(comBaudRate, "9600", "19200", "38400", "57600");
            InitComBox(comParity, Enum.GetNames(typeof(Parity)));
            InitComBox(comStopbits,Enum .GetNames(typeof(StopBits)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var portName=comPortName.Text;
            var baudRate=int.Parse(comBaudRate.Text);
            var databits=int.Parse(comDatabits.Text);
            var parity = (Parity)Enum.Parse(typeof(Parity), comParity.Text);
            var stopBits=(StopBits )Enum.Parse(typeof(StopBits),comStopbits.Text);
            sph = SerialPortHelper.Create(portName ,baudRate,databits,parity,stopBits);
            sph.Open();
            rbString .Checked = true;
            sph.ClearDataHandler();
            sph.AppendDataHandler(Tostring);
            sph.OnDataReceived += Sph_OnDataReceived;
        }

        private void Sph_OnDataReceived(object obj)
        {
            var msg = $"[RX]{DateTime .Now:yyyy-MMM-dd HH:mm:ss}:{obj}{Environment .NewLine}";
            //在 UI线程之外，访问UI对象
            //txthistory.AppendText(msg);
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txthistory.AppendText(msg);


                }));
            }
        }


        private object Tostring(object data) {
            return (data as byte[]).FromString() ;
        }
        private object ToHex(object data)
        {
            return (data as byte[]).ToHexString("-");
        }
        private object ToByte(object data)
        {
            return string .Join(",",data as byte[] ?? Array .Empty<byte>());
        }

        private void rbString_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton { Checked: true } && sph is not null)
            {
                sph.ClearDataHandler();
                sph.AppendDataHandler(Tostring);
            }

        }

        private void rbHex_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton { Checked: true } && sph is not null)
            {
                sph.ClearDataHandler();
                sph.AppendDataHandler(ToHex);
            }
        }

        private void rbbytes_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton { Checked: true } && sph is not null)
            {
                sph.ClearDataHandler();
                sph.AppendDataHandler(ToByte);
            }
        }
    }
}
