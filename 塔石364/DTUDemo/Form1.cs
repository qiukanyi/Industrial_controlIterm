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
using System.Net;

namespace DTUDemo
{



    public partial class Form1 : Form
    {
        //初始化表格
        private AntList<EnvironmentData> list = new ();
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
            
            table2.Columns = new[]
            {
           new Column ("Deviceid","服务器编号"),
           new Column ("Humidity","湿度"),
           new Column ("Temperature","温度"),
           new Column ("Light","光照度"),
            };
            table2.Binding(list);
            NetHelper.OnServerStatusChanged += status =>
            {
                button1.Text = NetHelper.IsRuning ? "停止" : "启动";
                button1.Type = status ? TTypeMini.Error : TTypeMini.Primary;

                this.Invoke(new Action(() =>
                {
                    
                    inputNumber1.Enabled = !status;
                }));
             
            };
            NetHelper.OnchannelConnected += channel =>
            {
                AntdUI.Message.info(this, $"客户端{((IPEndPoint )channel .RemoteAddress ).Address .MapToIPv4 ()}上线");

            };
            NetHelper.OnchannelDisconnected  += channel =>
            {
                AntdUI.Message.error (this, $"客户端{((IPEndPoint)channel.RemoteAddress).Address.MapToIPv4()}下线");

            };
            NetHelper.OnDataReceived += data =>
            {
                this . Invoke (new Action (() =>
                {
                    if (string.IsNullOrEmpty(data.Deviceid))
                    {
                        return;
                    }
                    var d = list.FirstOrDefault(d => d.Deviceid == data.Deviceid);
                    if (d == null)
                    {
                        list.Add(data);
                    }
                    else
                    {
                        d.Humidity = data.Humidity;
                        d.Light = data.Light;
                        d.Temperature = data.Temperature;
                    }
                    //更新表格
                    table2.Binding (list );
                }));
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender is AntdUI . Button btn)
            {
                btn.Loading = true;
                Task task = null;
                if (NetHelper.IsRuning)
                {
                   task = NetHelper.Stop();
                    
                }
                else
                {
                   task= NetHelper.Start((int)Settings.Default.SERVER_PORT);
                }
                task.ContinueWith(t =>
                {
                    btn.Loading = false;
                });
                }
            }
        }
    }

