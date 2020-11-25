using System;
using Configurator.Interfaces;

namespace Configurator.Pipeline
{
    public interface IPipelineContext
    {
        IArguments GetArguments();
        IOutput GetOutput();
        IServiceProvider Services { get; }
    }
}
