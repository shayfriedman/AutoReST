using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoReST.Filters
{
	internal interface IModelConverter
	{
		string ContentType { get; }

		string Convert(object model);
	}
}
