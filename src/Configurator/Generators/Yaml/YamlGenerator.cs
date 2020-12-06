using System;
using System.IO;
using Configurator.Interfaces;
using Microsoft.Extensions.Options;
using YamlDotNet.Serialization;

namespace Configurator.Generators.Yaml
{
    public class YamlGenerator : IGenerator
    {
        private readonly ISerializer serializer;
        private readonly YamlGeneratorOptions settings;

        public YamlGenerator(
            ISerializer serializer,
            IOptions<YamlGeneratorOptions> options)
        {
            this.serializer = serializer;
            this.settings = options.Value;
        }

        public void Generate(IOutput output)
        {
            var yaml = serializer.Serialize(output);

            var path = Path.Combine(settings.Path, settings.Filename);

            File.WriteAllText(path, yaml);
        }
    }
}
