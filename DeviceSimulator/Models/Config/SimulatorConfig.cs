using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator.Models.Config
{
    public class SimulationConfig
    {
        public int GatewayCount { get; set; }
        public int DevicesPerGateway { get; set; }
        public int ScanIntervalMs { get; set; }
    }
}
