using HmExtension.Standard.Extensions;
using HZH_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Detectorfrom
{
    public partial class Form1 : Form
    {
        //初始化类
        DigitalHelper digitalHelper;




        private double humidity;
        public Form1()
        {
            InitializeComponent();
        }
        #region  光照温湿度传感器
        //协议
        private static readonly byte[] mb = new byte[] { 0x2, 0x3, 0x00, 0x00, 0x03 }.AppendModbusCrc();

        private void panel1_Click(object sender, EventArgs e)
        {

        }
        //打算一次全读出来
        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write(mb, 0, mb.Length);//传感器的地址是2 
          /*  var valuel = humidity.ToDouble();
            var number = $"{valuel}".Replace(".", "").Length;
            digitalHelper.SetNumber(valuel);
*/

            /*
                        #region 线程      
                        // Thread
                        // 创建一个新的线程对象
                        Thread thread = new Thread(() =>
                        {
                            var value = "";
                            for (ushort i = 0; i < 6; i++)
                            {
                                value += digitalHelper[i];
                            }
                            // 清除空字符
                            value = value.Trim();
                            // 插入小数点
                            var dot = digitalHelper.GetDot();
                            if (dot > 0)
                            {
                                // 小数点位置
                                value = new string(value.Reverse().ToArray());
                                value = value.Insert(dot, ".");
                                value = new string(value.Reverse().ToArray());
                            }
                            // 在主线程上更新界面控件
                            this.Invoke(new Action(() =>
                            {
                                ucledNums1.Value = value;
                            }));
                        });
                        #endregion*/





        }
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
         
            serialPort1.Open();
            digitalHelper = new DigitalHelper(serialPort1, 1);        
            timer1.Start();
        }
        //数据接收
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[serialPort1.BytesToRead];
            serialPort1.Read(buffer, 0, buffer.Length);
            if (buffer.Length > 0)
            {
                //   //值
                //var value = $"{number}".Replace(".", "").Replace("-", "").ToInt();//新版本的那个转记得
                var values = buffer.Skip(3).Take(6).ToArray();//取出数据
                var humidity = values.Take(2).ToArray().Reverse().ToArray().ToShort();//湿度
                var temperature = values.Skip(2).Take(2).ToArray().Reverse().ToArray().ToShort();//温度
                var light = values.Skip(4).Take(2).ToArray().Reverse().ToArray().ToShort();//光照度
                inputNumber1.Value = (decimal)(humidity / 10.0);
                inputNumber2.Value = (decimal)(temperature / 10.0);
                inputNumber3.Value = light;



                var valuel = (double )(humidity / 10.0); ;
                var number = $"{valuel}".Replace(".", "").Length;
                digitalHelper.SetNumber(valuel);
                // 刷新界面控件
            
                #region 线程      
                // Thread
                // 创建一个新的线程对象
                Task.Run(() =>
                {
                    var value = "";
                    for (ushort i = 0; i < 6; i++)
                    {
                        value += digitalHelper[i];
                    }
                    //清楚空字符
                    value = value.Trim();
                    //插入小数点
                    var dot = digitalHelper.GetDot();
                    if (dot > 0)
                    {   //4500.1的小数点在C#中的索引从左数，为4
                        //小数点位置
                        value = new string(value.Reverse().ToArray());
                        value = value.Insert(dot, ".");
                        value = new string(value.Reverse().ToArray());

                    }

                    this.Invoke(new Action(() =>
                    {

                        ucledNums1.Value = value;

                    }));
                });









                /*
                                //更新数码管
                                digitalHelper.SetNumber(humidity);//更新湿度
                                digitalHelper.SetNumber(temperature);//更新温度
                                digitalHelper.SetNumber(light);//更新光照度*/






            }
        }





    

        #region 废弃代码：
        /*
                #region 数据显示

                /// <summary>
                /// 湿度按钮被点击
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void button1_Click(object sender, EventArgs e)
                {
                    var value = inputNumber1.Value.ToDouble();
                    var number = $"{value}".Replace(".", "").Length;
                    digitalHelper.SetNumber(value);
                }

                /// <summary>
                /// 摄氏度按钮被点击
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void button2_Click(object sender, EventArgs e)
                {
                    var value = inputNumber2.Value.ToDouble();
                    var number = $"{value}".Replace(".", "").Length;
                    digitalHelper.SetNumber(value);
                }
                /// <summary>
                /// 光照度按钮被点击
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void button3_Click(object sender, EventArgs e)
                {
                    var value = inputNumber3.Value.ToDouble();
                    var number = $"{value}".Replace(".", "").Length;
                    digitalHelper.SetNumber(value);
                }
                #endregion
        */

        /*  private void timer2_Tick(object sender, EventArgs e)
          {
             // 刷新界面控件
              #region 线程      
              // Thread
              // 创建一个新的线程对象
              Thread thread = new Thread(() =>
              {
                  var value = "";
                  for (ushort i = 0; i < 6; i++)
                  {
                      value += digitalHelper[i];
                  }
                  // 清除空字符
                  value = value.Trim();
                  // 插入小数点
                  var dot = digitalHelper.GetDot();
                  if (dot > 0)
                  {
                      // 小数点位置
                      value = new string(value.Reverse().ToArray());
                      value = value.Insert(dot, ".");
                      value = new string(value.Reverse().ToArray());
                  }
                  // 在主线程上更新界面控件
                  this.Invoke(new Action(() =>
                  {
                      ucledNums1.Value = value;
                  }));
              });*/
        #endregion
     
        private void timer2_Tick(object sender, EventArgs e)
        {
        /*    var valuel = humidity.ToDouble();
            var number = $"{valuel}".Replace(".", "").Length;
            digitalHelper.SetNumber(valuel);*/
            /*// 刷新界面控件
            #region 线程      
            // Thread
            // 创建一个新的线程对象
            Task.Run(() =>
            {
                var value = "";
                for (ushort i = 0; i < 6; i++)
                {
                    value += digitalHelper[i];
                }
                //清楚空字符
                value = value.Trim();
                //插入小数点
                var dot = digitalHelper.GetDot();
                if (dot > 0)
                {   //4500.1的小数点在C#中的索引从左数，为4
                    //小数点位置
                    value = new string(value.Reverse().ToArray());
                    value = value.Insert(dot, ".");
                    value = new string(value.Reverse().ToArray());

                }

                this.Invoke(new Action(() =>
                {

                    ucledNums1.Value = value;

                }));
            });*/
            #endregion
         
        }
    }


}

#endregion