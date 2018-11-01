using System;
using System.Collections.Generic;
using System.Text;
using OrientDB.Net.Core.DemoDB.Vertices;

namespace OrientDB.Net.Core.DemoDB.Edges
{
	public class IsFromCountry : E
	{
		public V In { get; set; }

		public V Out { get; set; }
	}
}
