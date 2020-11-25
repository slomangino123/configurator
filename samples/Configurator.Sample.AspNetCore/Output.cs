using Configurator.Interfaces;

namespace Configurator.Configuration
{
    public class Output : IOutput
    {
        public Output()
        {
        }
        public bool Build { get; set; }
        public string Branch { get; set; }
    }
}
