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

		public override Catalog addCatalog(Catalog catalog)
		{
			this.DataRepositoryEntry.DataLayer.addCatalog(catalog.Title, catalog);
			this.DataRepositoryEntry.DataLayer.addState(new State(catalog, true));
			return catalog;
		}


		public override bool removeCatalog(Catalog catalog)
		{
			return this.DataRepositoryEntry.DataLayer.removeCatalog(catalog.Title);
		}

		public override bool borrowCatalog(Catalog catalog, User user)
		{

			if (this.countAvailableCatalog(catalog) > 0)
			{
				State newState = new State(catalog, false);
				this.DataRepositoryEntry.DataLayer.addState(newState);
				this.DataRepositoryEntry.DataLayer.addEvent(new Event(newState, user));
				return true;
			}

			return false;
		}

		public override bool returnCatalog(Catalog catalog, User user)
		{
			State newState = new State(catalog, true);
			this.DataRepositoryEntry.DataLayer.addState(newState);
			this.DataRepositoryEntry.DataLayer.addEvent(new Event(newState, user));

			return true;
		}

		public override int countAvailableCatalog(Catalog catalog)
		{
			List<State> states = this.DataRepositoryEntry.DataLayer.getAllStates();

			int available = 0, notAvailable = 0;

			foreach (State state in states)
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

		public override List<User> getUsers()
		{
			return this.DataRepositoryEntry.DataLayer.getAllUsers();
		}

		public override List<Event> getEvents()
		{
			return this.DataRepositoryEntry.DataLayer.getAllEvents();
		}

		public override List<State> getStates()
		{
			return this.DataRepositoryEntry.DataLayer.getAllStates();
		}

		public override List<Catalog> getCatalogs()
		{
			return this.DataRepositoryEntry.DataLayer.getAllCatalogs();
		}

		public override User getUser(uint id)
		{
			foreach (User user in this.DataRepositoryEntry.DataLayer.getAllUsers())
			{
				if (user.Id == id)
					return user;
			}

			throw new Exception("Element not found!");
		}

		public override Event getEvent(uint id)
		{
			foreach (Event _event in this.DataRepositoryEntry.DataLayer.getAllEvents())
			{
				if (_event.Id == id)
					return _event;
			}

			throw new Exception("Element not found!");
		}

		public override State getState(uint id)
		{
			foreach (State state in this.DataRepositoryEntry.DataLayer.getAllStates())
			{
				if (state.Id == id)
					return state;
			}

			throw new Exception("Element not found!");
		}

		public override Catalog getCatalog(string title)
		{
			foreach (Catalog catalog in this.DataRepositoryEntry.DataLayer.getAllCatalogs())
			{
				if (catalog.Title == title)
					return catalog;
			}

			throw new Exception("Element not found!");
		}

		public override User addUser(User user)
		{
			return this.DataRepositoryEntry.DataLayer.addUser(user);
		}

		public override bool removeUser(User user)
		{
			return this.DataRepositoryEntry.DataLayer.removeUser(user.Id);
		}
	}
}
