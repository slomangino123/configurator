using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Configurator.Interfaces
{
    public interface IArgumentExtractor<TArguments>
        where TArguments : IArguments
    {
        TArguments Extract(IConfiguration config);
    }
}
