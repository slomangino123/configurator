using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Processor;
using Configurator.Sample.AspNetCore.Objects;

namespace Configurator.Sample.AspNetCore.Services.Processors
{
    public class TestProcessor : BaseOutputProcessor<bool, Output, Arguments>
    {
        public override Expression<Func<Output, bool>> OutputPropertySelector => (x) => x.Test;

        public override bool Process(Arguments arguments)
        {
            return arguments.Test;
        }
    }
}
