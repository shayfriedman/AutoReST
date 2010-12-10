using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoReST.Routing
{
    public class RoutingHttpVerbConstraint : IRouteConstraint
    {
        readonly HttpVerbs _httpVerbs;

        public RoutingHttpVerbConstraint(HttpVerbs httpVerb)
        {
            _httpVerbs = httpVerb;
        }

       
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
                          RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                var result =
                    (String.Compare(httpContext.Request.HttpMethod, _httpVerbs.ToString(),
                                    StringComparison.InvariantCultureIgnoreCase) == 0);

                return result;
            }
            return true;
        }

       
    }
}