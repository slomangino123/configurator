using System;
using System.IO;
using System.Threading.Tasks;
using Configurator.Sample.AspNetCore.Objects;
using Configurator.Sample.AspNetCore.Services.Extensions;
using Configurator.Sample.AspNetCore.Services.Processors;
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
            var executor = PiplineConfigurationExtensions.AddConfigurator<Arguments, Output>()
                .AddJsonFileArguments("appsettings.json")
                .AddEnvironmentVariableArguments()
                .AddArgumentExtractor<ArgumentExtractor>()
                .AddArgumentValidator<BuildValidator>()
                .AddArgumentValidator<BranchValidator>()
                .AddProcessor<BuildProcessor>()
                .AddProcessor<TestProcessor>()
                .AddProcessor<GitProcessor>()
                .AddConsoleGenerator()
                .AddYamlGenerator(
                configBuilder =>
                {
                    configBuilder.WithNamingConvention(CamelCaseNamingConvention.Instance);
                })
                .Build();

            executor.Execute();
        }
    }
}
