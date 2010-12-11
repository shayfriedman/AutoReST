using System.Collections.Generic;

namespace AutoReST.Routing
{
    public class RouteConventions
    {
        public IList<RouteMapping> Mappings { get; private set; }

        public RouteConventions()
        {
            Mappings = new List<RouteMapping>();
        }

        public RouteMapping MapAction(string actionName)
        {
            var mapping = new RouteMapping(actionName);

            Mappings.Add(mapping);

            return mapping;
        }

       

       
    }
}