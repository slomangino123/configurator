using System;
using System.Collections.Generic;
using System.Text;
using Configurator.Interfaces;
using Configurator.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Configuration
{
    public static class ConfigurePipelineExtensions
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
            var sd = new ServiceDescriptor(typeof(IArgumentExtractor<>).MakeGenericType(builder.Argument), typeof(TArgumentExtractor), ServiceLifetime.Transient);
            builder.Services.Add(sd);
            return builder;
        }

        public static IPipelineBuilder AddArgumentValidator<TValidator>(this IPipelineBuilder builder)
            where TValidator : class, IArgumentValidator
        {
            builder.Services.AddTransient<IArgumentValidator, TValidator>();
            return builder;
        }

        public static IPipelineBuilder AddOutputBuilder<TBuilder>(this IPipelineBuilder builder)
            where TBuilder : class, IOutputBuilder
        {
            builder.Services.AddTransient<IOutputBuilder, TBuilder>();
            return builder;
        }
    }
}
