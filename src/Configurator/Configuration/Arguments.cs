using System;
using System.Collections.Generic;
using System.Text;
using Configurator.Interfaces;

namespace Configurator.Configuration
{
    public class Arguments : IArguments
    {
        public Arguments(bool build,
            string branch)
        {
            Build = build;
            Branch = branch;
        }

        public bool Build { get; private set; }

        public string Branch { get; private set; }
    }
}
