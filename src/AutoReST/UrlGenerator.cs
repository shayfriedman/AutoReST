using System;
using System.Linq;

namespace AutoRestRoute
{
    public class UrlGenerator : IUrlGenerator
    {
        public string GenerateUrl(ActionInfo actionInfo)
        {
            var controller = actionInfo.Controller.Replace("Controller", "");

            return String.Format("{0}{1}", controller,
                                 actionInfo.Parameters.Where(p => !p.IsComplexType).Aggregate(String.Empty,
                                                                                             (current, actionParam) =>
                                                                                             current + "/{" +
                                                                                             actionParam.Name + "}"));


        }
    }
}