using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using AntdUI.Chat;
using ChartCommon;
using HmExtension.Standard.Extensions;


namespace ChartClient
{
    public partial class Form1 : Form
    {
        private Dictionary <int ,string >_nickNames=new ();
        public Form1()
        {
            InitializeComponent();
        }

        //连接按钮
        private void button1_Click(object sender, EventArgs e)//button1_Click 是一个事件处理方法，它处理一个按钮的点击事件。sender 参数是事件的发起者，EventArgs e 提供了事件的相关信息
        {
            if (sender is AntdUI.Button btn)//检查 sender 是否是 AntdUI.Button 类型的实例，并将其转换为 btn 变量，以便后续使用。
            {


                Task.Run(() =>//异步任务启动
                {
                    if (ClientHelper.IsConnected)
                    {
                        ClientHelper.Discoonect();
                    }
                    else
                    {
                        ClientHelper.ConnetAsync(ipTb.Text, (int)portTb.Value);
                    }

                }).ContinueWith(t =>
                {
                    btn.Loading = false;
                });
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitConnectedStatus();
           
        }

        private MsgItem _selectedItem;
        private void InitConnectedStatus()
        {
            msgList1.ItemSelected += (sender, args) =>
            {
                _selectedItem = args.SelectedItem;
            };

            ClientHelper.OnChangeConnected += connected =>
            {
                this.Invoke(new Action(() =>
                {
                    ipTb.Enabled = !connected;
                    portTb.Enabled = !connected;
                    nickNameTb.Enabled = !connected;
                    button1.Text = connected ? "断开" : "连接";
                    button1.Type = connected ? AntdUI.TTypeMini.Error : AntdUI.TTypeMini.Primary;
                    if (!connected)
                    {
                        msgList1.Items.Clear();
                    }

                }));
            };
            ClientHelper.OnChangeId += id =>
            {
                this.Invoke((() =>
                {
                    this.Text = $"{nickNameTb.Text} -已连接—ID:{id}";
                }));
                ClientHelper.SendCommand(ChartCommon.CommandType.Set_Nick_Name, 0, nickNameTb.Text);
            };

            ClientHelper.RegistHander(ChartCommon.CommandType.Set_On_Line, cmd =>
            {
                this.Invoke(() =>
                {
                    $"{cmd.RreceiverId}[{cmd.Content}上线了]".Println();
                    var item = new MsgItem(cmd.Content);
                    item.Tag = cmd.RreceiverId;
                    msgList1.Items.Add(item);
                   
                });
                _nickNames[cmd.RreceiverId] = cmd.Content;
            });


            ClientHelper.RegistHander(ChartCommon.CommandType.Set_Off_Line, cmd =>
            {
                this.Invoke((() =>
                {
                    $"{cmd.RreceiverId}[{cmd.Content}]下线了".Println();
                    foreach (var item in msgList1.Items)
                    {
                        if (item is MsgItem { Tag: not null } mi && mi.Tag.ToString() == cmd.RreceiverId.ToString())
                        {
                            msgList1.Items.Remove(item);
                        }
                    }
                    msgList1.Refresh();
                }));
                _nickNames.Remove(cmd.RreceiverId);
            });

            ClientHelper.RegistHander(ChartCommon.CommandType.Send_Message, cmd =>
            {
                this.Invoke(() =>
                {
                    TextChatItem item = new TextChatItem(cmd.Content??"", null,$"{_nickNames[cmd.SenderId]}{DateTime.Now:yyyy-MM-dd HH :mm:ss}");//?还少了一个
                    historyList  .AddToBottom(item);
                });
            });
        }

        private void MessageTb_ItemSelected(object sender, MsgItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientHelper.SendCommand(  ChartCommon.CommandType.Send_Message,
                broadcastCb.Checked ? 0 : int.Parse($"{_selectedItem.Tag??"0"}"),
                MessageTb .Text
               
                );
          

            historyList.AddToBottom(new TextChatItem(MessageTb.Text, null, $"{nickNameTb .Text }{DateTime.Now:yyyy-MM-dd HH :mm:ss}")
            {
                Me = true

            });
            MessageTb.Text = "";
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }
    }
}

