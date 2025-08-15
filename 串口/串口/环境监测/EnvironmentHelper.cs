using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using V8.Net;
using Modbus.Data;
using Modbus.Device;

namespace 环境监测;

    internal class EnvironmentHelper
    {
    private ModbusMaster _master;
    public byte Slave { get;  set; }
    public double Temperature { get;  set; }
    public double Humidity { get;  set; }
     public double Light { get;  set;}
    public EnvironmentHelper(ModbusMaster master  ,byte slave)
    {

        _master = master;
        Slave = slave;
    }
    public void Update() {
        ushort[] values = _master.ReadHoldingRegisters(Slave ,0,3);
        Humidity = values[0] / 10D;
        Temperature = values[1] / 10D;
        Light = values[2];
    
    
    }
     




    }

