using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace AutoReST.Infrastructure
{
    public interface IActionFinder
    {
        IList<ActionInfo> GetActions(IList<Type> controllers);
    }
}