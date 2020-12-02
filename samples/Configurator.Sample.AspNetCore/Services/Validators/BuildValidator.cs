using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Sample.AspNetCore.Objects;
using Configurator.Validator;

namespace Configurator.Sample.AspNetCore.Services.Validators
{
    public class BuildValidator : BaseArgumentValidator<bool, Arguments>
    {
        public override Expression<Func<Arguments, bool>> ArgumentSelector => (x) => x.Build;

        public override Task Validate(bool argument, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
