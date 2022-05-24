using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	internal class DataStorageWithSQLServer : DataLayerAPI
	{
		private SQLServerDataContext db;

		public override bool Connect()
		{
			this.db = new SQLServerDataContext();

			return true;
		}

		public override string addCatalog(Catalog catalog)
		{
			this.db.Catalogs.InsertOnSubmit(catalog);
			this.db.SubmitChanges();
			return catalog.Title;
		}

		public override long addEvent(Event _event)
		{
			this.db.Events.InsertOnSubmit(_event);
			this.db.SubmitChanges();
			return _event.Id;
		}

		public override long addState(State state)
		{
			this.db.States.InsertOnSubmit(state);
			this.db.SubmitChanges();
			return state.Id;
		}

		public override long addUser(User user)
		{
			this.db.Users.InsertOnSubmit(user);
			this.db.SubmitChanges();
			return user.Id;
		}

		public override List<Catalog> getAllCatalogs()
		{
			return this.db.Catalogs.Select(o => o).ToList<Catalog>();
		}

		public override List<Event> getAllEvents()
		{
			return this.db.Events.Select(o => o).ToList<Event>();
		}

		public override List<State> getAllStates()
		{
			return this.db.States.Select(o => o).ToList<State>();
		}

		public override List<User> getAllUsers()
		{
			return this.db.Users.Select(o => o).ToList<User>();
		}

		public override Catalog getCatalog(string title)
		{
			try
			{
				return this.db.Catalogs.Single(o => o.Title == title);
			}
			catch
			{
				return null;
			}
		}

		public override Event getEvent(long id)
		{
			try
			{
				return this.db.Events.Single(o => o.Id == id);
			}
			catch
			{
				return null;
			}
		}

		public override State getState(long id)
		{
			try
			{
				return this.db.States.Single(o => o.Id == id);
			}
			catch
			{
				return null;
			}
		}

		public override User getUser(long id)
		{
			try
			{
				return this.db.Users.Single(o => o.Id == id);
			}
			catch
			{
				return null;
			}
		}

		public override bool removeCatalog(string title)
		{
			try
			{
				Catalog catalog = this.db.Catalogs.Single(o => o.Title == title);
				this.db.Catalogs.DeleteOnSubmit(catalog);
				this.db.SubmitChanges();
				return true;
			}
			catch
			{
				this.db = new SQLServerDataContext();
				return false;
			}
		}

		public override bool removeEvent(long id)
		{
			try
			{
				Event _event = this.db.Events.Single(o => o.Id == id);
				this.db.Events.DeleteOnSubmit(_event);
				this.db.SubmitChanges();
				return true;
			}
			catch
			{
				this.db = new SQLServerDataContext();
				return false;
			}
		}

		public override bool removeState(long id)
		{
			try
			{
				State state = this.db.States.Single(o => o.Id == id);
				this.db.States.DeleteOnSubmit(state);
				this.db.SubmitChanges();
				return true;
			}
			catch
			{
				this.db = new SQLServerDataContext();
				return false;
			}
		}

		public override bool removeUser(long id)
		{
			try
			{
				User user = this.db.Users.Single(o => o.Id == id);
				this.db.Users.DeleteOnSubmit(user);
				this.db.SubmitChanges();
				return true;
			}
			catch
			{
				this.db = new SQLServerDataContext();
				return false;
			}
		}

		public override bool setCatalog(string title, Catalog catalog)
		{
			Catalog updateCatalog = this.db.Catalogs.Single(o => o.Title == title);
			updateCatalog.Author = catalog.Author;
			updateCatalog.NumberOfPages = catalog.NumberOfPages;
			updateCatalog.Title = catalog.Title;
			this.db.SubmitChanges();
			return true;
		}

		public override bool setEvent(Event _event)
		{
			Event updateEvent = this.db.Events.Single(o => o.Id == _event.Id);
			updateEvent.UserEntry = _event.UserEntry;
			updateEvent.StateEntry = _event.StateEntry;
			updateEvent.Time = _event.Time;
			this.db.SubmitChanges();
			return true;
		}

		public override bool setState(State state)
		{
			State updateState = this.db.States.Single(o => o.Id == state.Id);
			updateState.Available = state.Available;
			updateState.CatalogEntry = state.CatalogEntry;
			this.db.SubmitChanges();
			return true;
		}

		public override bool setUser(User user)
		{
			User updateUser = this.db.Users.Single(o => o.Id == user.Id);
			updateUser.FirstName = user.FirstName;
			updateUser.LastName = user.LastName;
			this.db.SubmitChanges();
			return true;
		}
	}
}
