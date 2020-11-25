using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Generators;
using Configurator.Sample.AspNetCore.Services.Extensions;
using Configurator.Sample.AspNetCore.Services.OutputBuilders;
using Configurator.Sample.AspNetCore.Services.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YamlDotNet.Serialization.NamingConventions;

namespace Configurator.Sample.AspNetCore
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
                .AddOutputBuilder<BranchBuilder>()
                .AddConsoleGenerator()
                .AddYamlGenerator(configBuilder =>
                {
                    configBuilder.WithNamingConvention(CamelCaseNamingConvention.Instance);
                })
                .Build();

            executor.Execute();
        }
    }
}
