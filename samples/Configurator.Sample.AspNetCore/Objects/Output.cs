using System.Collections.Generic;
using Configurator.Interfaces;

namespace Configurator.Sample.AspNetCore.Objects
{
    public class Output : IOutput
    {
        public Output()
        {
        }
        public bool Build { get; set; }
        public bool Test { get; set; }
        //public IDictionary<string, Git> Git { get; set; }
        public Git Git { get; set; }
    }
}
