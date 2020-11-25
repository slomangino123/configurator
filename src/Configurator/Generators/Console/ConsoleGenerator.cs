using System;
using Configurator.Interfaces;

namespace Configurator.Generators
{
    public class ConsoleGenerator : IGenerator
    {
        public void Generate(IOutput output)
        {
            var props = output.GetType().GetProperties();
            foreach (var prop in props)
            {
                Console.WriteLine($"{prop.Name}={prop.GetValue(output)}");
            }
        }
    }
}
