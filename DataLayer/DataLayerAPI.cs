using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
	public abstract class DataLayerAPI
	{
		public abstract bool Connect();
		
		public abstract string addCatalog(Catalog catalog);
		public abstract bool removeCatalog(string title);
		public abstract Catalog getCatalog(string title);
		public abstract bool setCatalog(string title, Catalog catalog);
		public abstract List<Catalog> getAllCatalogs();

		public abstract long addUser(User user);
		public abstract bool removeUser(long id);
		public abstract User getUser(long id);
		public abstract bool setUser(User user);
		public abstract List<User> getAllUsers();

		public abstract long addState(State state);
		public abstract bool removeState(long id);
		public abstract State getState(long id);
		public abstract bool setState(State state);
		public abstract List<State> getAllStates();

		public abstract long addEvent(Event _event);
		public abstract bool removeEvent(long id);
		public abstract Event getEvent(long id);
		public abstract bool setEvent(Event _event);
		public abstract List<Event> getAllEvents();

		public static DataLayerAPI CreateDataLayerWithSQLServer()
		{
			return new DataStorageWithSQLServer();
		}
	}
}
