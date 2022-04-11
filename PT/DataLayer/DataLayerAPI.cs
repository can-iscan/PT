using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public abstract class DataLayerAPI
	{
		public abstract bool Connect();
		
		public abstract Catalog addCatalog(string title, Catalog catalog);
		public abstract bool removeCatalog(string title);
		public abstract Catalog getCatalog(string title);
		public abstract bool setCatalog(Catalog catalog);
		public abstract List<Catalog> getAllCatalogs();

		public abstract User addUser(User user);
		public abstract bool removeUser(uint id);
		public abstract User getUser(uint id);
		public abstract bool setUser(User user);
		public abstract List<User> getAllUsers();

		public abstract State addState(State state);
		public abstract bool removeState(uint id);
		public abstract State getState(uint id);
		public abstract bool setState(State state);
		public abstract List<State> getAllStates();

		public abstract Event addEvent(Event _event);
		public abstract bool removeEvent(uint id);
		public abstract Event getEvent(uint id);
		public abstract bool setEvent(Event _event);
		public abstract List<Event> getAllEvents();


		public static DataLayerAPI CreateDataLayerWithCollections()
		{
			return new DataStorageWithCollections();
		}
	}
}
