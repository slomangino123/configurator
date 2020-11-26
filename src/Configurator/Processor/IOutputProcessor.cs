using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Interfaces;

namespace Configurator.Processor
{
    public interface IOutputProcessor<TProperty, TOutput, TArguments> : IOutputProcessor
        where TOutput : IOutput
        where TArguments : IArguments
    {
        Expression<Func<TOutput, TProperty>> PropertySelector { get; }
        TProperty Process(TArguments arguments);
    }

    public interface IOutputProcessor
    {
        int Precedence { get; }
        void Process(IOutput output, IArguments arguments);
    }
}
