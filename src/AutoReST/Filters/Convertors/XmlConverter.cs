using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace AutoReST.Filters.Convertors
{
	internal class XmlConverter : IModelConverter
	{
		public string ContentType
		{
			get { return "text/xml"; }
		}

		public string Convert(object model)
		{
			var serializer = new XmlSerializer(model.GetType());

			var xmlOutput = new StringBuilder();
			using (var writer = new StringWriter(xmlOutput))
			{
				serializer.Serialize(writer, model);
			}
			return xmlOutput.ToString();
		}
	}
}
