using System;
using System.Collections.Generic;
using System.Text;

namespace OrientDB.Net.Core.DemoDB.Vertices
{
	public class Reviews : V
	{
		public long Id { get; set; }

		public string Text { get; set; }
	}
}
