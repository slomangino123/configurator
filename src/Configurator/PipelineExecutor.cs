using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator
{
    public class PipelineExecutor : IPipelineExecutor
    {
        private readonly IPipelineContext context;
        public PipelineExecutor(
            IPipelineContext context)
        {
            this.context = context;
        }

        public void Execute()
        {
            var validators = context.Services.GetServices<IArgumentValidator>();

            foreach (var validator in validators)
            {
                validator.Validate(context.GetArguments(), default).Wait();
            }
        }

        /*
        public async Task Send(IPipelineContext context, CancellationToken cancellationToken)
        {
            // Validate arguments
            foreach (var validator in argumentValidators.OrderBy(x => x.Precedence))
            {
                await validator.Validate(context.GetArguments(), cancellationToken);
            }

            // Initialize output
            // TODO: replace with configure method?
            var output = context.GetOutput();

            // Process
            foreach (var processor in processors.OrderBy(x => x.Precedence))
            {
                var value = await processor.Process((TArguments)context.GetArguments(), cancellationToken);
                output.Pairs[processor.Key] = value;
            }

            // Generate output
            foreach (var outputGenerator in outputGenerators)
            {
                await outputGenerator.GenerateOutput(context.GetOutput(), cancellationToken);
            }
        }
        */
    }
}
