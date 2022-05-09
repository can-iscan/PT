using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class State : IState
	{
		public uint Id { get; set; }
		public ICatalog CatalogEntry { get; set; }
		public bool Available { get; set; }


		public State(ICatalog catalogEntry, bool available = true)
		{
			this.Id = 0;
			this.CatalogEntry = catalogEntry;
			this.Available = available;
		}

	}

	public class StateDictionary : Dictionary<uint, State> {}

	public interface IState
	{
		public uint Id { get; set; }
		public ICatalog CatalogEntry { get; set; }
		public bool Available { get; set; }
	}
}
