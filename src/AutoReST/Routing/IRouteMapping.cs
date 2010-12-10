using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public interface IRouteMapping
    {
        string GetRouteName(ActionInfo action);
        string GetRouteUrl(ActionInfo action);
        object GetRouteDefaults(ActionInfo action);
        object GetRouteConstraints(ActionInfo action);
    }

}