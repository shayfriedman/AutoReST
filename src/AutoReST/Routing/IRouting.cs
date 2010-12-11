using System.Web.Mvc;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public interface IRouting
    {
        string GetRouteName(ActionInfo action);
        string GetRouteUrl(ActionInfo action);
        HttpVerbs GetRouteConstraint(ActionInfo action);
        string GetRouteController(ActionInfo action);
        string GetRouteAction(ActionInfo action);
    }

}