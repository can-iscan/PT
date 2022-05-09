using PT.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT.LogicLayer
{
	class DataService : LogicLayerAPI
	{
		private DataRepository DataRepositoryEntry;

		public DataService()
		{
			DataRepositoryEntry = new DataRepository(DataLayerAPI.CreateDataLayerWithCollections());
		}

		public DataService(DataLayerAPI dataLayer)
		{
			DataRepositoryEntry = new DataRepository(dataLayer);
		}

		public override ICatalog addCatalog(ICatalog catalog)
		{
			this.DataRepositoryEntry.DataLayer.addCatalog(catalog.Title, catalog);
			IState state = this.DataRepositoryEntry.DataLayer.createState(catalog, true);
			this.DataRepositoryEntry.DataLayer.addState(state);
			return catalog;
		}


		public override bool removeCatalog(ICatalog catalog)
		{
			return this.DataRepositoryEntry.DataLayer.removeCatalog(catalog.Title);
		}

		public override bool borrowCatalog(ICatalog catalog, IUser user)
		{

			if (this.countAvailableCatalog(catalog) > 0)
			{
				IState newState = this.DataRepositoryEntry.DataLayer.createState(catalog, false);
				this.DataRepositoryEntry.DataLayer.addState(newState);
				IEvent _event = this.DataRepositoryEntry.DataLayer.createEvent(newState, user);
				this.DataRepositoryEntry.DataLayer.addEvent(_event);
				return true;
			}

			return false;
		}

		public override bool returnCatalog(ICatalog catalog, IUser user)
		{
			IState newState = this.DataRepositoryEntry.DataLayer.createState(catalog, true);
			this.DataRepositoryEntry.DataLayer.addState(newState);
			IEvent _event = this.DataRepositoryEntry.DataLayer.createEvent(newState, user);
			this.DataRepositoryEntry.DataLayer.addEvent(_event);

			return true;
		}

		public override int countAvailableCatalog(ICatalog catalog)
		{
			List<IState> states = this.DataRepositoryEntry.DataLayer.getAllStates();

			int available = 0, notAvailable = 0;

			foreach (IState state in states)
			{
				if (state.CatalogEntry.Title == catalog.Title)
				{
					if (state.Available)
						available++;
					else
						notAvailable++;
				}
			}

			return available - notAvailable;
		}

		public override List<IUser> getUsers()
		{
			return this.DataRepositoryEntry.DataLayer.getAllUsers();
		}

		public override List<IEvent> getEvents()
		{
			return this.DataRepositoryEntry.DataLayer.getAllEvents();
		}

		public override List<IState> getStates()
		{
			return this.DataRepositoryEntry.DataLayer.getAllStates();
		}

		public override List<ICatalog> getCatalogs()
		{
			return this.DataRepositoryEntry.DataLayer.getAllCatalogs();
		}

		public override IUser getUser(uint id)
		{
			foreach (IUser user in this.DataRepositoryEntry.DataLayer.getAllUsers())
			{
				if (user.Id == id)
					return user;
			}

			throw new Exception("Element not found!");
		}

		public override IEvent getEvent(uint id)
		{
			foreach (IEvent _event in this.DataRepositoryEntry.DataLayer.getAllEvents())
			{
				if (_event.Id == id)
					return _event;
			}

			throw new Exception("Element not found!");
		}

		public override IState getState(uint id)
		{
			foreach (IState state in this.DataRepositoryEntry.DataLayer.getAllStates())
			{
				if (state.Id == id)
					return state;
			}

			throw new Exception("Element not found!");
		}

		public override ICatalog getCatalog(string title)
		{
			foreach (ICatalog catalog in this.DataRepositoryEntry.DataLayer.getAllCatalogs())
			{
				if (catalog.Title == title)
					return catalog;
			}

			throw new Exception("Element not found!");
		}

		public override IUser addUser(IUser user)
		{
			return this.DataRepositoryEntry.DataLayer.addUser(user);
		}

		public override bool removeUser(IUser user)
		{
			return this.DataRepositoryEntry.DataLayer.removeUser(user.Id);
		}

		public override IEvent createEvent(IState state, IUser user)
		{
			return this.DataRepositoryEntry.DataLayer.createEvent(state, user);
		}

		public override IState createState(ICatalog catalog, bool available)
		{
			return this.DataRepositoryEntry.DataLayer.createState(catalog, available);
		}

		public override IUser createUser(string fname, string lname)
		{
			return this.DataRepositoryEntry.DataLayer.createUser(fname, lname);
		}

		public override ICatalog createCatalog(string title, string author, ushort numberOfPages)
		{
			return this.DataRepositoryEntry.DataLayer.createCatalog(title, author, numberOfPages);
		}
	}
}
