using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Sample.AspNetCore.Objects;
using Configurator.Validator;

namespace Configurator.Sample.AspNetCore.Services.Validators
{
    public class BranchValidator : BaseArgumentValidator<string, Arguments>
    {
        public override Expression<Func<Arguments, string>> ArgumentSelector => (x) => x.Branch;

        public override Task Validate(string argument, CancellationToken cancellationToken)
        {
            if (argument == "master")
            {
                throw new ArgumentException($"We do not deploy master!");
            }

            return Task.CompletedTask;
        }
    }
}
