using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Configurator.Processor;
using Configurator.Sample.AspNetCore.Objects;

namespace Configurator.Sample.AspNetCore.Services.Processors
{
    public class GitProcessor : BaseOutputProcessor<Git, Output, Arguments>
    {
        public override Expression<Func<Output, Git>> OutputPropertySelector => (x) => x.Git;

        public override Git Process(Arguments arguments)
        {
            var git = new Git();
            var dateTag = arguments.Branch + '-' + DateTime.UtcNow.ToString("yyyy.mm.dd");
            var buildNumberTag = arguments.Branch + '-' + "243";

            git.Branch = arguments.Branch.Trim();
            var obj = new Git()
            {
                Branch = arguments.Branch,
                Tags = new string[] { dateTag, buildNumberTag},
            };
            return obj;
        }
    }
}
