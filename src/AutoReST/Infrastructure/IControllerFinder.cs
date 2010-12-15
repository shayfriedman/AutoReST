using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace AutoReST.Infrastructure
{
    public interface IControllerFinder
    {
        IList<Type> GetControllers(Assembly assembly);
    }
}