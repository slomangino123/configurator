using System;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Pipeline
{
    public interface IPipelineBuilder
    {
        IServiceCollection Services { get; }
        Type Argument { get; }
        Type Output { get; }
        IPipelineExecutor Build();
    }
}
