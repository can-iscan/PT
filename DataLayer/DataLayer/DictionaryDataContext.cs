using System;
using System.Collections.Generic;
using System.Text;
using PT.DataLayer.Dictionary;

namespace PT.DataLayer
{
	internal class DictionaryDataContext
	{
		public CatalogDictionary	Catalogs;
		public EventDictionary		Events;
		public UserDictionary		Users;
		public StateDictionary		States;

		public DictionaryDataContext()
		{
			this.Catalogs = new CatalogDictionary();
			this.Events = new EventDictionary();
			this.Users = new UserDictionary();
			this.States = new StateDictionary();
		}
	}
}
