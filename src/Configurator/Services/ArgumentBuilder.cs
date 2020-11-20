﻿using System;
using System.Collections.Generic;
using System.Text;
using Configurator.Configuration;
using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configurator.Services
{
    public class ArgumentBuilder<TArguments> : IArgumentBuilder
        where TArguments : IArguments
    {
        private readonly IArgumentExtractor<TArguments> extractor;
        private readonly IConfiguration config;

        public ArgumentBuilder(
            IArgumentExtractor<TArguments> extractor,
            IConfiguration config)
        {
            this.extractor = extractor;
            this.config = config;
        }

        public IArguments Build()
        {
            var args = extractor.Extract(config);
            return args;
        }
    }
}
