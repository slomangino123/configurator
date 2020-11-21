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
        }
        public string Branch { get; set; }
    }
}
