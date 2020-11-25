using System.Linq;
using Configurator.Generators;
using Configurator.Processor;
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

            var processors = context.Services.GetServices<IProcessor>();
            foreach (var processor in processors.OrderBy(x => x.Precedence))
            {
                processor.Process(context.GetOutput(), context.GetArguments());
            }

            var generators = context.Services.GetServices<IGenerator>();
            foreach (var generator in generators)
            {
                generator.Generate(context.GetOutput());
            }

            var customGenerators = context.Services.GetServices(typeof(IGenerator<>).MakeGenericType(context.GetOutput().GetType()));
            foreach (var customGenerator in customGenerators)
            {
                customGenerator.GetType().GetMethod("Generate").Invoke(customGenerator, new object[] { context.GetOutput() });
            }
        }
    }
}
