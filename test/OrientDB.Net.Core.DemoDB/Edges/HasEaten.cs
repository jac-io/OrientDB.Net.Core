using System;
using System.Collections.Generic;
using System.Text;
using OrientDB.Net.Core.DemoDB.Vertices;

namespace OrientDB.Net.Core.DemoDB.Edges
{
	public class HasEaten : HasUsedService
	{
		public V In { get; set; }

	}
}
