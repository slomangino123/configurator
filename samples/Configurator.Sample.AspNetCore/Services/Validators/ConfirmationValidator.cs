using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Sample.AspNetCore.Objects;
using Configurator.Validator;

namespace Configurator.Sample.AspNetCore.Services.Validators
{
    public class ConfirmationValidator : BaseArgumentValidator<bool, Arguments>
    {
        public override Expression<Func<Arguments, bool>> ArgumentSelector => (x) => x.Confirmation;

        public override Task Validate(bool argument, CancellationToken cancellationToken)
        {
            if (argument == false)
            {
                throw new ArgumentException($"Confirmation was not provided. Value was \"{argument}\".");
            }

            return Task.CompletedTask;
        }
    }
}
