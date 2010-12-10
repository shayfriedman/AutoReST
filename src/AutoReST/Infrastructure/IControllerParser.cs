using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoReST.Infrastructure
{
    public interface IControllerParser
    {
        IList<ActionInfo> GetActions(Type controllerType);
        IList<ActionInfo> GetActions(Assembly assembly);
    }
}