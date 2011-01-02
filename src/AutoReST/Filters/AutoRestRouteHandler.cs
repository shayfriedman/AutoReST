using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoReST.Filters
{
	public class AutoRestRouteHandler : MvcRouteHandler
	{
		protected override System.Web.IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
		{
			string action = requestContext.RouteData.GetRequiredString("action");
			string targetFormat;
			if (TryGetFormat(action, out targetFormat))
			{
				string url = requestContext.HttpContext.Request.Url.ToString().Replace("." + targetFormat, "");
				string querystring = ConvertDictionaryToString(requestContext.HttpContext.Request.QueryString);

				var context = new HttpContextWrapper(new HttpContext(new HttpRequest("", url, querystring), new HttpResponse(new StringWriter())));

				requestContext.RouteData = RouteTable.Routes.GetRouteData(context);
				requestContext.RouteData.Values.Add("format", targetFormat);
			}

			return base.GetHttpHandler(requestContext);
		}

		private string ConvertDictionaryToString(NameValueCollection queryString)
		{
			StringBuilder output = new StringBuilder();
			bool first = true;
			foreach (var item in queryString.AllKeys)
			{
				output.AppendFormat("{0}{1}={2}", first ? String.Empty : "&", item, queryString[item]);
				first = false;
			}
			return output.ToString();
		}

		private bool TryGetFormat(string controllerName, out string format)
		{
			int lastDotPosition = controllerName.LastIndexOf('.');
			if (lastDotPosition > -1)
			{
				format = controllerName.Substring(lastDotPosition + 1);
				return true;
			}

			format = String.Empty;
			return false;
		}


	}
}
