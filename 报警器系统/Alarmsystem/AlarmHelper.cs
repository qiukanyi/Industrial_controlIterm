using HmExtension.Standard.Extensions;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alarmsystem
{
    public class AlarmHelper
    {
        //EF FF FF A6 33 EF 55
        // 定义查询模块参数常量   
        private static readonly byte[] QUERY_MODULE_CMD = { 0xEF, 0xFF, 0xFF, 0xA6, 0x33, 0xEF, 0x55 };


        //定义波特率常量
        private static readonly int[] BAUD_RATES = [1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200];
       
        //定义恢复出厂值指令常量
        private static readonly byte[] RESET_CMD = { 0xEF, 0xFF, 0xFF, 0xA7, 0x33, 0xEF, 0x55 };

        //单例模式
        public static AlarmHelper Instance;

        private SerialPort serialPort;

        private ModbusMaster ModbusMaster;
        //
        private AlarmHelper()
        {

        }
        //实例化：
        public static void Init(string portName, int baudRate, byte slave)
        {

            Instance = new AlarmHelper(portName, baudRate, slave);
        }

        //写串口数据
        public AlarmHelper(string portName, int baudRate, byte slave)//好像只能设置地址和波特率
        {
            BaudRate = baudRate;
            Slave = slave;
            serialPort = new SerialPort()
            {
                BaudRate = baudRate,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                PortName = portName,
            };
            InitModbus();
        }

        //初始化modbus
        private void InitModbus()
        {
            //检擦modbusmaster是否已经连接，如果已经连接，则重新初始化
            if (ModbusMaster != null)
            {
                ModbusMaster.Dispose();
            }
            if (!serialPort.IsOpen )
            {
                serialPort.Open();
            }
            ModbusMaster = ModbusSerialMaster.CreateRtu(serialPort);
        }


        //波特率
        public int BaudRate
        {
            get => serialPort?.BaudRate ?? 0;
            private set
            {
                if (serialPort != null)
                {
                    serialPort.BaudRate = value;
                }
            }
        }


        //地址码
        public byte Slave { get; private set; }

        //音量
        public int Volume { get; private set; }




        /// <summary>
        /// 警报器循环模式
        /// </summary>
        public LoopMod Loop 
        { 
        get=>_loop;
            private set
            { 
                _loop = value; 
                OnLoopChanged?.Invoke(value);
            }
        }

        public LoopMod _loop;

        public static    event Action<LoopMod> OnLoopChanged;

        #region 警报器设置
        //1、设置模块 485 通信波特率 
        //EF FF 当前模块地址 A1 XX EF 55 
        public Task<bool> SetBaudRate(int baudRate)
        {

            var cmd = new byte[] { 0xEF, 0xFF, Slave, 0xA1, (byte)Array.IndexOf(BAUD_RATES, baudRate), };
            return WriteAsyc(cmd).ContinueWith(t =>
            {
                var buffer = new byte[serialPort.BytesToRead];
                serialPort.Read(buffer, 0, buffer.Length);
                if (cmd.SequenceEqual(buffer.Take(cmd.Length)))
                {
                    BaudRate = baudRate;
                    serialPort.Close();
                    InitModbus();
                    return true;
                }
                return false;
            });

        }



        /// <summary>
        /// 设置模块地址
        /// </summary>
        /// <param name="slave"></param>
        /// <returns></returns>
        // 2、设置模块地址指令
        // EF FF 当前模块地址 A2 设置地址码（8 位） EF 55
        public Task<bool> SetSlave(byte slave)
        {
            var cmd = new byte[] { 0xEF, 0xFF,Slave, 0xA2, slave, 0xEF, 0x55 };
            return WriteAsyc(cmd).ContinueWith(t =>
            {
                var buffer = new byte[serialPort.BytesToRead];
                serialPort.Read(buffer, 0, buffer.Length);
                return buffer.SequenceEqual(buffer.Take(cmd.Length));
            });
        }



        // 3、查询模块参数
        //A1 波特率 A2 地址码 A3 音量 A4 循环模式 A5 5A
        public Task<bool> QueryModuleParameters()
        {
            return WriteAsyc(QUERY_MODULE_CMD,10,1000).ContinueWith(task =>
             {
                 if (task.Result != null)
                 {
                     var buffer = task.Result;
                    //var buffer = new byte[serialPort.BytesToRead];
                    //serialPort.Read(buffer, 0, buffer.Length);
                     if (buffer.Length == 10)
                     {

                         Slave = buffer[3];
                         Volume = buffer[5];
                         BaudRate = BAUD_RATES[buffer[1]];//因为是序号，所以要转一下
                         Loop = (LoopMod)buffer[7];
                         return true;
                     }
                 }
                 return false;

             });
        }
        private bool IsWrite = true;

        //封装一下
        //更改了方法
        //异步方法
        private Task<byte[]> WriteAsyc(byte[] data, int resultLength = 0, int timeout = 1000)
        {
               //其实还有一个叫令牌桶的东西，这里先不管
                var taskSource = new TaskCompletionSource<byte[]>();
           
            
                //发送数据
                serialPort.Write(data, 0, data.Length);//
                // Thread.Sleep(10);//等待10ms，等待数据发送完成
                //开始计时
                var timer = DateTime.Now;
                //等待结果
                //1.当resultLength=0时，只要有任意一个数据返回就结束等待
                //2.当resultLength>0时，等待resultLength个数据返回
                //3.当等待时间超过了最长等待时间，则抛出异常
                while (serialPort.BytesToRead == 0 || serialPort.BytesToRead < resultLength && resultLength != 0)
                {
                    Thread.Sleep(1);//为什么要等待一毫秒呢？减少cpu占用。//等多了则会减低自己代码的运行速度
                    if (DateTime.Now - timer > TimeSpan.FromMilliseconds(timeout))
                    {
                        taskSource.TrySetException(new TimeoutException($"等待结果超时：{timeout}"));
                    return taskSource.Task;
                }
                }
                var buffer = new byte[serialPort.BytesToRead];
                serialPort.Read(buffer, 0, buffer.Length);
                taskSource.TrySetResult(buffer);

         
            return taskSource.Task;
        }







        /// <summary>
        /// 恢复出厂值
        /// </summary>
        /// <returns></returns>
        //4、恢复出厂值指令
        // 发送：EF FF FF A7 33 EF 55
        public Task<bool> Reset()
        {
            return WriteAsyc(RESET_CMD).ContinueWith(t =>
            {
                var buffer = new byte[serialPort.BytesToRead];
                serialPort.Read(buffer, 0, buffer.Length);
                buffer .ToHexString (",").Println ();
                return RESET_CMD.SequenceEqual(buffer.Take(RESET_CMD.Length));

            });

        }

        //5、固件版本查询指令


        //6、设置音量指令
        // ID 06 00 04 00 XX CRC_L CRC_H
        public void SetVolume(int volume)
        {
            if (volume < 0) volume = 0;
            if (volume > 30) volume = 30;
            ModbusMaster.WriteSingleRegister(Slave, 0x04, (ushort)volume);
        }

        //读取音量
        //ID 03 00 01 00 01 CRC_L CRC_H 
        public Task<ushort> GetVolume()
        {
            return ModbusMaster.ReadHoldingRegistersAsync(Slave, 0x01, 1).ContinueWith(t =>
            {
                return t.Result[0];
            });
        }

        #endregion


        #region 控制警报器
        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="isOpen"></param>
        /// <returns></returns>
        /// ID 06 00 01 00 01 CRC_L CRC_H 
        public void Paly()
        {
            ModbusMaster.WriteSingleRegister(Slave, 0x01, 0x01);

        }
        /// <summary>
        /// 暂停
        /// </summary>
        /// ID 06 00 02 00 01 CRC_L CRC_H 
        public void Stop()
        {
            ModbusMaster.WriteSingleRegister(Slave, 0x02, 0x01);
        }
        /// <summary>
        /// 读取播放状态
        /// 0 停止
        /// 1 播放
        /// 3 暂停
        /// </summary>
        /// ID 03 00 03 00 01 CRC_L CRC_H
        public Task<ushort> GetPlayStatus()
        {
            return ModbusMaster.ReadHoldingRegistersAsync(Slave, 0x03, 0x01)
                .ContinueWith(t => t.Result[0] );
        }

        //停止  
        //ID 06 00 03 00 01 CRC_L CRC_H
    public void cease()
    {
       ModbusMaster .WriteSingleRegister(Slave, 0x03, 0x01);
    }

        //设置循环模式
        //ID 06 00 09 00 XX CRC_L CRC_H 
        public Task<bool> SetLoopMode(LoopMod loop) {
            return   ModbusMaster.WriteSingleRegisterAsync (Slave, 0x09, (ushort)loop)
            .ContinueWith(t =>
            {
                this.Loop = loop;
                return t.IsFaulted ==false ;
            });
           
        }

        #endregion


    }
}

