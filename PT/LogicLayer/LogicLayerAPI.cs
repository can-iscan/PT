using PT.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PT.LogicLayer
{
	public abstract class LogicLayerAPI
	{
		public abstract bool borrowCatalog(Catalog catalog, User user);
		public abstract bool returnCatalog(Catalog catalog, User user);

		public abstract Catalog addCatalog(Catalog catalog);
		public abstract bool removeCatalog(Catalog catalog);

		public abstract User addUser(User user);
		public abstract bool removeUser(User user);

		public abstract int countAvailableCatalog(Catalog catalog);
		
		public abstract List<Catalog> getCatalogs();
		public abstract List<User> getUsers();
		public abstract List<Event> getEvents();
		public abstract List<State> getStates();

		public abstract Catalog getCatalog(string title);
		public abstract User getUser(uint id);
		public abstract Event getEvent(uint id);
		public abstract State getState(uint id);

		public static LogicLayerAPI CreateLayer(DataLayerAPI dataLayer)
		{
			return new DataService(dataLayer);
		}

		public static LogicLayerAPI CreateLayer()
		{
			return new DataService();
		}
	}
}
