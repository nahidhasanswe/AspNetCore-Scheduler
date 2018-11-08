using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AspNetCore.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostBuilder = new HostBuilder().ConfigureServices(service =>
            {
                Startup startup = new Startup();
                startup.ConfigureServices(service);
                IServiceProvider serviceProvider = service.BuildServiceProvider();
            });

            hostBuilder.RunConsoleAsync().GetAwaiter().GetResult();
        }
    }
}
