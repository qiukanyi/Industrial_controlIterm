using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTUDemo.Properties;
using AntdUI;
using Button = AntdUI.Button;
using Message = AntdUI.Message;
using System.Net;

namespace DTUDemo
{
    public partial class Form1 : Form
    {
        //用于初始化表格table1
        private AntList<EnvironmentData> list = new AntList<EnvironmentData> ();

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
            //初始化表格并绑定数据源
            table1.Columns = new[]
            {
                new Column("DeviceID","服务器编号"),
                new Column("Humidity","湿度"),
                new Column("Temperature","服务器编号"),
                new Column("Light","服务器编号")

            };
            table1.Binding(list);

            //监听服务器运行状态从而保证UI的正常修改
            NettyHelper.OnServerStatusChanged += status =>
            {
                this.Invoke(new Action(() =>
                {
                    button1.Text = status ? "停止" : "启动";
                    button1.Type = status ? TTypeMini.Error : TTypeMini.Primary;
                    inputNumber1.Enabled = !status;
                }));
            };

            NettyHelper.OnChannelConnected += channel =>
            {
                Message.info(this, $"客户端{((IPEndPoint)channel.RemoteAddress).Address.MapToIPv4()}上线");
            };
            NettyHelper.OnChannelDisconnected += channel =>
            {
                Message.error(this, $"客户端{((IPEndPoint)channel.RemoteAddress).Address.MapToIPv4()}下线");
            };

            //给表格绑定处理过后的数据
            NettyHelper.OnDataReceived += data =>
            {
                this.Invoke(new Action(() =>
                {
                    if (string.IsNullOrEmpty(data.DeviceId)) return;
                    var da = list.FirstOrDefault(d => d.DeviceId == data.DeviceId);
                    if (da == null)
                    {
                        list.Add(data);
                    }
                    else
                    {
                        da.Humidity = data.Humidity;
                        da.Temperature = data.Temperature;
                        da.Light = data.Light;
                    }
                    //刷新表格
                    table1.Binding(list);
                }));
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                btn.Loading = true;

                Task.Run(() =>
                {
                    if (NettyHelper.IsRunning)
                    {
                        NettyHelper.Stop();
                    }
                    {
                        NettyHelper.Static((int)Settings.Default.SERVER_PORT);
                    }
                }).ContinueWith(t =>
                {
                    btn.Loading = false;
                });
            }
            
        }












    }
}
