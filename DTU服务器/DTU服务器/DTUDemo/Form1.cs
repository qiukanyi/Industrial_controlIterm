using AntdUI;
using DTUDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTUDemo
{
     
    public partial class Form1 : Form
    {
        private AntList<EnvironmentData> list=new();
        public Form1()
        {
            InitializeComponent();
        }

        private void inputNumber1_ValueChanged(object sender, decimal value)
        {
             Settings.Default.SERVER_PORT = value;
            Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table1.Columns = new[]
            {
                new Column("DeviceId","服务器编号"),
                new Column("Humidity","湿度"),
                new Column("Temperature","温度"),
                new Column("Light","光照度")
            };
            table1.Binding(list);
            NetHelper.OnServerStatesChanged += status => 
            {
                button1.Text = status ? "停止" : "启动";
                button1.Type=status?TTypeMini.Error:TTypeMini.Primary;
                this.Invoke(new Action(() =>
                {
                    inputNumber1.Enabled = !status;
                }));  
            };
            NetHelper.OnChannelConnected += channel =>
            {
               AntdUI.Message.info(this,$"客户端{((IPEndPoint)channel.RemoteAddress).Address.MapToIPv4()}上线了");
            };
            NetHelper.OnChannelDisconnected += channel =>
            {
                AntdUI.Message.info(this, $"客户端{((IPEndPoint)channel.RemoteAddress).Address.MapToIPv4()}下线了");
            };
            NetHelper.OnDataReceived += data => 
            {
                this.Invoke(() => 
                {
                    if (string.IsNullOrEmpty(data.DeviceId)) { return; }
                    var d = list.FirstOrDefault(d => d.DeviceId == data.DeviceId);
                    if (d == null)
                    {
                        list.Add(data);
                    }
                    else
                    {
                        d.Humidity = data.Humidity;
                        d.Temperature = data.Temperature;
                        d.Light = data.Light;
                    }
                    //更新表格
                    table1.Binding(list);
                });
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender is AntdUI. Button btn)
            {
                btn.Loading = true;
                Task task = null;
                if (NetHelper.IsRunning)
                {
                    task = NetHelper.Stop();
                }
                else
                {
                    task = NetHelper.Start((int)Settings.Default.SERVER_PORT);
                
                }
                task.ContinueWith(t => 
                {
                    btn.Loading = false;
                });
            }
        }
    }
}
