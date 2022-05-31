using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	internal class DataService : DataServiceAPI
	{
		private DataLayerAPI dataLayer;

		public DataService()
		{
			this.dataLayer = DataLayerAPI.CreateDataLayerWithSQLServer();
			this.dataLayer.Connect();
		}

		public override string addCatalog(Catalog catalog)
		{
			return this.dataLayer.addCatalog(catalog.getDataLayerCatalog());
		}

		public override long addUser(User user)
		{
			return this.dataLayer.addUser(user.getDataLayerUser());
		}

		public override List<Catalog> getAllCatalogs()
		{
			List<Catalog> catalogs = new List<Catalog>();
			foreach (DataLayer.Catalog obj in this.dataLayer.getAllCatalogs())
			{
				catalogs.Add(new Catalog(obj));
			}
			return catalogs;
		}

		public override List<Event> getAllEvents()
		{
			List<Event> events = new List<Event>();
			foreach (DataLayer.Event obj in this.dataLayer.getAllEvents())
			{
				events.Add(new Event(obj));
			}
			return events;
		}

		public override List<State> getAllStates()
		{
			List<State> states = new List<State>();
			foreach (DataLayer.State obj in this.dataLayer.getAllStates())
			{
				states.Add(new State(obj));
			}
			return states;
		}

		public override List<User> getAllUsers()
		{
			List<User> users = new List<User>();
			foreach (DataLayer.User obj in this.dataLayer.getAllUsers())
			{
				users.Add(new User(obj));
			}
			return users;
		}

		public override Catalog getCatalog(string title)
		{
			return new Catalog(this.dataLayer.getCatalog(title));
		}

		public override Event getEvent(long id)
		{
			return new Event(this.dataLayer.getEvent(id));
		}

		public override State getState(long id)
		{
			return new State(this.dataLayer.getState(id));
		}

		public override User getUser(long id)
		{
			return new User(this.dataLayer.getUser(id));
		}

		public override bool removeCatalog(string title)
		{
			return this.dataLayer.removeCatalog(title);
		}

		public override bool removeUser(long id)
		{
			return this.dataLayer.removeUser(id);
		}

		public override bool changeCatalog(Catalog catalog)
		{
			return this.dataLayer.setCatalog(catalog.Title, catalog.getDataLayerCatalog());
		}

		public override bool changeUser(User user)
		{
			return this.dataLayer.setUser(user.getDataLayerUser());
		}
	}
}
