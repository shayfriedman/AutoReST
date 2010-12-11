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
        readonly IRouting _routing;

        public RouteGenerator() : this(new VerbRouting())
        {
        }

        public RouteGenerator(IRouting routing, IControllerParserConfiguration controllerParserConfiguration)
            :
                this(routing, new ControllerParser(controllerParserConfiguration))
        {
        }

        public RouteGenerator(IControllerParserConfiguration controllerParserConfiguration) :
            this(new VerbRouting(), new ControllerParser(controllerParserConfiguration))
        {
        }

        public RouteGenerator(IRouting routing) :
            this(routing, new ControllerParser(new ControllerParserConfiguration()))
        {
        }

        public RouteGenerator(IRouting routing, IControllerParser controllerParser)
        {
            _routing = routing;
            _controllerParser = controllerParser;
        }

        public void GenerateRoutesFromAssembly(Assembly assembly, RouteCollection routeCollection)
        {
       
            IList<ActionInfo> actions = _controllerParser.GetActions(assembly);


            foreach (ActionInfo action in actions)
            {

                routeCollection.MapRoute(
                    _routing.GetRouteName(action),
                    _routing.GetRouteUrl(action),
                    new { controller = _routing.GetRouteController(action), action = _routing.GetRouteAction(action)},
                    new { method = new RoutingHttpVerbConstraint(_routing.GetRouteConstraint(action))});
            }

        }
    }
}