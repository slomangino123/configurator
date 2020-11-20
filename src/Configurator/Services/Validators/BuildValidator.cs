using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Microsoft.Extensions.Configuration;

namespace Configurator.Services.Validators
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
