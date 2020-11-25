using System;
using System.Collections.Generic;
using System.Text;
using Configurator.Configuration;
using Configurator.Interfaces;

namespace Configurator.Services.Generators
{
    public class ConsoleGenerator : IGenerator<Output>
    {
        public void Generate(Output output)
        {
            foreach(var prop in output.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name}={prop.GetValue(output).ToString()}");
            }
        }
    }
}
