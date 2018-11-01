using System;
using System.Collections.Generic;
using System.Text;

namespace OrientDB.Net.Core.DemoDB.Vertices
{
	public class Orders : V
	{
		public long Amount { get; set; }

		public long Id { get; set; }

		public DateTime OrderDate { get; set; }
	}
}
