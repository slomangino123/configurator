using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Configuration
{
    public class Arguments
    {
        public Arguments(bool build)
        {
            Build = build;
        }

        public bool Build { get; private set; }
    }
}
