using PT.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PT.LogicLayer
{
	public abstract class LogicLayerAPI
	{
		public abstract bool borrowCatalog(ICatalog catalog, IUser user);
		public abstract bool returnCatalog(ICatalog catalog, IUser user);

		public abstract ICatalog addCatalog(ICatalog catalog);
		public abstract bool removeCatalog(ICatalog catalog);

		public abstract IUser addUser(IUser user);
		public abstract bool removeUser(IUser user);

		public abstract int countAvailableCatalog(ICatalog catalog);
		
		public abstract List<ICatalog> getCatalogs();
		public abstract List<IUser> getUsers();
		public abstract List<IEvent> getEvents();
		public abstract List<IState> getStates();

		public abstract ICatalog getCatalog(string title);
		public abstract IUser getUser(uint id);
		public abstract IEvent getEvent(uint id);
		public abstract IState getState(uint id);

		public abstract IEvent createEvent(IState state, IUser user);
		public abstract IState createState(ICatalog catalog, bool available);
		public abstract IUser createUser(string fname, string lname);
		public abstract ICatalog createCatalog(string title, string author, ushort numberOfPages);

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
