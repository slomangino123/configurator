using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Interfaces;

namespace Configurator.Validator
{
    public abstract class BaseArgumentValidator<TArgument, TArguments>
        : IArgumentValidator<TArgument>
        where TArguments : IArguments
    {
        public virtual int Precedence => 10;
        public abstract Expression<Func<TArguments, TArgument>> ArgumentSelector { get; }

        public async Task Validate(IArguments arguments, CancellationToken cancellationToken)
        {
            var member = ArgumentSelector.Body as MemberExpression;

            var property = member.Member as PropertyInfo;

            await Validate((TArgument)property.GetValue(arguments), cancellationToken);
        }

        public abstract Task Validate(TArgument argument, CancellationToken cancellationToken);
    }
}
