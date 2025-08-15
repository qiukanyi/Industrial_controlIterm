using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using AntdUI;
namespace mqttDemo
{
    public partial class Form1 : Form
    {
        private AntList<EnvironmentData> list = new AntList<EnvironmentData>();



        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //如果按钮类型不是错误类型，调用 MqttHelper.Connect(...) 方法，连接到 MQTT 代理。
        //hostTb.Text 是主机名或 IP 地址的文本框输入值。
        //(int) portTb.Value 是端口号的数值输入。
        //userNameTb.Text 和 passwordTb.Text 是用户名和密码的文本框输入值，用于 MQTT 连接的身份验
        private void button1_Click(object sender, EventArgs e)
        {
            //sender：事件的发送者，即触发事件的对象。
            //在这里，通过 sender is AntdUI.Button btn 将发送者转换为 AntdUI.Button 类型的变量 btn。
            if (sender is AntdUI.Button btn)//确保发送者是一个 AntdUI.Button 控件，并将其转换为 btn 变量，以便后续操作
            {
                //e：事件参数，包含与事件相关的信息，如点击事件的详细信息。
                if (btn.Type == TTypeMini.Error)//检查按钮的类型。如果按钮的类型是 TTypeMini.Error，意味着用户点击了一个用于错误处理的按钮。
                {
                    MqttHelper.Disconnect();//如果按钮类型是错误类型，调用 MqttHelper.Disconnect() 方法，该方法应该是一个异步操作，用于断开 MQTT 客户端的连接。

                }
                /*  如果按钮类型不是错误类型，调用 MqttHelper.Connect(...) 方法，连接到 MQTT 代理。
                 hostTb.Text 是主机名或 IP 地址的文本框输入值。
                 (int)portTb.Value 是端口号的数值输入。
                 userNameTb.Text 和 passwordTb.Text 是用户名和密码的文本框输入值，用于 MQTT 连接的身份验*/
                else
                {
                    MqttHelper.Connect(houstTb.Text, (int)portTb.Value, userNameTb.Text, PasswordTb.Text);
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table1.Columns = new[] 
            {
                new  Column ("Deviceid","服务器编号"),
                new Column ("Humidity","湿度"),
                new Column("Temperature","温度"),
                new Column("Light","光照度"),
            }; 


            table1.Binding(list);


            MqttHelper.OnConnecting += option =>
            {
                button1.Loading = true;
                button1 .Text = "连接中...";

            };
            MqttHelper .OnConnected += result  =>
            {
                button1.Loading = false;
              
                if (result.ResultCode == MqttClientConnectResultCode.Success)
                {
                    button1.Text = "停止";
                    button1.Type = TTypeMini.Error ;
                    AntdUI .  Message .success (this,"连接成功！");
                }
                else
                {
                    button1.Text = "连接";
                    button1.Type = TTypeMini.Primary;
                    AntdUI .Message .error (this ,"连接失败！");
                }

            };
            MqttHelper.OnDataReceived += data =>
            {
                this.Invoke(new Action(() =>
                {
                    var ed=list .FirstOrDefault(d => d.Deviceid == data.Deviceid);
                    if (ed == null)
                    {
                        list.Add(data);
                    }
                    else
                    {
                        ed.Humidity = data.Humidity;
                        ed.Light = data.Light;
                        ed.Temperature = data.Temperature;
                    }
                }));
                table1 .Binding(list);
            };
        }

        //订阅按钮
        private void button2_Click(object sender, EventArgs e)
        {
            MqttHelper.SubscribleAsync(pullTb.Text);
        }

        private void input3_TextChanged(object sender, EventArgs e)
        {
           // MqttHelper.SubscribleAsync(pullTb .Text );
        }

        //发送
        private void button3_Click(object sender, EventArgs e)
        {
            MqttHelper.Push(pushTb.Text, input3.Text);
        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
