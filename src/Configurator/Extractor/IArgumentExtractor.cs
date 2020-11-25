using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configurator.Extractor
{
    public interface IArgumentExtractor<TArguments>
        where TArguments : IArguments
    {
        TArguments Extract(IConfiguration config);
    }
}
