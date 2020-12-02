using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Processor;
using Configurator.Sample.AspNetCore.Objects;

namespace Configurator.Sample.AspNetCore.Services.Processors
{
    public class BuildProcessor : BaseOutputProcessor<bool, Output, Arguments>
    {
        public override Expression<Func<Output, bool>> OutputPropertySelector => (x) => x.Build;

        public override bool Process(Arguments arguments)
        {
            return arguments.Build || arguments.Test;
        }
    }
}
