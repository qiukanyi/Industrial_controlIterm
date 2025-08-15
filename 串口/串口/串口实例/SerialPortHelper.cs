using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 串口实例;

/// <summary>
/// 串口辅助类
/// </summary>
public class SerialPortHelper: IDisposable
{
    /// <summary>
    /// 接收处理完最终数据结果的事件
    /// </summary>
    public event Action<object> OnDataReceived;

    /// <summary>
    /// 定义SerialPort对象
    /// </summary>
    private SerialPort serialPort = new() {
        BaudRate = 9600,//波特率
        DataBits = 8,//数据位
        Parity = Parity.None,
        StopBits = StopBits.One

    };
    /// <summary>
    /// 定义一个list委托
    /// </summary>
    private List<Func<object ,object >> dataHandPipe=new();//dataHandPipe数据处理管道
                                                           //<object ,object >表示一个泛型列表，第一个Object表示有多少个泛型，就表示有多少个参数    
                                                           //最后一个表示这个委托有一个什么类型的返回值 
                                                           //例如：Func<int ,bool>表示一个返回值为bool类型，参数为int类型的委托 
                                                           //即bool func(int a);
                                                           //如果Func<int ,；long,bool>表示  bool func(int a，long b);
                                                           //func<bool> 表示bool func();
    #region 参数设置
    /// <summary>
    /// 波特率
    /// </summary>
    public int BaudRate
    {
        get => serialPort.BaudRate;
        set => serialPort.BaudRate = value; 

    }
    /// <summary>
    /// 数据位
    /// </summary>
    public int DataBits {
        get => serialPort.DataBits;
        set => serialPort.DataBits = value;
    }
    /// <summary>
    /// 校验位
    /// </summary>
    public Parity Parity {
        get => serialPort.Parity;
        set => serialPort.Parity = value;
    }
    /// <summary>
    /// 停止位
    /// </summary>
    public StopBits StopBits {
        get => serialPort.StopBits;
        set => serialPort.StopBits = value;
    }
    /// <summary>
    /// 串口名
    /// </summary>
    public string PortName {
        get => serialPort.PortName;
        set => serialPort.PortName = value;
    }
    #endregion
    /// <summary>
    /// 连接状态：是否打开
    /// </summary>
    public bool IsOpen => serialPort.IsOpen;
    /// <summary>
    /// 构造私有化
    /// </summary>
    private SerialPortHelper () {}

    /// <summary>
    /// 支持直接传一个对象
    /// </summary>
    /// <param name="serialPort"></param>
    /// <returns></returns>
    public static SerialPortHelper Create(SerialPort serialPort) { 
     
     return new SerialPortHelper()
     {

         serialPort = serialPort,
     };
    
    }
    /// <summary>
    /// 创建一个带端口的SerialPortHelper的类
    /// </summary>
    /// <param name="portName"></param>
    /// <param name="baudRate"></param>
    /// <param name="dateBits"></param>
    /// <param name="parity"></param>
    /// <param name="stopBits"></param>
    /// <returns></returns>
    public static SerialPortHelper Create(string portName,
        int baudRate=9600,
        int dateBits=8,
        Parity parity =Parity.None ,
        StopBits stopBits =StopBits.One 
        ) { 
     return new SerialPortHelper() { 
       PortName = portName,
       BaudRate = baudRate,
       DataBits =dateBits,
       Parity = parity,
       StopBits = stopBits 
     };
    
    }

    /// <summary>
    /// 判断串口是否打开    
    /// </summary>
    /// <exception cref="Exception"></exception>
    private void CheckOpen() {
        if (!IsOpen)
        {
            throw new Exception("串口未打开");
        }
    
    }
    /// <summary>
    /// 追加到末尾
    /// </summary>
    /// <param name="handler"></param>
    public void AppendDataHandler(Func<object, object> handler)
    {
        dataHandPipe.Add(handler);
    }

    /// <summary>
    /// 把最后的数据结果添加到指定的位置上
    /// </summary>
    /// <param name="index"></param>
    /// <param name="handler"></param>
    public void InsertDataHandler(int index,Func<object, object> handler) 
    {
        dataHandPipe.Insert(index,handler);   
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="handler"></param>
    public void RemoveDataHandler(Func<object, object> handler)
    { 
        dataHandPipe.Remove(handler); 
    }

    public void RemoveDataHandler(int index)
    {
        dataHandPipe.RemoveAt(index);
    }

    public void ClearDataHandler() { 
     dataHandPipe.Clear();
    
    }
    /// <summary>
    /// 发送的数据   
    /// </summary>
    /// <param name="datas"></param>
    public void SendData(params byte[] datas)//params byte[] datas可变参数列表：可以同时传任意个数的参数，后面接数组
    {

        SendData(datas ,0,datas .Length);
    }
    public void SendData(byte[] datas,int offset,int len )
    {
        CheckOpen();//判断是否打开串口
        serialPort.Write(datas, offset, len);//将读取的数据写出



    }



    /// <summary>
    /// 打开串口
    /// </summary>
    public void Open() { 
    
     serialPort .Open();
        if (this .IsOpen)
        {
            serialPort.DataReceived += SerialPortOnDataReceived;
            //对串口进行监听，如果串口打开就执行SerialPortOnDataReceived方法接收信息
        }
    }
    /// <summary>
    /// 接收数据方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
       byte[] data=new byte[serialPort.BytesToRead];//拿到接收的数据
        serialPort .Read(data, 0, data.Length);//读取数据
        object value = data;
        foreach (var action in dataHandPipe )
        {
            value=action .Invoke(value);//将上一个函数的结果作为下一个函数的参数传进去反复处理，
                                        //最终得到一个结果
        }
        OnDataReceived?.Invoke(value);//OnDataReceived最终结果的事件
    }
    /// <summary>
    /// 关闭串口
    /// </summary>
    public void Close()
    {
        serialPort .Close();
    }
    /// <summary>
    ///     Dispose接口，代码执行完自动销毁
    /// </summary>
    public void Dispose()
    {
        Close();
    }
}

