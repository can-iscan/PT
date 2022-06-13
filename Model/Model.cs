using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	internal class Model : ModelAPI
	{
		public ServiceLayer.DataServiceAPI DataService;

		public Model()
		{
			this.DataService = ServiceLayer.DataServiceAPI.CreateDataService();
		}

		public Model(ServiceLayer.DataServiceAPI dataService)
		{
			this.DataService = dataService;
		}

		public override bool BorrowCatalog(string title, long userId)
		{
			return DataService.borrowCatalog(title, userId);
		}

		public override bool ReturnCatalog(string title, long userId)
		{
			return DataService.returnCatalog(title, userId);
		}

		public override bool AddCatalog(ICatalog catalog)
		{
			DataService.addCatalog(getServiceLayerCatalog(catalog));
			return true;
		}

		public override bool AddUser(IUser user)
		{
			DataService.addUser(getServiceLayerUser(user));
			return true;
		}

		public override bool RemoveCatalog(string title)
		{
			return DataService.removeCatalog(title);
		}

		public override bool RemoveUser(long id)
		{
			return DataService.removeUser(id);
		}

		public override int CountAvailableCatalogs(string title)
		{
			return DataService.countAvailableCatalog(title);
		}

		public override ICatalog GetCatalog(string title)
		{
			ServiceLayer.Catalog cat = DataService.getCatalog(title);
			return new Catalog(cat.Title, cat.Author, cat.NumberOfPages);
		}

		public override IUser GetUser(long id)
		{
			ServiceLayer.User usr = DataService.getUser(id);
			return new User(usr.Id, usr.FirstName, usr.LastName);
		}

		public override List<ICatalog> GetAllCatalogs()
		{
			List<ICatalog> catalogs = new List<ICatalog>();

			foreach (ServiceLayer.Catalog cat in DataService.getAllCatalogs())
			{
				catalogs.Add(new Catalog(cat.Title, cat.Author, cat.NumberOfPages));
			}

			return catalogs;
		}

		public override List<IUser> GetAllUsers()
		{
			List<IUser> users = new List<IUser>();

			foreach (ServiceLayer.User usr in DataService.getAllUsers())
			{
				users.Add(new User(usr.Id, usr.FirstName, usr.LastName));
			}

			return users;
		}

		public override List<IState> GetAllStates()
		{
			List<IState> states = new List<IState>();

			foreach (ServiceLayer.State state in DataService.getAllStates())
			{
				states.Add(new State(state.CatalogEntry, state.Available));
			}

			return states;
		}

		public override List<IEvent> GetAllEvents()
		{
			List<IEvent> events = new List<IEvent>();

			foreach (ServiceLayer.Event _event in DataService.getAllEvents())
			{
				events.Add(new Event(_event.StateEntry, _event.UserEntry));
			}

			return events;
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

		private static ServiceLayer.Catalog getServiceLayerCatalog(ICatalog icatalog)
		{
			ServiceLayer.Catalog catalog = new ServiceLayer.Catalog();
			catalog.Title = icatalog.Title;
			catalog.Author = icatalog.Author;
			catalog.NumberOfPages = icatalog.NumberOfPages;
			return catalog;
		}

		private static ServiceLayer.Event getServiceLayerEvent(IEvent ievent)
		{
			ServiceLayer.Event _event = new ServiceLayer.Event();
			_event.Id = ievent.Id;
			_event.StateEntry = ievent.StateEntry;
			_event.UserEntry = ievent.UserEntry;
			return _event;
		}

		private static ServiceLayer.State getServiceLayerState(IState istate)
		{
			ServiceLayer.State state = new ServiceLayer.State();
			state.Id = istate.Id;
			state.CatalogEntry = istate.CatalogEntry;
			state.Available = istate.Available;
			return state;
		}

		private static ServiceLayer.User getServiceLayerUser(IUser iuser)
		{
			ServiceLayer.User user = new ServiceLayer.User();
			user.Id = iuser.Id;
			user.FirstName = iuser.FirstName;
			user.LastName = iuser.LastName;
			return user;
		}
	}
}
