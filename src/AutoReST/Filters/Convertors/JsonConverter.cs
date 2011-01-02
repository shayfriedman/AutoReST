using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace AutoReST.Filters.Convertors
{
	internal class JsonConverter : IModelConverter
	{
		public string ContentType
		{
			get { return "application/json"; }
		}

		public string Convert(object model)
		{
			var serializer = new JavaScriptSerializer();
			
			var jsonOutput = new StringBuilder();
			serializer.Serialize(model, jsonOutput);
			return jsonOutput.ToString();
		}
	}
}
