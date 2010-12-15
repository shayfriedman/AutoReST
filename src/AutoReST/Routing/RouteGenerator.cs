using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public class RouteGenerator
    {
        readonly IControllerFinder _controllerFinder;
        readonly IActionFinder _actionFinder;
        readonly IRouting _routing;

        public RouteGenerator() : this(new ConventionRouting(new DefaultRouteConventions()),
            new ControllerFinder(new DefaultControllerFinderConfiguration()), new ActionFinder())
        {
        }

        public RouteGenerator(IRouting routing, IControllerFinder controllerFinder, IActionFinder actionFinder)
        {
            _routing = routing;
            _actionFinder = actionFinder;
            _controllerFinder = controllerFinder;
        }

        public void GenerateRoutesFromAssembly(Assembly assembly, RouteCollection routeCollection)
        {

            var controllers = _controllerFinder.GetControllers(assembly);

            IList<ActionInfo> actions = _actionFinder.GetActions(controllers);


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