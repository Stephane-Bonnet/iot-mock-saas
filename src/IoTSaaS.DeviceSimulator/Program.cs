// src/IoTSaaS.Simulator/Program.cs
using DeviceSimulator;
using DeviceSimulator.Models.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args); // ← nouveau style

builder.Services.Configure<SimulationConfig>(
    builder.Configuration.GetSection("Simulation"));

builder.Services.AddHostedService<SimulationWorker>();

builder.AddServiceDefaults(); // ← s'appelle sur le builder, pas sur Services

await builder.Build().RunAsync();