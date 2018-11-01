using System;
using System.Collections.Generic;
using System.Text;

namespace OrientDB.Net.Core.DemoDB.Vertices
{
	public class Attractions : V
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }
	}
}
