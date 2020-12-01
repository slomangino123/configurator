using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Configurator.Generators.Yaml
{
    /// <summary>
    /// PostConfigure implementation for YamlGeneratorOptions
    /// Configure settings from environment variables if not explicitly set already.
    /// </summary>
    public class YamlGeneratorPostConfigureOptions : IPostConfigureOptions<YamlGeneratorOptions>
    {
        private static readonly string FILENAME_KEY = "YAML_FILENAME";
        private static readonly string PATH_KEY = "YAML_OUTPUT_PATH";
        private readonly IConfiguration configuration;

        public YamlGeneratorPostConfigureOptions(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void PostConfigure(string name, YamlGeneratorOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Filename))
            {
                var filenameFromConfig = configuration[FILENAME_KEY] ?? "yaml_output.yaml";
                options.Filename = filenameFromConfig;
            }

            if (string.IsNullOrWhiteSpace(options.Path))
            {
                var pathFromConfig = configuration[PATH_KEY] ?? "/output";
                options.Path = pathFromConfig;
            }
        }
    }
}
