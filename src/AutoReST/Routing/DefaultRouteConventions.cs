using System.Collections.Generic;
using System.Web.Mvc;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public class DefaultRouteConventions: RouteConventions
    {
        public DefaultRouteConventions()
        {

            MapAction("List").ToRootPlural().ConstraintToVerb(HttpVerbs.Get);

            MapAction("Details").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Get);

            MapAction("Delete").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Delete);

            MapAction("Update").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToCustomUrl("/edit").ConstraintToVerb(HttpVerbs.Get);

            MapAction("Update").WithParameters(
                new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = false, Name = "id"},
                    new ActionParam() { IsComplexType = true, Name = "employee"}
                }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Put);

            MapAction("Create").WithNoParameters().ToCustomUrl("/new").ConstraintToVerb(HttpVerbs.Get);

            MapAction("Create").WithParameters(new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = true, Name = "Employee"}
                }).ToRoot().ConstraintToVerb(HttpVerbs.Post);
  
        }
    }
}