using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPresentationLayer
{
	public class ModelForTesting : ModelAPI
	{
		public override bool AddCatalog(ICatalog catalog)
		{
			return true;
		}

		public override bool AddUser(IUser user)
		{
			return true;
		}

		public override bool BorrowCatalog(string title, long userId)
		{
			return true;
		}

		public override int CountAvailableCatalogs(string title)
		{
			return 10;
		}

		public override ICatalog CreateCatalog(string title, string author, int numofpages)
		{
			Catalog catalog = new Catalog(title, author, numofpages);
			return catalog;
		}

		public override IUser CreateUser(long id, string fname, string lname)
		{
			User user = new User(id, fname, lname);
			return user;
		}

		public override List<ICatalog> GetAllCatalogs()
		{
			return new List<ICatalog>();
		}

		public override List<IEvent> GetAllEvents()
		{
			return new List<IEvent>();
		}

		public override List<IState> GetAllStates()
		{
			return new List<IState>();
		}

		public override List<IUser> GetAllUsers()
		{
			return new List<IUser>();
		}

		public override ICatalog GetCatalog(string title)
		{
			return new Catalog("testGetCatalog", "test", 100);
		}

		public override IUser GetUser(long id)
		{
			return new User(1, "testGetUser", "test");
		}

		public override bool RemoveCatalog(string title)
		{
			return true;
		}

		public override bool RemoveUser(long id)
		{
			return true;
		}

		public override bool ReturnCatalog(string title, long userId)
		{
			return true;
		}
	}

	internal class User : IUser
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }


		public User(long id, string firstName, string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
		}
	}

	internal class State : IState
	{
		public long Id { get; set; }
		public string CatalogEntry { get; set; }
		public bool Available { get; set; }


		public State(string catalogEntry, bool available = true)
		{
			this.Id = 0;
			this.CatalogEntry = catalogEntry;
			this.Available = available;
		}
	}

	internal class Event : IEvent
	{
		public long Id { get; set; }
		public long StateEntry { get; set; }
		public long UserEntry { get; set; }


		public Event(long stateEntry, long userEntry)
		{
			this.Id = 0;
			this.StateEntry = stateEntry;
			this.UserEntry = userEntry;
		}
	}

	internal class Catalog : ICatalog
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public int NumberOfPages { get; set; }


		public Catalog(string title, string author, int numberOfPages)
		{
			this.Title = title;
			this.Author = author;
			this.NumberOfPages = numberOfPages;
		}
	}
}
