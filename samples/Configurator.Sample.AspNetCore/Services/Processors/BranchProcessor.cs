using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Configuration;
using Configurator.Processor;

namespace Configurator.Sample.AspNetCore.Services.Processors
{
    public class BranchProcessor : IProcessor<Arguments, Output, string>
    {
        public int Precedence => 10;

        public string Key => "branch";

        public Expression<Func<Output, string>> ArgumentSelector => (x) => x.Branch;

        public void Assign(string property, Output output)
        {
            output.Branch = property;
        }

        public Task<string> Process(Arguments arguments, CancellationToken cancellationToken)
        {
            return Task.FromResult(arguments.Branch);
        }


    }
}
