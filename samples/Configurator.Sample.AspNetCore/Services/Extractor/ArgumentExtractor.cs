using System;
using Configurator.Configuration;
using Configurator.Extractor;
using Microsoft.Extensions.Configuration;

namespace Configurator.Sample.AspNetCore.Services.Extensions
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
