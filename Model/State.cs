using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	internal class State : IState
	{
		public long Id { get; set; }
		public string CatalogEntry { get; set; }
		public bool Available { get; set; }


		public State(string catalogEntry, bool available = true)
		{
			this.Id = 0;
			this.CatalogEntry = catalogEntry;
			this.Available = available;
		}

	}
}
