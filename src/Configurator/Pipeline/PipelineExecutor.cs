using System.Linq;
using Configurator.Generators;
using Configurator.OutputBuilder;
using Configurator.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.Pipeline
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

            foreach (var validator in validators.OrderBy(x => x.Precedence))
            {
                validator.Validate(context.GetArguments(), default).Wait();
            }

            var builders = context.Services.GetServices<IOutputBuilder>();

            foreach (var builder in builders.OrderBy(x => x.Precedence))
            {
                builder.Build(context.GetOutput(), context.GetArguments());
            }

            var generators = context.Services.GetServices(typeof(IGenerator));
            //var generators = context.Services.GetServices(typeof(IGenerator<>).MakeGenericType(context.GetOutput().GetType()));

            foreach (var generator in generators)
            {
                generator.GetType().GetMethod("Generate").Invoke(generator, new object[] { context.GetOutput() });
            }
        }
    }
}
