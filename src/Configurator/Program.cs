using System;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile($"appsettings.json");
            IConfiguration config = configurationBuilder.Build();

            var services = new ServiceCollection();

            services.ConfigureServices();

            using (var serviceProvider = services.BuildServiceProvider())
            using (var scope = serviceProvider.CreateScope())
            {
                var pipeline = scope.ServiceProvider.GetRequiredService<IPipeline>();

                await pipeline.Begin(config, new CancellationToken());
            }
        }
    }
}
