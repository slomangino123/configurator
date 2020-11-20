using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Configurator.Interfaces
{
    public interface IArgumentValidator<TArgument> : IArgumentValidator
    {
        Task Validate(TArgument argument, CancellationToken cancellationToken);
    }

    public interface IArgumentValidator
    {
        int Precedence { get; }
        Task Validate(IArguments arguments, CancellationToken cancellationToken);
    }
}
