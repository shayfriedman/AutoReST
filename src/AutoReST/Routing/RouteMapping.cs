using System.Collections.Generic;
using System.Web.Mvc;
using AutoReST.Infrastructure;

namespace AutoReST.Routing
{
    public class RouteMapping
    {
        public HttpVerbs Verb { get; private set; }
        public string ActionName { get; private set; }
        public IList<ActionParam> ActionParams { get; private set; }
        public string Url { get; private set; }
        public UrlType UrlType{ get; private set; }
 
        public RouteMapping(string actionName)
        {
            ActionName = actionName;
            UrlType = UrlType.CustomUrl;
        }


        public RouteMapping WithParameters(IList<ActionParam> parameters)
        {
            ActionParams = parameters;

            return this;
        }

        public RouteMapping ToRootPlural()
        {
            UrlType = UrlType.PluralController;

            return this;
        }

        public RouteMapping ToCustomUrl(string url)
        {
            UrlType = UrlType.CustomUrl;
            Url = url;

            return this;
        }

        public void ConstraintToVerb(HttpVerbs httpVerb)
        {
            Verb =  httpVerb;
        }

        public RouteMapping ToRoot()
        {
            UrlType = UrlType.RootController;

            return this;
        }

        public RouteMapping WithNoParameters()
        {
            ActionParams = null;

            return this;
        }
    }
}