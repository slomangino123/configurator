using Configurator.Interfaces;

namespace Configurator.Sample.AspNetCore.Objects
{
    public class Arguments : IArguments
    {
        public Arguments(
            bool build,
            bool test,
            string branch,
            bool confirmation)
        {
            Build = build;
            Test = test;
            Branch = branch;
            Confirmation = confirmation;
        }

        public bool Build { get; private set; }
        public bool Test { get; private set; }
        public string Branch { get; private set; }
        public bool Confirmation { get; private set; }
    }
}
