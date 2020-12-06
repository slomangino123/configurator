using System;
using System.Linq.Expressions;
using Configurator.Argument;
using Configurator.Extractor;
using Configurator.Generators;
using Configurator.Generators.Yaml;
using Configurator.Interfaces;
using Configurator.Pipeline;
using Configurator.Processor;
using Configurator.Validator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using YamlDotNet.Serialization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PiplineConfigurationExtensions
    {
        public static IPipelineBuilder AddConfigurator<TProject, TArguments, TOutput>()
           where TArguments : IArguments
        {
            var services = new ServiceCollection();
            services.AddOptions();

            services.AddTransient<IArgumentBuilder, ArgumentBuilder<TArguments>>();

            var builder = new PipelineBuilder<TArguments>(
                typeof(TProject),
                typeof(TArguments),
                typeof(TOutput),
                services);

            return builder;
        }

        public static IPipelineBuilder AddEnvironmentVariableArguments(this IPipelineBuilder builder)
        {
            builder.ConfigurationBuilder.AddEnvironmentVariables();
            return builder;
        }

        public static IPipelineBuilder AddJsonFileArguments(this IPipelineBuilder builder, string filename)
        {
            builder.ConfigurationBuilder.AddJsonFile(filename, false);
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
            where TProcessor : class, IOutputProcessor
        {
            builder.Services.AddTransient<IOutputProcessor, TProcessor>();
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

        public static IPipelineBuilder AddYamlGenerator(
            this IPipelineBuilder builder,
            Action<SerializerBuilder> configureSerializer) =>
            builder.AddYamlGenerator(x => new YamlGeneratorOptions(), configureSerializer);

        public static IPipelineBuilder AddYamlGenerator(
            this IPipelineBuilder builder,
            Action<YamlGeneratorOptions> configureSettings,
            Action<SerializerBuilder> configureSerializer)
        {
            builder.Services.AddTransient<ISerializer>((svc) =>
            {
                var serializerBuilder = new SerializerBuilder();
                configureSerializer?.Invoke(serializerBuilder);
                return serializerBuilder.Build();
            });

            builder.Services.AddSingleton<IPostConfigureOptions<YamlGeneratorOptions>, YamlGeneratorPostConfigureOptions>();

            builder.Services.Configure<YamlGeneratorOptions>(configureSettings);

            builder.Services.AddTransient<IGenerator, YamlGenerator>();
            return builder;
        }
    }
}
