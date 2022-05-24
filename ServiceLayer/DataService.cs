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
			return this.addCatalog(catalog);
		}

		public override long addUser(User user)
		{
			return this.addUser(user);
		}

		public override List<Catalog> getAllCatalogs()
		{
			return this.dataLayer.getAllCatalogs();
		}

		public override List<Event> getAllEvents()
		{
			return this.dataLayer.getAllEvents();
		}

		public override List<State> getAllStates()
		{
			return this.dataLayer.getAllStates();
		}

		public override List<User> getAllUsers()
		{
			return this.dataLayer.getAllUsers();
		}

		public override Catalog getCatalog(string title)
		{
			return this.dataLayer.getCatalog(title);
		}

		public override Event getEvent(long id)
		{
			return this.dataLayer.getEvent(id);
		}

		public override State getState(long id)
		{
			return this.dataLayer.getState(id);
		}

		public override User getUser(long id)
		{
			return this.dataLayer.getUser(id);
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
			return this.dataLayer.setCatalog(catalog.Title, catalog);
		}

		public override bool changeUser(User user)
		{
			return this.dataLayer.setUser(user);
		}
	}
}
