using System.Web.Mvc;

namespace AutoReST.Filters
{	
	public class AutoResultFilter : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{			
			if (filterContext.RouteData.Values.ContainsKey("format"))
			{
				string targetFormat = filterContext.RouteData.Values["format"].ToString();

				// Do not do anything if the target format is not supported
				// NOTE: Maybe throw an exception?
				if (!ModelConverterFactory.IsTargetFormatSupported(targetFormat))
					return;
				
				var converter = ModelConverterFactory.GetModelConvertor(targetFormat);
				var result = new ContentResult()
					            {
					             	ContentType = converter.ContentType,
					             	Content = converter.Convert(filterContext.Controller.ViewData.Model)
					            };

				// Replace the result
				filterContext.Result = result;
			}
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			
		}

			
	}
}
