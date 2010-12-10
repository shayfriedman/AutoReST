using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace AutoReST.Infrastructure
{
    public class ControllerParser : IControllerParser
    {
        readonly IControllerParserConfiguration _controllerParserConfiguration;

        public ControllerParser(IControllerParserConfiguration controllerParserConfiguration)
        {
            _controllerParserConfiguration = controllerParserConfiguration;
        }

        #region IControllerParser Members

        public IList<ActionInfo> GetActions(Type controllerType)
        {
            MethodInfo[] methods = controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            return methods.Where(
                m => m.ReturnType == typeof (ActionResult) || m.ReturnType.IsSubclassOf(typeof (ActionResult)))
                .Select(action => new ActionInfo
                                  {
                                      Controller = controllerType.Name.Substring(0, controllerType.Name.IndexOf("Controller")),
                                      Name = action.Name,
                                      Parameters = action.GetParameters().Select(param => new ActionParam
                                                                                          {
                                                                                              Name = param.Name,
                                                                                              Type = param.ParameterType,
                                                                                              IsComplexType =
                                                                                                  !TypeDescriptor.
                                                                                                       GetConverter(
                                                                                                           param.
                                                                                                               ParameterType)
                                                                                                       .CanConvertFrom(
                                                                                                           typeof (
                                                                                                               string)),
                                                                                          }).ToList(),
                                      Verb = GetActionVerbs(action)
                                  }).ToList();
        }

        public IList<ActionInfo> GetActions(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();

            List<Type> controllers;

            if (_controllerParserConfiguration.Namespaces.Count > 0)
            {
                controllers =
                    types.Where(
                        t =>
                        _controllerParserConfiguration.Namespaces.Contains(t.Namespace) &&
                        t.GetInterfaces().Contains(typeof (IController))).ToList();
            }
            else if (_controllerParserConfiguration.Controllers.Count > 0)
            {
                controllers = types.Where(
                        t =>
                        _controllerParserConfiguration.Controllers.Contains(t.Name) &&
                        t.GetInterfaces().Contains(typeof(IController))).ToList();
            }
            else
            {
                controllers = types.Where(t => t.GetInterfaces().Contains(typeof (IController))).ToList();
            }

            var actions = new List<ActionInfo>();

            foreach (Type controller in controllers)
            {
                actions.AddRange(GetActions(controller));
            }

            return actions;
        }

        #endregion

        static HttpVerbs GetActionVerbs(MethodInfo action)
        {
            if (action.GetCustomAttributes(typeof (HttpPostAttribute), false).Count() > 0)
            {
                return HttpVerbs.Post;
            }
            if (action.GetCustomAttributes(typeof (HttpDeleteAttribute), false).Count() > 0)
            {
                return HttpVerbs.Delete;
            }
            if (action.GetCustomAttributes(typeof (HttpPutAttribute), false).Count() > 0)
            {
                return HttpVerbs.Put;
            }
            return HttpVerbs.Get;
        }
    }
}