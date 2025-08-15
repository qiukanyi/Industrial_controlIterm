﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttDemo
{
    internal class EnvironmentData
    {
        public string DeviceId { get; set; }

        public double Humidity { get; set; }

        public double Temperature { get; set; }

        public ushort Light { get; set; }
    }
}
