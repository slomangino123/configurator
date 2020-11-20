using System;
using System.Collections.Generic;
using System.Text;
using Configurator.Interfaces;

namespace Configurator.Configuration
{
    public class Output : IOutput
    {
        public Output()
        {
            Pairs = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Pairs { get; private set; }
        public string Branch { get; set; }
    }
}
