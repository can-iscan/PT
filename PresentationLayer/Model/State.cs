using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
	public class State
	{
		public long Id;
		public string CatalogEntry;
		public bool Available;

		public State() { }

		public State(long id, string catalog, bool available)
		{
			this.Id = id;
			this.CatalogEntry = catalog;
			this.Available = available;
		}

		internal State(ServiceLayer.State state)
		{
			this.Id = state.Id;
			this.CatalogEntry = state.CatalogEntry;
			this.Available = state.Available;
		}

		internal ServiceLayer.State getDataLayerState()
		{
			ServiceLayer.State state = new ServiceLayer.State();
			state.Id = this.Id;
			state.CatalogEntry = this.CatalogEntry;
			state.Available = this.Available;
			return state;
		}
	}
}
