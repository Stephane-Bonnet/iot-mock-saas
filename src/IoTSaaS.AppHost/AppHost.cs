// src/IoTSaaS.AppHost/Program.cs
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// --- Infrastructure (commenté pour l'instant, décommente quand tu ajoutes Kafka/Redis)
// var redis = builder.AddRedis("cache");
// var kafka = builder.AddKafka("broker");

// --- Services
var api = builder.AddProject<Projects.IoTSaaS_Api>("api");
// .WithReference(redis)    ← quand Redis sera prêt
// .WithReference(kafka)

builder.AddProject<Projects.IoTSaaS_DeviceSimulator>("simulator");
// .WithReference(kafka)

builder.Build().Run();
