using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace AutoReST.Infrastructure
{
    public class ControllerFinder : IControllerFinder
    {
        readonly IControllerFinderConfiguration _controllerFinderConfiguration;

        public ControllerFinder(IControllerFinderConfiguration controllerFinderConfiguration)
        {
            _controllerFinderConfiguration = controllerFinderConfiguration;
        }

    
        public IList<Type> GetControllers(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();

            if (_controllerFinderConfiguration.Namespaces.Count > 0)
            {
                return
                    types.Where(
                        t =>
                        _controllerFinderConfiguration.Namespaces.Contains(t.Namespace) &&
                        t.GetInterfaces().Contains(typeof (IController))).ToList();
            }
            if (_controllerFinderConfiguration.Controllers.Count > 0)
            {
                return  types.Where(
                    t =>
                    _controllerFinderConfiguration.Controllers.Contains(t.Name) &&
                    t.GetInterfaces().Contains(typeof(IController))).ToList();
            }
            return types.Where(t => t.GetInterfaces().Contains(typeof (IController))).ToList();
        }
    }

}