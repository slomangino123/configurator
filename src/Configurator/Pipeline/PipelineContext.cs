using System;
using Configurator.Interfaces;

namespace Configurator.Pipeline
{
    public class PipelineContext<TArguments> : IPipelineContext
        where TArguments : IArguments
    {
        public TArguments Arguments { get; }

        public IServiceProvider Services { get; }

        public IOutput Output { get; set; }

        public PipelineContext(TArguments arguments, IServiceProvider services)
        {
            Arguments = arguments;
            Services = services;
        }

        public IArguments GetArguments() => Arguments;

        public IOutput GetOutput() => Output;
    }
}
