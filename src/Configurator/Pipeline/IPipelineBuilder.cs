using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Pipeline
{
    public interface IPipelineBuilder
    {
        IServiceCollection Services { get; }
        IConfigurationBuilder ConfigurationBuilder { get; }
        Type Argument { get; }
        Type Output { get; }
        IPipelineExecutor Build();
    }
}
