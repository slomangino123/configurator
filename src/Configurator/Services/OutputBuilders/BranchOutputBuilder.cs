using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Configurator.Configuration;

namespace Configurator.Services.OutputBuilders
{
    public class BranchOutputBuilder : BaseOutputBuilder<string, Output, Arguments>
    {
        public override Expression<Func<Output, string>> PropertySelector => (x) => x.Branch;

        public override string Build(Arguments arguments)
        {
            var branch = arguments.Branch + "test";
            return branch;
        }
    }
}
