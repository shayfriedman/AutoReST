using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReST.Filters.Convertors;

namespace AutoReST.Filters
{
	internal static class ModelConverterFactory
	{
		public static IModelConverter GetModelConvertor(string targetFormat)
		{
			if (String.IsNullOrEmpty(targetFormat))
				throw new ArgumentNullException("targetFormat");

			ConverterTargets convertor;
			if (!Enum.TryParse(targetFormat, true, out convertor))
				throw new ArgumentException("The target format is not supported.", "targetFormat");

			switch (convertor)
			{
				case ConverterTargets.Xml: 
					return new XmlConverter();
				case ConverterTargets.Json: 
					return new JsonConverter();
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public static bool IsTargetFormatSupported(string targetFormat)
		{
			ConverterTargets convertor;
			return Enum.TryParse(targetFormat, true, out convertor);
		}

	}
}
