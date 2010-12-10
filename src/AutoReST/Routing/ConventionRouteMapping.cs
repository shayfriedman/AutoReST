using System;
using System.Linq;
using System.Web.Mvc;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public class ConventionRouteMapping : VerbRouteMapping
    {
        public string ResourceReadAction { get; set; }
        public string ResourceCreateAction { get; set; }
        public string ResourceUpdateAction { get; set; }
        public string ResourceDeleteAction { get; set; }
        public string ResourceUpdateDisplayUrl { get; set; }

        public ConventionRouteMapping()
        {
            ResourceListAction = "List";
            ResourceReadAction = "Details";
            ResourceCreateAction = "Create";
            ResourceUpdateAction = "Edit";
            ResourceUpdateDisplayUrl = "edit";
            ResourceDeleteAction = "Delete";
            MapResourceListToPluralController = true;
        }

        public override string GetRouteUrl(ActionInfo action)
        {
            if (action.Name.Equals(ResourceUpdateAction, StringComparison.InvariantCultureIgnoreCase) &&
                action.Parameters.Count == 1 && !action.Parameters[0].IsComplexType)
            {
         
                return String.Format("{0}/{1}", action.Controller, ResourceUpdateDisplayUrl);
              
            }
            return base.GetRouteUrl(action);
        }

        public override object GetRouteConstraints(ActionInfo action)
        {
            HttpVerbs verb = HttpVerbs.Get;

            // TODO: Refactor
            if (action.Name.Equals(ResourceListAction, StringComparison.InvariantCultureIgnoreCase) ||
                action.Name.Equals(ResourceReadAction, StringComparison.InvariantCultureIgnoreCase) ||
                (action.Name.Equals(ResourceCreateAction, StringComparison.InvariantCultureIgnoreCase) &&
                    action.Parameters.Count == 0) ||
                (action.Name.Equals(ResourceUpdateAction, StringComparison.InvariantCultureIgnoreCase) &&
                    action.Parameters.Count == 1 && !action.Parameters[0].IsComplexType))
            {
                verb = HttpVerbs.Get;
            } else if (action.Name.Equals(ResourceCreateAction, StringComparison.InvariantCultureIgnoreCase))
            {
                verb = HttpVerbs.Post;
            } else if (action.Name.Equals(ResourceUpdateAction, StringComparison.InvariantCultureIgnoreCase))
            {
                verb = HttpVerbs.Put;
            } else if (action.Name.Equals(ResourceDeleteAction, StringComparison.InvariantCultureIgnoreCase))
            {
                verb = HttpVerbs.Delete;
            }
            return new { method = new RoutingHttpVerbConstraint(verb) };
        }
    }
}