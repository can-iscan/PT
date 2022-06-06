using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public abstract class DataServiceAPI
    {
		public abstract bool borrowCatalog(string catalog, long user);
		public abstract bool returnCatalog(string catalog, long user);

		public abstract int countAvailableCatalog(string catalog);

		public abstract string addCatalog(Catalog catalog);
		public abstract bool removeCatalog(string title);
		public abstract Catalog getCatalog(string title);
		public abstract bool changeCatalog(Catalog catalog);
		public abstract List<Catalog> getAllCatalogs();

		public abstract long addUser(User user);
		public abstract bool removeUser(long id);
		public abstract User getUser(long id);
		public abstract bool changeUser(User user);
		public abstract List<User> getAllUsers();

		public abstract State getState(long id);
		public abstract List<State> getAllStates();

		public abstract Event getEvent(long id);
		public abstract List<Event> getAllEvents();

		public static DataServiceAPI CreateDataService()
		{
            return new DataService();
		}

		public static DataServiceAPI CreateDataServiceWith(DataLayer.DataLayerAPI dataAPI)
		{
			return new DataService(dataAPI);
		}
	}

	public class User
	{
		public long Id;
		public string FirstName;
		public string LastName;

		public User() {}

		internal User(DataLayer.User user)
		{
			this.Id = user.Id;
			this.FirstName = user.FirstName;
			this.LastName = user.LastName;
		}

		internal DataLayer.User getDataLayerUser()
		{
			DataLayer.User user = new DataLayer.User();
			user.Id = this.Id;
			user.FirstName = this.FirstName;
			user.LastName = this.LastName;
			return user;
		}
	}

	public class Catalog
	{
		public string Title;
		public string Author;
		public int NumberOfPages;

		public Catalog() { }

		internal Catalog(DataLayer.Catalog catalog)
		{
			this.Title = catalog.Title;
			this.Author = catalog.Author;
			this.NumberOfPages = catalog.NumberOfPages;
		}

		internal DataLayer.Catalog getDataLayerCatalog()
		{
			DataLayer.Catalog catalog = new DataLayer.Catalog();
			catalog.Title = this.Title;
			catalog.Author = this.Author;
			catalog.NumberOfPages = this.NumberOfPages;
			return catalog;
		}
	}

	public class State
	{
		public long Id;
		public string CatalogEntry;
		public bool Available;

		public State() { }

		internal State(DataLayer.State state)
		{
			this.Id = state.Id;
			this.CatalogEntry = state.CatalogEntry;
			this.Available = state.Available;
		}

		internal DataLayer.State getDataLayerState()
		{
			DataLayer.State state = new DataLayer.State();
			state.Id = this.Id;
			state.CatalogEntry = this.CatalogEntry;
			state.Available = this.Available;
			return state;
		}
	}

	public class Event
	{
		public long Id;
		public long StateEntry;
		public long UserEntry;

		public Event() { }

		internal Event(DataLayer.Event _event)
		{
			this.Id = _event.Id;
			this.StateEntry = _event.StateEntry;
			this.UserEntry = _event.UserEntry;
		}

		internal DataLayer.Event getDataLayerEvent()
		{
			DataLayer.Event _event = new DataLayer.Event();
			_event.Id = this.Id;
			_event.StateEntry = this.StateEntry;
			_event.UserEntry = this.UserEntry;
			return _event;
		}
	}
}
