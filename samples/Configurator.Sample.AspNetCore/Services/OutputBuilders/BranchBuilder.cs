using System;
using System.Linq.Expressions;
using Configurator.Configuration;
using Configurator.OutputBuilder;

namespace Configurator.Sample.AspNetCore.Services.OutputBuilders
{
    public class BranchBuilder : BaseOutputBuilder<string, Output, Arguments>
    {
        public override Expression<Func<Output, string>> PropertySelector => (x) => x.Branch;

        public override string Build(Arguments arguments)
        {
            var branch = arguments.Branch + "test";
            return branch;
        }
    }
}
