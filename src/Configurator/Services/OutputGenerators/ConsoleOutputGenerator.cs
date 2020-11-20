using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Interfaces;

namespace Configurator.Services.OutputGenerators
{
    public class ConsoleOutputGenerator : IOutputGenerator
    {
        public Task GenerateOutput(IOutput output, CancellationToken cancellationToken)
        {
            var pairs = output.Pairs;

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.Key}={pair.Value}");
            }

            return Task.CompletedTask;
        }
    }
}
