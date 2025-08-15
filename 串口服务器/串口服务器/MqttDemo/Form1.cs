using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = AntdUI.Message;
using Button = AntdUI.Button;
using AntdUI;
using MQTTnet.Client;

namespace MqttDemo
{
    public partial class Form1 : Form
    {
        private AntList<EnvironmentData> list = new AntList<EnvironmentData>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                if(btn.Type == AntdUI.TTypeMini.Error)
                {
                    MqttHelper.Disconnect();
                }
                else
                {
                    MqttHelper.Connect(hostTb.Text, (int)portTb.Value, usernameTb.Text, passwordTb.Text);
                }
            }
            
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
            MqttHelper.OnConnecting += options =>
            {
                button1.Loading = true;
                button1.Text = "连接中...";
            };

            MqttHelper.OnConnected += result =>
            {
                button1.Loading = false;
                if(result.ResultCode == MQTTnet.Client.MqttClientConnectResultCode.Success)
                {
                    button1.Type = AntdUI.TTypeMini.Error;
                    button1.Text = "停止";
                    Message.success(this, "连接成功");
                }
                else
                {
                    button1.Type = AntdUI.TTypeMini.Primary;
                    button1.Text = "连接";
                    Message.error(this, "连接失败");
                }
            };

            MqttHelper.OnDataReceived += data =>
            {
                this.Invoke(new Action(() =>
                {
                    var ed = list.FirstOrDefault(d => d.DeviceId == data.DeviceId);
                    if(ed == null)
                    {
                        list.Add(data);
                    }
                    else
                    {
                        ed.Humidity = data.Humidity;
                        ed.Temperature = data.Temperature;
                        ed.Light = data.Light;
                    }
                    table1.Binding(list);

                }));
            };

        }


        private void button2_Click(object sender, EventArgs e)
        {
            MqttHelper.SubscribeAsync(pullTb.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MqttHelper.Push(pushTb.Text,input3.Text);
        }
    }
}
