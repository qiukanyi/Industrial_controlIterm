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
using HmExtension;
using HmExtension.Pay;
using HmExtension.Standard.Extensions;


namespace 支付宝
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void input2_TextChanged(object sender, EventArgs e)
        {

        }

        private void input1_Click(object sender, EventArgs e)
        {
            
        }
        //初始化支付宝支付
        private void button1_Click(object sender, EventArgs e)
        {
            AlipayContext.Init(
                input1.Text,
                input2.Text,
                input3.Text,
                input4.Text);
            serialPort1 .Open ();
            MessageBox.Show("支付宝支付初始化成功！");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            input5.Text =Guid.NewGuid().ToString();
        }

        private void inputNumber1_ValueChanged(object sender, decimal value)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var btn = sender as AntdUI.Button;
            btn.Loading = true;

            PayInPersonApi  ppa=new PayInPersonApi();
            var task= ppa.Pay(input5.Text, input6.Text, (double )inputNumber1.Value, input8.Text);
            task.ContinueWith(t => {
                if (t.Result.IsSuccess())
                {
                    MessageBox.Show(this, "支付成功！");


                }
                else {
                    MessageBox.Show(this, "支付失败！");
                
                }
            btn .Loading = false;
            });
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[]bytes=new byte[serialPort1.BytesToRead];
            serialPort1 .Read(bytes,0,bytes.Length);
            input8.Text = bytes.FromString(); 
        }
    }
}
