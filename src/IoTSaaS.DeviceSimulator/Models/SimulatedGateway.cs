using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator.Models
{
    internal class SimulatedGateway
    {
        public string GatewayId { get; }
        private readonly List<SimulatedDevice> _devices;
        private readonly Random _random = new();

        public SimulatedGateway(string id, int deviceCount)
        {
            GatewayId = id;

            _devices = Enumerable.Range(0, deviceCount)
                .Select(i => new SimulatedDevice($"{id}-dev-{i}"))
                .ToList();
        }

        public async Task RunSimulationAsync(CancellationToken token, int scanIntervalMs)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    foreach (var device in _devices)
                    {
                        // simulation perte BLE (10%)
                        if (_random.NextDouble() < 0.1)
                            continue;

                        var msg = device.CreateFakeMessage(GatewayId);

                        // 👉 ici on simulera Kafka plus tard
                        Console.WriteLine(
                            $"{msg.Timestamp}({DateTimeOffset.FromUnixTimeMilliseconds(msg.Timestamp):HH:mm:ss}) | {msg.GatewayId} | {msg.DeviceId} | {msg.Temperature:F1}°C | {msg.Battery}% | {msg.Rssi} dBm"
                        );
                    }

                    // scan BLE toutes les scanIntervalMs ms
                    await Task.Delay(scanIntervalMs, token);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Gateway {GatewayId} stopped.");
            }
        }
    }
}
