using System;
using System.Collections.Generic;
using System.Text;
using Configurator.Argument;
using Configurator.Extractor;
using Configurator.Generators;
using Configurator.Interfaces;
using Configurator.Pipeline;
using Configurator.Processor;
using Configurator.Validator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YamlDotNet.Serialization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PiplineConfigurationExtensions
    {
        public static IPipelineBuilder AddConfigurator<TProject, TArguments, TOutput>(
           this IConfiguration config)
           where TArguments : IArguments
        {
            var services = new ServiceCollection();
            services.AddTransient<IConfiguration>((svc) => config);
            services.AddTransient<IArgumentBuilder, ArgumentBuilder<TArguments>>();

            var builder = new PipelineBuilder<TArguments>(
                typeof(TProject),
                typeof(TArguments),
                typeof(TOutput),
                services);

            return builder;
        }

        public static IPipelineBuilder AddArgumentExtractor<TArgumentExtractor>(this IPipelineBuilder builder)
        {
            var sd = new ServiceDescriptor(
                typeof(IArgumentExtractor<>).MakeGenericType(builder.Argument),
                typeof(TArgumentExtractor),
                ServiceLifetime.Transient);
            builder.Services.Add(sd);
            return builder;
        }

        public static IPipelineBuilder AddArgumentValidator<TValidator>(this IPipelineBuilder builder)
            where TValidator : class, IArgumentValidator
        {
            builder.Services.AddTransient<IArgumentValidator, TValidator>();
            return builder;
        }

        public static IPipelineBuilder AddProcessor<TProcessor>(this IPipelineBuilder builder)
            where TProcessor : class, IProcessor
        {
            builder.Services.AddTransient<IProcessor, TProcessor>();
            return builder;
        }

        public static IPipelineBuilder AddGenerator<TGenerator>(this IPipelineBuilder builder)
        {
            var sd = new ServiceDescriptor(
                typeof(IGenerator<>).MakeGenericType(builder.Output),
                typeof(TGenerator),
                ServiceLifetime.Transient);
            builder.Services.Add(sd);
            return builder;
        }

        public static IPipelineBuilder AddConsoleGenerator(this IPipelineBuilder builder)
        {
            builder.Services.AddTransient<IGenerator, ConsoleGenerator>();
            return builder;
        }

        public static IPipelineBuilder AddYamlGenerator(this IPipelineBuilder builder, Action<SerializerBuilder> configureSerializer = null)
        {
            builder.Services.AddTransient<ISerializer>((svc) =>
            {
                var serializerBuilder = new SerializerBuilder();
                configureSerializer?.Invoke(serializerBuilder);
                return serializerBuilder.Build();
            });

            builder.Services.AddTransient<IGenerator, YamlGenerator>();
            return builder;
        }
    }
}
