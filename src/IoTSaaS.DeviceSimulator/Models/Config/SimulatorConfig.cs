namespace DeviceSimulator.Models.Config
{
    public class SimulationConfig
    {
        public int GatewayCount { get; set; }
        public int DevicesPerGateway { get; set; }
        public int ScanIntervalMs { get; set; }

        public string Display()
        {
            return $"""
                Active config: 
                    Gateways: {GatewayCount}
                    Devices per gateway: {DevicesPerGateway}
                    Scan Interval: {ScanIntervalMs} ms
                """;
        }
    }
}
