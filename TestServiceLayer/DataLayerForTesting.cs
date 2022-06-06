using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceLayer
{
	internal class DataLayerForTesting : DataLayerAPI
	{
		public DataLayerForTesting() { }

		public override string addCatalog(Catalog catalog)
		{
			return "test";
		}

		public override long addEvent(Event _event)
		{
			return 0;
		}

		public override long addState(State state)
		{
			return 0;
		}

		public override long addUser(User user)
		{
			return 0;
		}

		public override bool Connect()
		{
			return true;
		}

		public override List<Catalog> getAllCatalogs()
		{
			var list = new List<Catalog>();
			list.Add(new Catalog());
			return list;
		}

		public override List<Event> getAllEvents()
		{
			var list = new List<Event>();
			list.Add(new Event());
			return list;
		}

		public override List<State> getAllStates()
		{
			var list = new List<State>();
			var state = new State();
			state.CatalogEntry = "1984";
			state.Available = true;
			list.Add(state);
			return list ;
		}

		public override List<User> getAllUsers()
		{
			var list = new List<User>();
			list.Add(new User());
			return list;
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

		public override bool removeEvent(long id)
		{
			return true;
		}

		public override bool removeState(long id)
		{
			return true;
		}

		public override bool removeUser(long id)
		{
			return true;
		}

		public override bool setCatalog(string title, Catalog catalog)
		{
			return true;
		}

		public override bool setEvent(Event _event)
		{
			return true;
		}

		public override bool setState(State state)
		{
			return true;
		}

		public override bool setUser(User user)
		{
			return true;
		}
	}
}
