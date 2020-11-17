using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configurator
{
    public class Pipeline : IPipeline
    {
        public Task Begin(IConfiguration config, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
