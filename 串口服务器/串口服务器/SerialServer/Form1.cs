using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NettyHelper.Start(ipTB.Text, (int)portTB.Value, Handler);
        }

        private void Handler(EnvironmentData obj)
        {
            this.Invoke(new Action(() =>
            {
                humidityTB.Value = (decimal)obj.Humidity;
                temperatureTB.Value = (decimal)obj.Temperature;
                lightTB.Value = (decimal)obj.Light;

            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NettyHelper.OnConnectChanged += isConnected =>
            {
                this.Invoke((Action)(() =>
                {
                    button1.Text = isConnected ? "断开" : "连接";
                    button1.Type = isConnected ? AntdUI.TTypeMini.Error : AntdUI.TTypeMini.Primary;
                    ipTB.Enabled = portTB.Enabled = !isConnected;
                }));
            };
        }
    }
}
