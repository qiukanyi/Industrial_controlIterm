using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmExtension.Standard.Extensions;


namespace Alarm_system
{

    public class AlarmHelper
    {
       /* private static sensor sensor1;*/

     


        private ModbusMaster ModbusMaster;
        public byte Slave { get; set; }
        public AlarmHelper(ModbusMaster modbus, byte slave)
        {
            ModbusMaster = modbus;
            Slave = slave;
        }

        public void RaiseAlarm()
        {
            try
            {
                // 假设寄存器地址为0，写入值为1表示触发报警
                ushort address = 0;
                ushort value = 1;

                ModbusMaster.WriteSingleRegister(Slave, address, value);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
