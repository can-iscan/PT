using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class DataContext
	{
		public CatalogDictionary	Catalogs;
		public EventDictionary		Events;
		public UserDictionary		Users;
		public StateDictionary		States;

		public DataContext()
		{
			this.Catalogs = new CatalogDictionary();
			this.Events = new EventDictionary();
			this.Users = new UserDictionary();
			this.States = new StateDictionary();
		}
	}
}
