using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Interfaces
{
    public interface IPipelineBuilder
    {
        IServiceCollection Services { get; }
        Type Argument { get; }
        IPipelineExecutor Build();
    }
}
