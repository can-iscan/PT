using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public abstract class DataLayerAPI
	{
		public abstract bool Connect();
		
		public abstract ICatalog addCatalog(string title, ICatalog catalog);
		public abstract bool removeCatalog(string title);
		public abstract ICatalog getCatalog(string title);
		public abstract bool setCatalog(ICatalog catalog);
		public abstract List<ICatalog> getAllCatalogs();

		public abstract IUser addUser(IUser user);
		public abstract bool removeUser(uint id);
		public abstract IUser getUser(uint id);
		public abstract bool setUser(IUser user);
		public abstract List<IUser> getAllUsers();

		public abstract IState addState(IState state);
		public abstract bool removeState(uint id);
		public abstract IState getState(uint id);
		public abstract bool setState(IState state);
		public abstract List<IState> getAllStates();

		public abstract IEvent addEvent(IEvent _event);
		public abstract bool removeEvent(uint id);
		public abstract IEvent getEvent(uint id);
		public abstract bool setEvent(IEvent _event);
		public abstract List<IEvent> getAllEvents();

		public abstract IEvent createEvent(IState state, IUser user);
		public abstract IState createState(ICatalog catalog, bool available);
		public abstract IUser createUser(string fname, string lname);
		public abstract ICatalog createCatalog(string title, string author, ushort numberOfPages);


		public static DataLayerAPI CreateDataLayerWithCollections()
		{
			return new DataStorageWithCollections();
		}

		public static DataLayerAPI CreateDataLayer()
		{
			return new DataStorageGeneration();
		}
	}
}
