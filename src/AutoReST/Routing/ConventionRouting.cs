using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoReST.Infrastructure;
using AutoReST.Routing;

namespace AutoReST.Routing
{   
    public class ConventionRouting: IRouting
    {
        readonly RouteConventions _routeConventions;

        public ConventionRouting()
        {
            _routeConventions = new RouteConventions();

            _routeConventions.MapAction("List").ToRootPlural().ConstraintToVerb(HttpVerbs.Get);
            
            _routeConventions.MapAction("Details").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id"}}
                
                
                ).ToRoot().ConstraintToVerb(HttpVerbs.Get);

            _routeConventions.MapAction("Update").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id"}}
                
                
                ).ToCustomUrl("/edit").ConstraintToVerb(HttpVerbs.Get);

            _routeConventions.MapAction("Update").WithParameters(
                new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = false, Name = "id"},
                    new ActionParam() { IsComplexType = true, Name = "employee"}
                }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Put);
            
            _routeConventions.MapAction("Create").WithNoParameters().ToCustomUrl("/new").ConstraintToVerb(HttpVerbs.Get);
            
            _routeConventions.MapAction("Create").WithParameters(new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = true, Name = "Employee"}
                }).ToRoot().ConstraintToVerb(HttpVerbs.Post);
        }

        public ConventionRouting(RouteConventions routeConventions)
        {
            _routeConventions = routeConventions;
        }

        public string GetRouteName(ActionInfo action)
        {
            return StringHelpers.GetUniqueString(action.Controller, action.Name);
        }

        public string GetRouteUrl(ActionInfo action)
        {
            var mapping = GetMappingByNameAndParameters(action);

            switch (mapping.UrlType)
            {
                case UrlType.PluralController:
                    return StringHelpers.Pluralize(action.Controller);
                case UrlType.CustomUrl:
                case UrlType.RootController:
                    if (action.Parameters != null)
                    {
                        return String.Format("{0}{1}{2}", action.Controller, mapping.Url, action.Parameters.Where(p => !p.IsComplexType).Aggregate(String.Empty,
                                                                                                     (current, actionParam) =>
                                                                                                     current + "/{" +
                                                                                                     actionParam.Name + "}"));
                    }
                    return String.Format("{0}{1}", action.Controller, mapping.Url);
                                 
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        RouteMapping GetMappingByNameAndParameters(ActionInfo action)
        {
            foreach(var m in _routeConventions.Mappings)
            {
                if (m.ActionName == action.Name)
                {
                    if (m.ActionParams != null && action.Parameters != null)
                    {
                        if (m.ActionParams.Count == action.Parameters.Count)
                        {
                            foreach(var p in m.ActionParams)
                            {
                                if (!action.Parameters.Contains(p))
                                {
                                    break;
                                }
                            }
                            return m;
                        }
                    }
                    return m;
                }
            }
            throw new InvalidOperationException("Mapping not found");

        }

        public HttpVerbs GetRouteConstraint(ActionInfo action)
        {
            var mapping = GetMappingByNameAndParameters(action);

            return mapping.Verb;
        }

        public string GetRouteController(ActionInfo action)
        {
            return action.Controller;
        }

        public string GetRouteAction(ActionInfo action)
        {
            return action.Name;
        }
    }
}