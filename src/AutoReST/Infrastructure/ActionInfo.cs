using System.Collections.Generic;
using System.Web.Mvc;

namespace AutoReST.Infrastructure
{
    public class ActionInfo
    {
        public ActionInfo()
        {
            Verb = HttpVerbs.Get;
        }

        public string Name { get; set; }
        public string Controller { get; set; }
        public HttpVerbs Verb { get; set; }
        public IList<ActionParam> Parameters { get; set; }
    }
}