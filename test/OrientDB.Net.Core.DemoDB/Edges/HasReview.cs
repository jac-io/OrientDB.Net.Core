using System;
using System.Collections.Generic;
using System.Text;
using OrientDB.Net.Core.DemoDB.Vertices;

namespace OrientDB.Net.Core.DemoDB.Edges
{
	public class HasReview : E
	{
		public V In { get; set; }

		public int Stars { get; set; }

	}
}
