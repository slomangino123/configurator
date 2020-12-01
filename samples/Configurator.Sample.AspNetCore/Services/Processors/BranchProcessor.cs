using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Processor;

namespace Configurator.Sample.AspNetCore.Services.Processors
{
    public class BranchProcessor : BaseOutputProcessor<string, Output, Arguments>
    {
        public override Expression<Func<Output, string>> PropertySelector => (x) => x.Branch;

        public override string Process(Arguments arguments)
        {
            return arguments.Branch;
        }
    }
}
