using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 串口案例
{
    public  interface 接口
    {
        /// <summary>
        /// 串口辅助类
        /// </summary>
        public class SerialPortHelper : IDisposable//IDisposable的作用是释放资源
        {
            //事件
            public event Action <object> OnDataReceived;

            #region 私有字段
            private SerialPort serialPort = new SerialPort()//SerialPort类是.NET Framework提供的用于读写串口的类//
            {
                BaudRate = 9600,
                PortName = "COM1",
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
            };//私有字段一般使用小驼峰命名法或下划线命名法
            #endregion
            
            
            //委托
            private List<Func<object, object>> dataHandPipe = new();


            #region 参数设置（属性）
            /// <summary>
            /// 参数设置
            /// </summary>
            public int BuadRate
            {
                get => serialPort.BaudRate;
                set => serialPort.BaudRate = value;
            }
            public string PortName
            {
                get => serialPort.PortName;
                set => serialPort.PortName = value;
            }
            public int DataBits
            {
                get => serialPort.DataBits;
                set => serialPort.DataBits = value;
            }
            public Parity Parity
            {
                get => serialPort.Parity;
                set => serialPort.Parity = value;
            }
            public StopBits StopBits
            {
                get => serialPort.StopBits;
                set => serialPort.StopBits = value;
            }
            #endregion


            #region 连接状态
            /// <summary>
            /// 打开串口
            /// </summary>
            public bool IsOpen => serialPort.IsOpen;//判断串口是否打开//另一种写法：public bool IsOpen { get { return serialPort.IsOpen; } }和public bool IsOpen => serialPort.IsOpen;效果一样
            #endregion


            #region 用静态方法创建辅助类
            private SerialPortHelper() { }//私有构造函数:serialPort是私有字段，不能在外部创建实例，只能通过Create方法创建实例

            //支持再传入SerialPort参数
            public static SerialPortHelper Create(SerialPort serialPort)//create方法是什么？：创建实例并返回实例
            {
                return new SerialPortHelper()
                {
                    serialPort = serialPort
                };
            }
            public static SerialPortHelper Create(string portName, int baudRate = 9600, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)//可变参数列表,设置默认值
            {
                return new SerialPortHelper()
                {
                    PortName = portName,
                    BuadRate = baudRate,
                    DataBits = dataBits,
                    Parity = parity,
                    StopBits = stopBits
                };
            }
            #endregion

            //抛出异常
            private void CheckOpen()
            {
                if (!IsOpen) throw new Exception("串口未打开");
            }
            #region 数据处理器
            //追加数据处理器
            public void AppendDataHandler(Func<object, object> handler)
            {
                dataHandPipe.Add(handler);
            }
            //插入数据处理器
            public void InsertDataHandler(int index, Func<object, object> handler)
            { 
            dataHandPipe.Insert(index, handler);
            
            }
            //移除数据处理器
            public void RemoveDataHandler(Func<object, object> handler)
            {
            dataHandPipe.Remove(handler);
            }
            //删除指定位置
            public void RemoveDataHandler(int index)
            {
                dataHandPipe.RemoveAt(index);
            }
            //清空数据处理器
            public void ClearDataHandler()
            {
                dataHandPipe.Clear();
            }
            #endregion




            #region 发送数据
            public void SendData(params byte[] datas)//可变参数列表,params关键字表示该参数是一个可变参数列表
            {
                CheckOpen();
                serialPort.Write(datas, 0, datas.Length);
            }
            //重载方法
            public void SendData(byte[] datas, int offset, int len)//可变参数列表
            {
                CheckOpen();
                serialPort.Write(datas, offset, len);
            }
            #endregion


            #region 打开串口
            public void Open()
            {

             serialPort.Open();
                //接受数据
                if(this.IsOpen){ 
                
                serialPort.DataReceived += SerialPortOnDataReceived;//事件处理器,类似于委托
                
                }
                
            }
            //对原始数据进行处理
            private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs e)//SerialDataReceivedEventArgs 是.NET Framework提供的事件参数类
            {
                byte[] data = new byte[serialPort.BytesToRead];//serialPort.BytesToRead是读取缓冲区中剩余的字节数
                serialPort.Read(data, 0, data.Length);
                object value =data;
                foreach (var action in dataHandPipe)
                {
                   value = action.Invoke(value);
                }
               //触发事件
                OnDataReceived?.Invoke(value);//？的作用是什么？：调用委托方法
            }
            #endregion

            #region 关闭串口
            public void Close()
            {
               serialPort . Close();
            }
            #endregion


            //实现IDisposable接口,释放资源
            public void Dispose()
            {
                Close();
            }
            




        }
    }
}
