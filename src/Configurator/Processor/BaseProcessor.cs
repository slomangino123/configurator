using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Configurator.Interfaces;

namespace Configurator.Processor
{
    public abstract class BaseProcessor<TProperty, TOutput, TArguments>
        : IProcessor<TProperty, TOutput, TArguments>
        where TOutput : IOutput
        where TArguments : IArguments
    {
        public virtual int Precedence => 10;
        public abstract Expression<Func<TOutput, TProperty>> PropertySelector { get; }

        public abstract TProperty Process(TArguments arguments);

        public void Process(IOutput output, IArguments arguments)
        {
            var propertyValue = Process((TArguments)arguments);
            Assign(propertyValue, output);
        }

        private void Assign(TProperty propertyValue, IOutput output)
        {
            var member = PropertySelector.Body as MemberExpression;

            var property = member.Member as PropertyInfo;

            property.SetValue(output, propertyValue);
        }
    }
}
