using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm_system
{
    public class sensor
    {
        private ModbusMaster ModbusMaster;
        public bool judgment { get; set; }

        public byte Slave { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Light { get; set; }

        //串口在接受数据时，每个数据包之间至少要间隔3.5个字符时间，才能保证数据的完整性
        //96n81  9600 8n1=>1+8+1=10bit=>1个字符
        //9600/10=960个字符/秒
        //1/960=10.417ms  一个字符的时间间隔
        //3.5*1.04=3.96ms  俩个字符的时间间隔
        public sensor(ModbusMaster master, byte slave)
        {
            ModbusMaster = master;
            Slave = slave;

        }

        //获取数据;
        public void Update()
        {

            ushort[] value = ModbusMaster.ReadHoldingRegisters(Slave, 0, 3);
            Temperature = value[0] / 10D;
            Humidity = value[1] / 10D;
            Light = value[2];

        }

    }
}
