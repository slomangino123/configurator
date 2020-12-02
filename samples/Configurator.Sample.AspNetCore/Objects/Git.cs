using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Sample.AspNetCore.Objects
{
    public class Git
    {
        public string Branch { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
