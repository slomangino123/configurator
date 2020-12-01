using System;
using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Pipeline
{
    public class PipelineBuilder<TArguments> : IPipelineBuilder
        where TArguments : IArguments
    {
        private readonly Type Project;
        public Type Argument { get; }
        public Type Output { get; }
        public IServiceCollection Services { get; }
        public IConfigurationBuilder ConfigurationBuilder { get; }


        public PipelineBuilder(Type project, Type argument, Type output, IServiceCollection services)
        {
            Project = project;
            Output = output;
            Argument = argument;
            Services = services;
            ConfigurationBuilder = new ConfigurationBuilder();
        }

        public IPipelineExecutor Build()
        {
            BuildAndRegisterIConfiguration();

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

        private void BuildAndRegisterIConfiguration()
        {
            var configuration = ConfigurationBuilder.Build();
            Services.AddTransient<IConfiguration>((svc) => configuration);
        }
    }
}
