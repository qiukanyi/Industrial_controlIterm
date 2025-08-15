using HmExtension.Standard.Extensions;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 报警器调试工具;

public class AlarmHelper
{
    private static readonly byte[] QUERY_MODE_PARAMETER = { 0xEF, 0xFF, 0xFF, 0xA6, 0x33, 0xEF, 0x55 };

    private static readonly byte[] RESET = { 0xEF, 0xFF, 0xFF, 0xA7, 0x33, 0xEF, 0x55 };

    private static readonly int[] BAUD_RATE = [ 1200,2400,4800,9600,19200,38400,57600,115200];

    public static   AlarmHelper Instance ;

    public SerialPort _serialPort;

    private ModbusMaster _modbusMaster  ; 

    private AlarmHelper(string portName, int baudRate,byte slave) { 
     BaudRate = baudRate;
        Slave = slave;
        _serialPort = new SerialPort()
        { 
         BaudRate =baudRate,
         DataBits = 8,
         Parity =Parity.None,
         StopBits = (System.IO.Ports.StopBits)StopBits.一位,
         PortName = portName
        };
        InitModbus();
       
    }

    private void InitModbus() {

        //检查_modbusMaster是否已经连接，如果已连接，则断开连接，重新初始化

        if (_modbusMaster !=null )
        {
            _modbusMaster.Dispose();
        }

        if (!_serialPort.IsOpen)
        {
            _serialPort.Open();
        }
        
        //初始化modbus

        _modbusMaster = ModbusSerialMaster.CreateRtu(_serialPort);
    }




    public static void Init(string portName, int baudRate, byte slave) { 
    
        Instance=new AlarmHelper(portName ,baudRate ,slave );
    }
    /// <summary>
    /// 警报器波特率
    /// </summary>
    public int BaudRate 
    {
     get=> _serialPort?.BaudRate??0;
        private set {
            if (_serialPort != null) { 
             _serialPort.BaudRate = value;
            
            }
        }
    
    }
    /// <summary>
    /// 警报器模块地址
    /// </summary>
    public byte  Slave { get; private set; }
    /// <summary>
    /// /警报器音量
    /// </summary>
    public int Volume { get; private set; }
    /// <summary>
    ///   警报器循环模式 
    /// </summary>
    public  Loopmode Loop {
        get => _loop;
        private set
        { 
         _loop = value;
         OnLoopModeChanged?.Invoke(value);
        }             
            }

    private Loopmode _loop;
    public  static event Action<Loopmode> OnLoopModeChanged;


    #region 警报器设置
    //设置模块485通信波特率
    public  Task <bool> Setbaudrate(int baudRate)
    {
        //EF FF 当前模块地址 A1 XX EF 55
        var data = new byte[] { 0xEF, 0xFF, Slave, 0xA1, (byte)Array.IndexOf(BAUD_RATE,baudRate), 0xEF, 0x55 };
        return WriteAsync(data).ContinueWith(t =>
        {
            var buffer = new byte[_serialPort.BytesToRead];
            _serialPort.Read(buffer, 0, buffer.Length);

            if (data.SequenceEqual(buffer.Take(data.Length))) 
            
            {
                BaudRate = baudRate;
                _serialPort.Close();
                InitModbus(); 
                return true;
            
            }

             return false;
        });

    }

    //设置模块地址指令
    public Task<bool> SetSlave(byte slave) {
        //EF FF 当前模块地址 A2 设置地址码（8 位） EF 55
        var data = new byte[] { 0xEF, 0xFF, Slave, 0xA2 ,slave,0xEF, 0x55 };
        return WriteAsync(data).ContinueWith(t =>
        {
            var buffer =t.Result;
            return data.SequenceEqual(buffer.Take(data.Length));
        });
    }




