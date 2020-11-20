using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Configurator.Interfaces
{
    public interface IProcessor<TArguments, TOutput, TProperty>
        where TArguments : IArguments
    {
        int Precedence { get; }
        string Key { get; }
        Expression<Func<TOutput, TProperty>> ArgumentSelector { get; }
        Task<string> Process(TArguments arguments, CancellationToken cancellationToken);
        void Assign(TProperty property, TOutput output);
    }
}
