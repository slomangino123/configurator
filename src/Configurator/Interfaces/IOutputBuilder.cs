using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Interfaces
{
    public interface IOutputBuilder<TProperty, TArguments> : IOutputBuilder
    {
        TProperty Build(TArguments arguments);
    }

    public interface IOutputBuilder
    {
        int Precedence { get; }
        void Build(IOutput output, IArguments arguments);
    }
}
