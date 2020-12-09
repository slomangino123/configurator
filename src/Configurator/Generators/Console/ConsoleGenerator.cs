using System;
using Configurator.Generators.Console;
using Configurator.Interfaces;
using Microsoft.Extensions.Options;
using YamlDotNet.Serialization;

namespace Configurator.Generators.Console
{
    public class ConsoleGenerator : IGenerator
    {
        private readonly ConsoleGeneratorOptions options;
        private readonly ISerializer yamlSerializer;

        public ConsoleGenerator(IOptions<ConsoleGeneratorOptions> options,
            ISerializer yamlSerializer)
        {
            this.options = options.Value;
            this.yamlSerializer = yamlSerializer;
        }

        public void Generate(IOutput output)
        {
            string outputString;

            // TODO: Implement strategy factory to handle this.
            switch (options.OutputType)
            {
                case ConsoleOutputType.JSON: // TODO: Fix this guy.
                case ConsoleOutputType.XML: // TODO: Fix this guy.
                case ConsoleOutputType.YAML:
                default:
                    {
                        outputString = yamlSerializer.Serialize(output);
                        break;
                    }
            }

            System.Console.WriteLine(outputString);
        }
    }
}
