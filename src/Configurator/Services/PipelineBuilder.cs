using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Services
{
    public class PipelineBuilder<TArguments> : IPipelineBuilder
        where TArguments : IArguments
    {
        private readonly Type Project;
        public Type Argument { get; }
        public Type Output { get; }
        public IServiceCollection Services { get; }

        public PipelineBuilder(Type project, Type argument, Type output, IServiceCollection services)
        {
            Project = project;
            Output = output;
            Argument = argument;
            Services = services;
        }

        public IPipelineExecutor Build()
        {
            var serviceProvider = Services.BuildServiceProvider();

            var argumentBuilder = serviceProvider
                .GetRequiredService<IArgumentBuilder>();

            var args = argumentBuilder.Build();

            var pipelineContext = new PipelineContext<TArguments>((TArguments)args, serviceProvider);

            // Get default constructor for output type
            var ctor = Output.GetConstructor(new Type[0]);

            // Initialize the pipeline context's output object.
            pipelineContext.Output = (IOutput)ctor.Invoke(new object[0]);

            var pipelineExecutor = new PipelineExecutor(pipelineContext);

            return pipelineExecutor;
        }
    }
}
