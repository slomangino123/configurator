using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Interfaces
{
    public interface IPipelineContext
    {
        IArguments GetArguments();
        IOutput GetOutput();
        IServiceProvider Services { get; }
    }
}
