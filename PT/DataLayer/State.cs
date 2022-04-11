using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class State
	{
		public uint Id;
		public Catalog CatalogEntry { get; set; }
		public bool Available { get; set; }

		public State(Catalog catalogEntry, bool available = true)
		{
			this.CatalogEntry = catalogEntry;
			this.Available = available;
		}

	}

	public class StateDictionary : Dictionary<uint, State>
	{

	}
}
