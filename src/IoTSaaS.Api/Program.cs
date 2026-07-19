var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults(); // ← même chose côté WebApp

var app = builder.Build();
app.MapDefaultEndpoints(); // expose /health et /alive
app.Run();