using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public abstract class ModelAPI
	{
		public abstract bool BorrowCatalog(string title, long userId);
		public abstract bool ReturnCatalog(string title, long userId);

		public abstract bool AddCatalog(ICatalog catalog);
		public abstract bool AddUser(IUser user);
		public abstract bool RemoveCatalog(string title);
		public abstract bool RemoveUser(long id);

		public abstract ICatalog GetCatalog(string title);
		public abstract IUser GetUser(long id);

		public abstract List<ICatalog> GetAllCatalogs();
		public abstract List<IUser> GetAllUsers();
		public abstract List<IState> GetAllStates();
		public abstract List<IEvent> GetAllEvents();

		public abstract int CountAvailableCatalogs(string title);

		public abstract ICatalog CreateCatalog(string title, string author, int numofpages);
		public abstract IUser CreateUser(long id, string fname, string lname);

		public static ModelAPI CreateModel()
		{
			return new Model();
		}

		public static ModelAPI CreateModel(ServiceLayer.DataServiceAPI dataService)
		{
			return new Model(dataService);
		}
	}

	public interface ICatalog
	{
		string Title { get; set; }
		string Author { get; set; }
		int NumberOfPages { get; set; }
	}

	public interface IState
	{
		long Id { get; set; }
		string CatalogEntry { get; set; }
		bool Available { get; set; }
	}

	public interface IUser
	{
		long Id { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
	}

	public interface IEvent
	{
		long Id { get; set; }
		long StateEntry { get; set; }
		long UserEntry { get; set; }
	}
}
