using System;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Interfaces;
using Configurator.Services;
using Configurator.Services.OutputGenerators;
using Configurator.Services.Processors;
using Configurator.Services.Validators;
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
            configurationBuilder
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();
            IConfiguration config = configurationBuilder.Build();

            var executor = config.AddConfigurator<object, Arguments, Output>()
                .AddArgumentExtractor<ArgumentExtractor>()
                .AddArgumentValidator<BuildValidator>()
                .AddArgumentValidator<BranchValidator>()
                .Build();

            executor.Execute();
        }
    }
}
