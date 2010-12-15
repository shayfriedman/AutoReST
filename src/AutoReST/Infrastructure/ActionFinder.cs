using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace AutoReST.Infrastructure
{
    public class ActionFinder : IActionFinder
    {
    
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

        private static IList<ActionInfo> GetActions(Type controller)
        {
            MethodInfo[] methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            return methods.Where(
                m => m.ReturnType == typeof(ActionResult) || m.ReturnType.IsSubclassOf(typeof(ActionResult)))
                .Select(action => new ActionInfo
                {
                    Controller = controller.Name.Substring(0, controller.Name.IndexOf("Controller")),
                    Name = action.Name,
                    Parameters = action.GetParameters().Select(param => new ActionParam
                    {
                        Name = param.Name,
                        IsComplexType = !TypeDescriptor.
                          GetConverter(
                                     param.
                                         ParameterType)
                                 .CanConvertFrom(
                                     typeof(
                                         string))
                    }).ToList(),
                    Verb = GetActionVerbs(action)
                }).ToList();

        }

        public IList<ActionInfo> GetActions(IList<Type> controllers)
        {
            var actions = new List<ActionInfo>();

            foreach (var controller in controllers)
            {
                actions.AddRange(GetActions(controller));
            }

            return actions;

        }
    }
}