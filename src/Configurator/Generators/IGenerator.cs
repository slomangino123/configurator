using Configurator.Interfaces;

namespace Configurator.Generators
{
    public interface IGenerator<TOutput>
        where TOutput : IOutput
    {
        void Generate(TOutput output);
    }

    public interface IGenerator
    {
        void Generate(IOutput output);
    }
}
  