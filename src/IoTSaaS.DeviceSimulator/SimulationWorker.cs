using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator
{
    using DeviceSimulator.Models;
    using DeviceSimulator.Models.Config;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    public class SimulationWorker : BackgroundService
    {
        private readonly SimulationConfig _config;

        public SimulationWorker(IOptions<SimulationConfig> config)
        {
            _config = config.Value;
            Console.WriteLine(_config.Display());
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Simulation will start in 2 seconds!\n");
            await Task.Delay(2000, stoppingToken);

            var gateways = Enumerable.Range(0, _config.GatewayCount)
                .Select(i => new SimulatedGateway($"gw-{i}", _config.DevicesPerGateway))
                .ToList();

            var tasks = gateways
                .Select(gw => gw.RunSimulationAsync(stoppingToken, _config.ScanIntervalMs))
                .ToList();

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Stopped cleanly.");
            }
        }
    }
}
