using System;
using System.Linq;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public class VerbRouteMapping : IRouteMapping
    {
        int _uniqueId;

        public bool MapResourceListToPluralController { get; set; }

        public string ResourceListAction { get; set; }

        public VerbRouteMapping()
        {
            ResourceListAction = "Index";
            MapResourceListToPluralController = true;
        }

       
        public virtual string GetRouteName(ActionInfo action)
        {
            _uniqueId++;
            return String.Format("{0}.{1}.{2}", action.Controller, action.Name, _uniqueId);
        }

        public virtual string GetRouteUrl(ActionInfo action)
        {
            if (action.Name.Equals(ResourceListAction, StringComparison.CurrentCultureIgnoreCase) &&
                MapResourceListToPluralController)
            {
                return Pluralize(action.Controller);
            }

            return String.Format("{0}{1}", action.Controller,
                                 action.Parameters.Where(p => !p.IsComplexType).Aggregate(String.Empty,
                                                                                          (current, actionParam) =>
                                                                                          current + "/{" +
                                                                                          actionParam.Name + "}"));
        }

        public string Pluralize(string singular)
        {
            return singular + "s";
        }

        public virtual object GetRouteDefaults(ActionInfo action)
        {
            return new {controller = action.Controller, action = action.Name};
        }

        public virtual object GetRouteConstraints(ActionInfo action)
        {
            return new {method = new RoutingHttpVerbConstraint(action.Verb)};
        }

       
    }
}