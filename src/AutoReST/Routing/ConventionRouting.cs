﻿using System;
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
            // TODO: Refactor this to simplify it. 
            var mappings = (from mapping in _routeConventions.Mappings
                           where mapping.ActionName == action.Name
                           select mapping).ToList();

            if (mappings.Count == 0)
                throw new MappingException(action);
      
            if (mappings.Count() == 1)
            {
                return mappings.First();
            }

            if (mappings.Count() > 1)
            {
                if (action.Parameters == null || action.Parameters.Count == 0)
                {
                    var noParamsMappings = (from mapping in mappings
                           where mapping.ActionParams == null
                           select mapping).ToList();

                    if (noParamsMappings.Count == 0)
                    {
                        throw new MappingException(action);
                    }
                    return noParamsMappings.First();
                }
                var equalParamsMappings = (from mapping in mappings
                                           where mapping.ActionParams != null && mapping.ActionParams.Count == action.Parameters.Count
                                           select mapping).ToList();
          
                foreach (var mapping in equalParamsMappings)
                {
                    var equalParams = 0;

                    foreach (var found in
                        mapping.ActionParams.Select(mappingParam => action.Parameters.Any(actionParam => mappingParam != actionParam)).Where(found => found))
                    {
                        equalParams++;
                        continue;
                    }
                    if (mapping.ActionParams.Count == equalParams)
                    {
                        return mapping;
                    }
                    
                }
            }
            throw new MappingException(action);

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