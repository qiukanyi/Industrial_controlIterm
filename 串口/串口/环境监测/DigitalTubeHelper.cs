using HmExtension.Standard.Extensions;
using Modbus.Device;
using Modbus.Extensions.Enron;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 环境监测;

    internal class DigitalTubeHelper
    {
    private ModbusMaster  _master;
    public byte Slave { get;  set; }
    public DigitalTubeHelper(ModbusMaster master  ,byte slave)
    {

        _master = master;
        Slave = slave;
    }
    public void SetValue(Double value,char prefix)
    {
        //6,7
        var doIndex = value.ToString().Reverse().IndexOf('.');
        if (doIndex ==-1)
        {
          doIndex = 0;
        }
        var sign = value < 0 ? 1 : 0;
       ushort intValue =value.ToString().Replace(".","").ToUShort();
        byte[] bytes =new byte[4];
        bytes[1] = (byte)((sign << 4) | doIndex);
        var b=BitConverter.GetBytes(intValue);
        bytes[2]= b[0];
        bytes[3]= b[1];
        _master.WriteMultipleRegisters(Slave, 6, new ushort[] {
         bytes.ToUShort(),
         bytes.ToUShort(2),       
        });
        Thread.Sleep(4);
        _master.WriteSingleRegister(Slave ,0,prefix);
    }



    }

