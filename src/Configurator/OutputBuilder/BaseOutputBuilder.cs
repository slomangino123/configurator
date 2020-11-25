using System;
using System.Linq.Expressions;
using System.Reflection;
using Configurator.Interfaces;

namespace Configurator.OutputBuilder
{
    public abstract class BaseOutputBuilder<TProperty, TOutput, TArguments>
        : IOutputBuilder<TProperty, TArguments>
        where TOutput : IOutput
    {
        public virtual int Precedence => 10;
        public abstract Expression<Func<TOutput, TProperty>> PropertySelector { get; }

        public void Build(IOutput output, IArguments arguments)
        {
            var member = PropertySelector.Body as MemberExpression;

            var property = member.Member as PropertyInfo;

            var propertyValue = Build((TArguments)arguments);

            property.SetValue(output, propertyValue);
        }

        public abstract TProperty Build(TArguments arguments);
    }
}
