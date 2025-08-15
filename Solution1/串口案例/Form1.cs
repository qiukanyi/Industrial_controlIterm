using HmExtension;
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
using 串口案例;
using static 串口案例.接口;

namespace 串口案例
{
    public partial class Form1 : Form
    {
        private SerialPortHelper sph;

        public Form1()
        {
            InitializeComponent();
        }




       //打开串口
        private void button1_Click(object sender, EventArgs e)
        {
            //获取串口参数
            var portName =portNameCb .Text;
            var baudRate = int.Parse(baudRateCb.Text);
            var dataBits = int.Parse(dateBitesCb .Text );
            var parity=(Parity )Enum.Parse(typeof(Parity),ParityCb .Text);
            var stopBits=(StopBits )Enum.Parse(typeof(StopBits),stopBitesCb .Text);
            //创建串口对象
            sph = SerialPortHelper.Create(portName, baudRate, dataBits, parity, stopBits);
            //打开串口
            sph .Open ();
            stringRb.Checked = true;//默认显示为字符串
            sph.ClearDataHandler();//清空原有的数据处理方式
            sph.AppendDataHandler(ToString);//添加数据处理方式
            sph.OnDataReceived += Sph_OnDataReceived;//添加数据接收事件
        }
        private void Sph_OnDataReceived(object obj) {

         var msq=  $"[RX]{DateTime.Now:yyyy-MM-dd HH:mm:ss}:{obj}{Environment.NewLine}";//格式化显示，添加时间戳，这种写法很新奇

            //在ui线程之外，访问ui对象
            //InvokeRequired是否需要使用Invoke调用
            //这是正规完整的写法，记住了，以后杰哥就不会直接写if啥的了

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    historyTb.AppendText(msq);
                }));
            }
            else {

                historyTb.AppendText(msq);

            }
        }


        //处理方式，这里的目的是为了显示数据，所以只需要把数据转成字符串即可
        private object ToString(object data) {

            return (data as byte[] ).FromString ();
        }
        private object ToHex(object data)
        {

            return (data as byte[]).ToHexString ();
        }
        private object ToByte(object data)
        {

            return String.Join(",", data as byte[]??Array.Empty <byte >());
        }



        
        private void stringRb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton { Checked: true }&& sph is not null )
            {
                sph.ClearDataHandler();
                sph.AppendDataHandler(ToString);
            }//sender
        }

        private void hexRb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton { Checked: true } && sph is not null)
            {
                sph.ClearDataHandler();
                sph.AppendDataHandler(ToHex);
            }//sender
        }

        private void byteRb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton { Checked: true } && sph is not null)
            {
                sph.ClearDataHandler();
                sph.AppendDataHandler(ToByte);
            }//sender
        }

        private void InitComboBox(ComboBox box, params string[] items) 
        { 
            box .Items.Clear();
            box .Items.AddRange(items);
            try
            {
                int selectedIndex = 0; // 例如尝试设置的索引值
                if (selectedIndex >= 0 && selectedIndex < box.Items.Count)
                {
                    box.SelectedIndex = selectedIndex;
                }
                else
                {
                    // 处理索引超出范围的情况
                    Console.WriteLine("Invalid index specified.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // 可以在这里处理异常，例如输出错误信息或者其他处理
                Console.WriteLine("Caught ArgumentOutOfRangeException: " + ex.Message);
            }



        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitComboBox(portNameCb ,SerialPort .GetPortNames());
            InitComboBox(baudRateCb, "9600", "19200", "38400", "57600", "115200");
            InitComboBox(ParityCb, Enum.GetNames(typeof(Parity)));
            InitComboBox(stopBitesCb , Enum.GetNames(typeof(StopBits )));
        }

        private void historyTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendMsgTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
