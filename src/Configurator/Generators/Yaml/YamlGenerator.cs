using System;
using Configurator.Interfaces;
using YamlDotNet.Serialization;

namespace Configurator.Generators
{
    public class YamlGenerator : IGenerator
    {
        private readonly ISerializer serializer;

        public YamlGenerator(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public void Generate(IOutput output)
        {
            var yaml = serializer.Serialize(output);
            Console.WriteLine(yaml);
        }
    }
}
