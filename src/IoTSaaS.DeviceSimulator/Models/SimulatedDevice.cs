using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator.Models
{
    internal class SimulatedDevice
    {
        public string DeviceId { get; }
        private double _battery = 100;
        private readonly Random _random;

        public SimulatedDevice(string id)
        {
            DeviceId = id;
            _random = new Random(Guid.NewGuid().GetHashCode());
        }

        public IoTMessage CreateFakeMessage(string gatewayId)
        {
            // décharge progressive
            _battery -= 0.005 + _random.NextDouble() * 0.02;
            if (_battery < 0) _battery = 100;

            var voltage = 3.0 + (_battery / 100.0) * 1.2; // approx 3.0–4.2V

            return new IoTMessage
            {
                GatewayId = gatewayId,
                DeviceId = DeviceId,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),

                Temperature = 15 + _random.NextDouble() * 10,
                Battery = (int)_battery,
                Voltage = voltage,

                Rssi = -40 - _random.Next(0, 60)
            };
        }
    }
}
