using Configurator.Interfaces;

namespace Configurator.OutputBuilder
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
