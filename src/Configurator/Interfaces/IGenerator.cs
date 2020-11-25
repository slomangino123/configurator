using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Configurator.Interfaces
{
    public interface IGenerator<TOutput>
        where TOutput : IOutput
    {
        void Generate(TOutput output);
    }
}
  