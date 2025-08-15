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

namespace 报警器调试工具;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
        //禁止调整窗体大小
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MinimizeBox = false;
        this.MaximizeBox = false;

            //初始化下拉框
            InitPortName();
            InitDataBits();
            InitParitys();
            InitStopBits();
            InitBaudRate();
            InitLoopModel();    
        }



      private void InitLoopModel() { 
       loopModelPanel.Controls.Clear();
        var names = Enum.GetNames(typeof(Loopmode));
        foreach (var name in names) { 
         var radioBtn= new RadioButton();
            radioBtn.Text = name;
            radioBtn.Tag =(Loopmode)Enum.Parse(typeof(Loopmode), name);
            AlarmHelper.OnLoopModeChanged += (mode) => {

                if (radioBtn.InvokeRequired)
                {
                    radioBtn.Invoke(new Action(() => radioBtn.Checked = (Loopmode)radioBtn.Tag == mode));
                }
                else
                {
                    radioBtn.Checked = (Loopmode)radioBtn.Tag == mode;
                }// radioBtn.Checked = (Loopmode)radioBtn.Tag == mode;原代码报错:线程错误
            };  
            radioBtn.CheckedChanged += (sender, e) =>
            {
                if (radioBtn.Checked)
                {
                    AlarmHelper.Instance.SetLoopMode((Loopmode)radioBtn.Tag);
                }

            };
            loopModelPanel.Controls.Add(radioBtn);
        
        }
        loopModelPanel.Refresh();
    
    
    }
        private void InitPortName() { 
         string[] portNames=SerialPort .GetPortNames();
            portNamecb.Items.Clear();
            portNamecb.Items.AddRange(portNames);
        }

        private void InitDataBits() { 
          dataBitcb.Items.Clear();
            dataBitcb.Items.AddRange([5,6,7,8]);
            dataBitcb.SelectedIndex = 3;
           
        }

        private void InitParitys() {
        paritycb.Items.Clear();
        paritycb.Items.AddRange([ParityType.无,ParityType.奇检验,ParityType.偶校验]);
        paritycb.SelectedIndex = 0;  
         }
    private void InitBaudRate()
    {
        BaudRatecb.Items.Clear();
        List<int> baudRates = new List<int>();
        for (int i = 600, j = 0; j < 10; i <<= 1 ,j++) {
            baudRates.Add(i);
        }
        
        for (int i = 480, j = 0; j < 10; i <<= 1 ,j++)
        {
            baudRates.Add(i);
        }
        //将item从小到大排序
        var array=baudRates.OrderBy(x => x).ToList();
        for (var i = 0; i < array.Count; i++) { 
          BaudRatecb .Items.Add(array[i]);
            if (array[i]==9600)
            {
                BaudRatecb.SelectedIndex = i;
            }
        
        }
    }

    private void InitStopBits()
    {
        stopBitcb.Items.Clear();
        stopBitcb.Items.AddRange([StopBits.无, StopBits.一位, StopBits.两位,StopBits.一点五位]);
        stopBitcb.SelectedIndex = 1;
    }

    private void button1_Click(object sender, EventArgs e)
    {
          AlarmHelper.Init(portNamecb.Text,
            (int)BaudRatecb.SelectedValue,
            (byte)slavetb.Value
            );
        ReloadModeParameters();
        
    }

    public void ReloadModeParameters() {
        AlarmHelper.Instance.QueryModuleParameters().ContinueWith(t => {
            if (t.Result)
            {

                BaudRatecb.Text = AlarmHelper.Instance.BaudRate.ToString();
                slavetb.Value = AlarmHelper.Instance.Slave;
                volumesli.Value = AlarmHelper.Instance.Volume;
                AntdUI.Message.success(this, "参数加载成功");
            }


        });
        

    }

    private void button2_Click(object sender, EventArgs e)
    {
        //参数设置
        //1.设置从站地址
        AlarmHelper.Instance.SetSlave((byte)slavetb.Value).ContinueWith(t =>
        {
            if (t.Result)
            {
                AntdUI.Message.success(this, "设置成功");
                AlarmHelper.Instance.Setbaudrate((int)BaudRatecb.SelectedValue).ContinueWith(t =>
                {                   
                    ReloadModeParameters();                   
                });                
            }
            else {
                AntdUI.Message.error(this,"设置失败");                
            }
        });
    }

    private void volumesli_ValueChanged(object sender, int value)
    {
        label2.Text=volumesli.Value.ToString();
        AlarmHelper.Instance.SetVolume(value);
    }
    private void button3_Click(object sender, EventArgs e)
    {
        AlarmHelper.Instance.Reset().ContinueWith(t => {

            if (!t.Result)
            {               
                ReloadModeParameters();
                AntdUI.Message.success(this, "重置成功！请断开电源后重新连接");
            }
            else {
                AntdUI.Message.error(this ,"重置失败");
            }        
        });
    }
    private void button4_Click(object sender, EventArgs e)
    {
        ReloadModeParameters();
    }
    private void Playbtn_Click(object sender, EventArgs e)
    {
       
        AlarmHelper.Instance.GetPlayStatus().ContinueWith(t =>
        {
            if (t.Result==1)
            {
                AlarmHelper.Instance.pause();
                Playbtn.Image = 报警器调试工具.Properties.Resources._1;
                Playbtn.ImageHover = 报警器调试工具.Properties.Resources._2;
            }
            else
            {
                AlarmHelper.Instance.play();
                Playbtn.Image = 报警器调试工具.Properties.Resources._3;
                Playbtn.ImageHover = 报警器调试工具.Properties.Resources._4;
            }

        });
    }
    private void stopbtn_Click(object sender, EventArgs e)
    {
            AlarmHelper.Instance.stop();
        Playbtn.Image = 报警器调试工具.Properties.Resources._1;
        Playbtn.ImageHover = 报警器调试工具.Properties.Resources._2;
    }
}
enum ParityType { 
 无,
 奇检验,
 偶校验
}

enum StopBits { 
    无,
      一位,
        两位,
        一点五位
}