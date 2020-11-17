using System;
using System.Collections.Generic;
using System.Text;
using Configurator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Configuration
{
    public static class ConfigurePipeline
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IPipeline, Pipeline>();

            return services;
        }
    }
}
