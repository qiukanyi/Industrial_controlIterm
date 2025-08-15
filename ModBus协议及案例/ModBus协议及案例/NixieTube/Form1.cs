using HmExtension.Standard.Extensions;
using HZH_Controls;
using Newtonsoft.Json.Linq;
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

namespace NixieTube
{
    public partial class Form1 : Form
    {
        DigitalHelper digitalHelper;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            digitalHelper = new DigitalHelper(serialPort1, 1);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var value = "";
                for (ushort i = 0; i < 6; i++)
                {
                    value += digitalHelper[i];
                }
                //清除空字符
                value = value.Trim();

                //插入小数点
                var dot = digitalHelper.GetDot();
                if (dot > 0)
                {
                    //4500.1的小数点在C#中的索引从左数，为4
                    //但数码管存储的索引从右边数，是1
                    value = new string(value.Reverse().ToArray());
                    value = value.Insert(dot, ".");
                    value = new string(value.Reverse().ToArray());
                }

                this.Invoke(new Action(() =>
                {
                    ucledNums1.Value = value;
                    
                }));
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var value = inputNumber1.Value.ToDouble();
            var number = $"{value}".Replace(".","").Length;
            if (value < 0 && number > 6)
            {
                AntdUI.Message.error(this, "当数据小于0时，最多出现5个数字");
                return;
            }
            if(number > 6)
            {
                AntdUI.Message.error(this, "最多出现6个数字");
                return;
            }
            digitalHelper.SetNumber(value); 
        }

        private int value;

        private void checkbox1_CheckedChanged(object sender, bool value)
        {
            var cb = sender as Checkbox;
            var index = cb.Tag.ToString().ToInt();

            var v = value ? 1 : 0;
            if (cb.Checked)
            {
                this.value |= v << index;
            }
            else
            {
                this.value &= ~(1 << index);
            }

            digitalHelper.Twinkle((ushort)this.value);
        }

        private void ucledNums1_Load(object sender, EventArgs e)
        {

        }
    }
}
