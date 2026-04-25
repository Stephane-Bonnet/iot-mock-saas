using DeviceSimulator;
using DeviceSimulator.Models;
using DeviceSimulator.Models.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
{
    services.Configure<SimulationConfig>(
        context.Configuration.GetSection("Simulation"));

    services.AddHostedService<SimulationWorker>();
});

await builder.Build().RunAsync();