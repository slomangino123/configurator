using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Interfaces
{
    public interface IOutput
    {
        IDictionary<string, string> Pairs { get; }
    }
}
