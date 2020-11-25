using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Interfaces;

namespace Configurator.Processor
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
