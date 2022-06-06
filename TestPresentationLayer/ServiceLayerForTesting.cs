using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPresentationLayer
{
	class ServiceLayerForTesting : DataServiceAPI
	{
		public override string addCatalog(Catalog catalog)
		{
			return "test";
		}

		public override long addUser(User user)
		{
			return 1;
		}

		public override bool borrowCatalog(string catalog, long user)
		{
			return true;
		}

		public override bool changeCatalog(Catalog catalog)
		{
			return true;
		}

		public override bool changeUser(User user)
		{
			return true;
		}

		public override int countAvailableCatalog(string catalog)
		{
			return 1;
		}

		public override List<Catalog> getAllCatalogs()
		{
			return new List<Catalog>();
		}

		public override List<Event> getAllEvents()
		{
			return new List<Event>();
		}

		public override List<State> getAllStates()
		{
			return new List<State>();
		}

		public override List<User> getAllUsers()
		{
			return new List<User>();
		}

		public override Catalog getCatalog(string title)
		{
			return new Catalog();
		}

		public override Event getEvent(long id)
		{
			return new Event();
		}

		public override State getState(long id)
		{
			return new State();
		}

		public override User getUser(long id)
		{
			return new User();
		}

		public override bool removeCatalog(string title)
		{
			return true;
		}

		public override bool removeUser(long id)
		{
			return true;
		}

		public override bool returnCatalog(string catalog, long user)
		{
			return true;
		}
	}
}
