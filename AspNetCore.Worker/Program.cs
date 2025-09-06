using AspNetCore.Worker;
using AspNetCore.Scheduler;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddScheduler<TestScheduler>("*/1 * * * *"); // Runs every minute

var host = builder.Build();
await host.RunAsync();
