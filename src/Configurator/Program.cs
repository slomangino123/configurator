using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Services;
using Configurator.Services.OutputBuilders;
using Configurator.Services.Validators;
using Microsoft.Extensions.Configuration;

namespace Configurator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();
            IConfiguration config = configurationBuilder.Build();

            var executor = config.AddConfigurator<object, Arguments, Output>()
                .AddArgumentExtractor<ArgumentExtractor>()
                .AddArgumentValidator<BuildValidator>()
                .AddArgumentValidator<BranchValidator>()
                .AddOutputBuilder<BranchOutputBuilder>()
                .Build();

            executor.Execute();
        }
    }
}
