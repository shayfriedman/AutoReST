using System.Collections.Generic;

namespace AutoReST.Infrastructure
{
    public class ControllerParserConfiguration : IControllerParserConfiguration
    {
        public ControllerParserConfiguration()
        {
            Namespaces = new List<string>();
            Controllers = new List<string>();
        }

        
        public IList<string> Namespaces { get; set; }
        public IList<string> Controllers { get; set; }

     }
}