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

            var path = string.IsNullOrEmpty(settings.Path) ? Directory.GetCurrentDirectory() : settings.Path;

            if (!path.EndsWith('/'))
            {
                path = path + '/';
            }

            var filename = settings.Filename;

            if (!filename.EndsWith(".yaml") && !filename.EndsWith(".yml"))
            {
                filename += ".yaml";
            }

            path = path + filename;

            File.WriteAllText(path, yaml);
        }
    }
}
