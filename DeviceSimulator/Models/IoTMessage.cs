using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator.Models
{
    internal class IoTMessage
    {
        public string GatewayId { get; set; }
        public string DeviceId { get; set; }
        public long Timestamp { get; set; }

        public double Temperature { get; set; }
        
        public int Battery { get; set; }
        public int Rssi { get; set; }
        public double Voltage { get; set; }
    }
}
