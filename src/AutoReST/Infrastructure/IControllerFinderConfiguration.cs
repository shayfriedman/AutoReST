using System.Collections.Generic;

namespace AutoReST.Infrastructure
{
    public interface IControllerFinderConfiguration
    {
        IList<string> Namespaces { get; set; }
        IList<string> Controllers { get; set; }
    }
}