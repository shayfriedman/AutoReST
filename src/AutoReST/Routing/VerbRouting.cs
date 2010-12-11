using System;
using System.Linq;
using System.Web.Mvc;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public class VerbRouting : IRouting
    {
        public bool MapResourceListToPluralController { get; set; }

        public string ResourceListAction { get; set; }

        public VerbRouting()
        {
            ResourceListAction = "Index";
            MapResourceListToPluralController = true;
        }

       
        public string GetRouteName(ActionInfo action)
        {
            return StringHelpers.GetUniqueString(action.Controller, action.Name);
        }

        public string GetRouteUrl(ActionInfo action)
        {
            if (action.Name.Equals(ResourceListAction, StringComparison.CurrentCultureIgnoreCase) &&
                MapResourceListToPluralController)
            {
                return StringHelpers.Pluralize(action.Controller);
            }

            return String.Format("{0}{1}", action.Controller,
                                 action.Parameters.Where(p => !p.IsComplexType).Aggregate(String.Empty,
                                                                                          (current, actionParam) =>
                                                                                          current + "/{" +
                                                                                          actionParam.Name + "}"));
        }

        public string GetRouteController(ActionInfo action)
        {
            return action.Controller;
        }

        public string GetRouteAction(ActionInfo action)
        {
            return action.Name;
        }
        public HttpVerbs GetRouteConstraint(ActionInfo action)
        {
            return action.Verb;
        }

       
    }
}