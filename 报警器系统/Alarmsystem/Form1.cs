using Alarmsystem.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace Alarmsystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // AlarmHelper AlarmHelper;
        private void Form1_Load(object sender, EventArgs e)
        {
            //禁止调整窗体大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;


            // AlarmHelper.Init("COM3", 9600, 1);
            InitPortNames();
            InitDataBits();
            InitParitys();
            InitStopBits();
            InitBaudRates();
            InitloopMode();
           
        }
        //初始化

        private void InitloopMode() { 
         //清空现有的RadioButtons控件
        LoopModPanel2 .Controls.Clear();
            //获取LoopMod的所有名称
        var  names=Enum.GetNames(typeof(LoopMod));
            //
         foreach (var name in names)
         {
                var readioBtn = new RadioButton();
                readioBtn .Text = name;
                readioBtn .Tag =(LoopMod)Enum.Parse(typeof(LoopMod), name);
                AlarmHelper.OnLoopChanged+=(mode =>//监听
                {
                    if (readioBtn.InvokeRequired)
                    {
                        readioBtn.Invoke(new Action(() =>
                        {
                            readioBtn.Checked = (LoopMod)readioBtn.Tag == mode;
                        }));
                    }
                    else
                    {
                        readioBtn.Checked = (LoopMod)readioBtn.Tag == mode;
                    }
                    
                });
                readioBtn.CheckedChanged += (sender, e) =>
                {
                    if (readioBtn.Checked)
                    {
                        AlarmHelper.Instance.SetLoopMode ( (LoopMod)readioBtn.Tag);
                    }
                };
                LoopModPanel2.Controls.Add(readioBtn);
                }
                LoopModPanel2.Refresh ();
        }



        private void InitPortNames()
        {
            string[] porNames = SerialPort.GetPortNames();
            portNameCb.Items.Clear();
            portNameCb.Items.AddRange(porNames);



        }
        //初始化数据位
        private void InitDataBits()
        {
            dataBitCB.Items.Clear();
            dataBitCB.Items.AddRange([5, 6, 7, 8]);
            dataBitCB.SelectedIndex = 3;
        }


        //校验位和停止位打算翻译成中文
        private void InitParitys()
        {
            parityCb.Items.Clear();
            parityCb.Items.AddRange([ParityType.无, ParityType.奇校验, ParityType.偶校验]);
            parityCb.SelectedIndex = 0;
        }
        private void InitStopBits()
        {
            stopBitCb.Items.Clear();
            stopBitCb.Items.AddRange([StopBitsType.无, StopBitsType.一位, StopBitsType.一点五位, StopBitsType.二位]);
            stopBitCb.SelectedIndex = 1;
        }
        //初始化波特率
        private void InitBaudRates()
        {
            baudRateCb.Items.Clear();
            List<int> baudRates = new List<int>();
            for (int i = 600, j = 0; j < 10; i <<= 1, j++)
            {
                baudRates.Add(i);
            }
            for (int i = 480, j = 0; j < 10; i <<= 1, j++)
            {
                baudRates.Add(i);
            }
            //将items进行从小到大的排序
            var array = baudRates.OrderBy(x => x).ToList();
            for (var i = 0; i < array.Count; i++)
            {
                baudRateCb.Items.Add(array[i]);
                if (array[i] == 9600)
                {
                    baudRateCb.SelectedIndex = i;
                }
            }
        }



        //连接按钮
        private void button1_Click(object sender, EventArgs e)
        {
            AlarmHelper.Init(portNameCb.Text,
             (int)baudRateCb.SelectedValue,
             (byte)slaveTb.Value
             );
            ReloadModeParameters();
        }
        //连接的方法
        private void ReloadModeParameters()
        {
            AlarmHelper.Instance.QueryModuleParameters().ContinueWith(t =>
            {
                if (t.Result)
                {
                    baudRateCb.Text = AlarmHelper.Instance.BaudRate.ToString();
                    slaveTb.Value = AlarmHelper.Instance.Slave;
                    slider1.Value = AlarmHelper.Instance.Volume;
                    AntdUI.Message.success(this, "连接成功");
                }
               
            });
            }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1设置从站地址
            AlarmHelper.Instance.SetSlave((byte)slaveTb.Value).ContinueWith(t =>
            {
                if (t.Result)
                {
                    AntdUI.Message.success(this, "设置成功");
                    AlarmHelper.Instance.SetBaudRate((int)baudRateCb.SelectedValue).ContinueWith(t =>
                    {
                        ReloadModeParameters();
                    });
                }
                else
                {
                    AntdUI.Message.error(this, "设置失败");
                }
            });
        }
        // //恢复出场设置
        private void button3_Click_1(object sender, EventArgs e)
        {
            AlarmHelper.Instance.Reset().ContinueWith(t =>
            {
                if (t.Result)
                {
                    AntdUI.Message.success(this, "重置成功，请断开电源后重新连接");
                    ReloadModeParameters();//初始化设置之后可以重新读取参数
                }
                else
                {
                    AntdUI.Message.success(this, "恢复出厂成功！");
                }
            });
    
            }
        ////读取参数按钮
        private void button4_Click_1(object sender, EventArgs e)
        {
            ReloadModeParameters();//初始化设置之后可以重新读取参数
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
     
            AlarmHelper .Instance.GetPlayStatus().ContinueWith(t =>
            {
                if (t.Result==1)
                {
                    
                    AlarmHelper.Instance.Stop();
                    playBtn.Image=Alarmsystem .Properties .Resources.播放__1_;
                    playBtn.ImageHover = Alarmsystem .Properties .Resources.播放__2_;
                }
                else
                {
                    AlarmHelper.Instance.Paly();
                    playBtn.Image = Alarmsystem.Properties.Resources.暂停;
                    playBtn.ImageHover = Alarmsystem.Properties.Resources.暂停__1_;
                }
            });
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AlarmHelper.Instance.cease();
            playBtn.ImageSvg = Resources.Play_ImageSvg;
            playBtn.ImageHoverSvg = Resources.Play_HoverImageSvg;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void baudRateCb_SelectedIndexChanged(object sender, int value)
        {

        }

        private void volimeLb_Click(object sender, EventArgs e)
        {

        }

        private void slider1_ValueChanged(object sender,int value)
        {
            volimeLb.Text = slider1.Value.ToString();
            AlarmHelper.Instance.SetVolume(value);

        }      
    }
}
    //校验位
    enum ParityType 
{
    无,
    奇校验,
    偶校验
}
//停止位
enum StopBitsType 
{
    无,
    一位,
    一点五位,
    二位
}
