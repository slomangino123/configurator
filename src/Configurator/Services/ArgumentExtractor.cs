using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configurator.Services
{
    public class ArgumentExtractor : IArgumentExtractor<Arguments>
    {
        public const string BUILD = "build";
        public const string BRANCH = "branch";
        public Arguments Extract(IConfiguration config)
        {
            var build = TryParseBool(config, BUILD);
            var branch = config[BRANCH];

            var args = new Arguments(build, branch);
            return args;
        }

        private bool TryParseBool(IConfiguration config, string key)
        {
            if (!bool.TryParse(config[key], out bool value))
            {
                throw new ArgumentException($"Could not parse boolean value for {key}: \"{config[key]}\"");
            }

            return value;
        }
    }
}
