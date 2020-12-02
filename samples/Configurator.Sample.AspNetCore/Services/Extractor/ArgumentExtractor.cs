using System;
using Configurator.Extractor;
using Configurator.Sample.AspNetCore.Objects;
using Microsoft.Extensions.Configuration;

namespace Configurator.Sample.AspNetCore.Services.Extensions
{
    public class ArgumentExtractor : IArgumentExtractor<Arguments>
    {
        public const string BUILD = "build";
        public const string TEST = "test";
        public const string BRANCH = "branch";
        public Arguments Extract(IConfiguration config)
        {
            var build = TryParseBool(config, BUILD);
            var test = TryParseBool(config, TEST);
            var branch = config[BRANCH];

            var args = new Arguments(build, test, branch);
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
