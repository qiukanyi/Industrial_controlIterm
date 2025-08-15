using ChartCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button=AntdUI.Button;
using ChartSever;

namespace ChartSever
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<int, int> rowClientMapping = new();

            ServerHandler.OnClientConnected += Client =>
            {
                this.Invoke(new Action(() =>
                {
                 var index=   dataGridView1.Rows.Add(Client.Id, Client.NickName, Client.IpAddress, Client.port, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                 
                    dataGridView1.Refresh();
                    listView1.Items.Add($"{Client.Id}{Client.IpAddress}{Client.port}已连接");
                    rowClientMapping[Client .Id] = index;
                }));
            };
            ServerHandler.OnClientDisConnected += Client =>
            {
                this.Invoke(new Action(() =>
                {

                   var row= dataGridView1.Rows[rowClientMapping[Client.Id]];
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                    dataGridView1.Rows.Remove(row);
                    dataGridView1.Refresh();
                    listView1.Items.Add($"{Client.Id}[{Client.NickName}]{Client.IpAddress}{Client.port}已断开连接");
                
                
                }));
                //离线通知
                ServerHelp.Broadcast(new Command()
                {
                    Type = ChartCommon.CommandType.Set_Off_Line,
                    SenderId = 0,
                    RreceiverId = Client.Id,
                    Content = Client.NickName,
                }, c => c.Id != Client.Id);
            };
            //注册处理器
            ServerHandler.RegisterHandler(ChartCommon.CommandType.Set_Nick_Name, (client, command) =>
            {
                client.NickName = command.Content;
                this .Invoke(new Action(() =>
                {
                    
                    var row = dataGridView1.Rows[rowClientMapping[client.Id]];
                    row.Cells[1].Value = client.NickName;
                    dataGridView1.Refresh();
                }));
                //上线通知
                ServerHelp.Broadcast(new Command() 
                {
                Type = ChartCommon . CommandType.Set_On_Line ,
                SenderId =0,
                RreceiverId =client .Id ,
                Content =client .NickName,
                }, c => c.Id != client.Id);
                foreach (var chatClient in ServerHelp.Clients)
                {
                    if (chatClient != client) 
                    
                    {
                        client .SendMessage(new Command()
                        {
                            Type = ChartCommon.CommandType.Set_On_Line,
                            SenderId = 0,
                            RreceiverId = chatClient.Id,
                            Content = chatClient.NickName,
                        });
                    }
                }
            });
            //监听客户端发送的消息
            ServerHandler.RegisterHandler(ChartCommon.CommandType.Send_Message, (client, cmd ) =>
            {
                //如果接受方消息为0，则为广播消息
                if (cmd.RreceiverId == 0)
                {
                    ServerHelp.Broadcast(cmd, c => c.Id != client.Id);
                }
                else
                {
                    //将消息转发给指定的客户端
                    ServerHelp.SendMessage(cmd.RreceiverId, cmd);
                }
            });

        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {

                Button btn = (Button)sender;
                btn.Loading = true;
                btn.Text = "正在启动。。。";
                ServerHelp.Start((int)inputNumber1.Value).ContinueWith(t =>
                {
                    this.Invoke(new Action(() =>
                    {
                        btn.Loading = false;

                        if (t.IsFaulted)
                        {
                            AntdUI.Message.error(this, $"服务器启动失败:{t.Exception.Message}");
                            btn.Text = "启动服务器";
                            btn.Enabled = true;

                        }
                        else
                        {

                            this.Invoke(new Action(() =>
                            {
                                btn.Text = "服务器已启动";
                                AntdUI.Message.success(this, "服务器启动成功");
                                btn.Enabled = false;
                                this.Text = "ChatSever-已启动-端口号" + inputNumber1.Value;
                            }));
                        }

                    }));

                });
            }));
        }
        
    }
}