    //查询模块参数
    // A1 波特率 A2 地址码 A3 音量 A4 循环模式 A5 5A
    public Task<bool> QueryModuleParameters( )
    {
        return  WriteAsync(QUERY_MODE_PARAMETER,10,1000).ContinueWith(task => 
        
        {
            if (task.Result !=null)
            {

                var buffer = task.Result;
                  
                   if (buffer.Length ==10)          
                   { 
                    BaudRate =BAUD_RATE[ buffer[1]];
                    Slave = buffer[3]; 
                    Volume = buffer[5];
                    Loop = (Loopmode) buffer[7] ;
                     return true; 
                    }
            }
            return false;
         });      
    }
    private bool IsWrite=true;
    private Task<byte[]> WriteAsync(byte[] data, int resultLength = 0, int timeout = 1000)
    {
        var taskSource = new TaskCompletionSource<byte[]>();
        //发送数据
        _serialPort.Write(data, 0, data.Length);
        Thread.Sleep(10);
        //开始计时
        var timer = DateTime.Now;
        //等待数据返回
        //1、当resultLength为0时，只要有任意一个数据返回就结束等待
        //2、当resultLength>0时，等待resultLength个数据返回
        //3、当等待时间超过了最长等待时间timeout,则抛出异常
        while (_serialPort.BytesToRead == 0 || (_serialPort.BytesToRead < resultLength && resultLength != 0))
        {
            Thread.Sleep(1);//为什么要等待一毫秒，释放cpu多了就会影响运行速度
            if (DateTime.Now - timer > TimeSpan.FromMilliseconds(timeout))
            {

                taskSource.TrySetException(new TimeoutException($"等待结果超时：{timeout}"));
                return taskSource.Task;
            }
        }
        var buffer = new byte[_serialPort.BytesToRead];
        _serialPort.Read(buffer, 0, buffer.Length);
        taskSource.TrySetResult(buffer);


        return taskSource.Task;
            
    }

       //恢复出厂设置
       public Task<bool> Reset() 
       {
        return WriteAsync(RESET).ContinueWith(t => { 
         var buffer=new byte[_serialPort.BytesToRead];
            _serialPort.Read(buffer, 0, buffer.Length);
            buffer.ToHexString(",").Println();
            return RESET.SequenceEqual(buffer.Take(RESET.Length));
        });
        }
    public void SetVolume(int volum) {

        if (volum<0)
        {
            volum = 0;
        }
        if (volum > 30) { 
        
         volum=30;
        }
        //ID 06 00 04 00 XX CRC_L CRC_H
        _modbusMaster.WriteSingleRegister(Slave ,0x04,(ushort)volum);
    }
    public Task<ushort> GetVolum (){
        //ID 03 00 01 00 01 CRC_L CRC_H
        return _modbusMaster.ReadHoldingRegistersAsync(Slave, 0x01, 1).ContinueWith(t =>
        {
            return t.Result[0];       
        });

    }



    //固件版本查询指令

    #endregion


    #region 控制
    public void play() {
        //ID 06 00 01 00 01 CRC_L CRC_H 
        _modbusMaster.WriteSingleRegister(Slave,0x01,0x01);
    
    }
    public void pause() {
        //ID 06 00 02 00 01 CRC_L CRC_H
        _modbusMaster.WriteSingleRegisterAsync(Slave,0x02,0x01);


    }
    /// <summary>
    /// 得到播放状态,0停止，1播放，2暂停
    /// </summary>
    /// <returns></returns>
    public Task<ushort> GetPlayStatus()
    {
        //ID 03 00 03 00 01 CRC_L CRC_H
        return _modbusMaster.ReadHoldingRegistersAsync(Slave, 0x03, 1).ContinueWith(t => t.Result[0]);
    }

    /// <summary>
    /// 停止
    /// </summary>
    public void stop() {
        //ID 06 00 03 00 01 CRC_L CRC_H
        _modbusMaster.WriteSingleRegister(Slave,0x03,0x01);


    }
    public Task<bool> SetLoopMode(Loopmode loop) {
        //ID 06 00 09 00 XX CRC_L CRC_H
        return _modbusMaster.WriteSingleRegisterAsync(Slave, 0x09, (ushort)loop).ContinueWith(t => {
         this .Loop=loop;
            return t.IsFaulted==false;
        
        });
    }

    #endregion
}

