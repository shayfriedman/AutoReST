using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public class RouteGenerator
    {
        readonly IControllerParser _controllerParser;
        readonly IRouteMapping _routeMapping;

        public RouteGenerator() : this(new VerbRouteMapping())
        {
        }

        public RouteGenerator(IRouteMapping routeMapping, IControllerParserConfiguration controllerParserConfiguration)
            :
                this(routeMapping, new ControllerParser(controllerParserConfiguration))
        {
        }

        public RouteGenerator(IControllerParserConfiguration controllerParserConfiguration) :
            this(new VerbRouteMapping(), new ControllerParser(controllerParserConfiguration))
        {
        }

        public RouteGenerator(IRouteMapping routeMapping) :
            this(routeMapping, new ControllerParser(new ControllerParserConfiguration()))
        {
        }

        public RouteGenerator(IRouteMapping routeMapping, IControllerParser controllerParser)
        {
            _routeMapping = routeMapping;
            _controllerParser = controllerParser;
        }

        public void GenerateRoutesFromAssembly(Assembly assembly, RouteCollection routeCollection)
        {
       
            IList<ActionInfo> actions = _controllerParser.GetActions(assembly);


            foreach (ActionInfo action in actions)
            {
                routeCollection.MapRoute(
                    _routeMapping.GetRouteName(action),
                    _routeMapping.GetRouteUrl(action),
                    _routeMapping.GetRouteDefaults(action),
                    _routeMapping.GetRouteConstraints(action));
            }

        }
    }
}