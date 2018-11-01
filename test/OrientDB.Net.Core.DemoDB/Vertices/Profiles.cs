using System;
using System.Collections.Generic;
using System.Text;

namespace OrientDB.Net.Core.DemoDB.Vertices
{
	public class Profiles : V
	{
		public string Bio { get; set; }

		public DateTime Birthday { get; set; }

		public string Email { get; set; }

		public long Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }
	}
}
