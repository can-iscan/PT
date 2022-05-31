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
			IQueryable<Catalog> result;

			result = from catalog in this.db.Catalogs
					 select catalog;

			return result.ToList();
		}

		public override List<Event> getAllEvents()
		{
			IQueryable<Event> result;

			result = from _event in this.db.Events
					 select _event;

			return result.ToList();
		}

		public override List<State> getAllStates()
		{
			IQueryable<State> result;

			result = from state in this.db.States
					 select state;

			return result.ToList();
		}

		public override List<User> getAllUsers()
		{
			IQueryable<User> result;

			result = from user in this.db.Users
					 select user;


			return result.ToList();
		}

		public override Catalog getCatalog(string title)
		{
			try
			{
				return (from catalog in this.db.Catalogs
					   where catalog.Title == title
					   select catalog).First();
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
				return (from _event in this.db.Events
						where _event.Id == id
						select _event).First();
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
				return (from state in this.db.States
						where state.Id == id
						select state).First();
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
				return (from user in this.db.Users
						where user.Id == id
						select user).First();
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
				Catalog catalog = this.getCatalog(title);
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
				Event _event = this.getEvent(id);
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
				State state = this.getState(id);
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
				User user = this.getUser(id);
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
			Catalog updateCatalog = this.getCatalog(title);
			updateCatalog.Author = catalog.Author;
			updateCatalog.NumberOfPages = catalog.NumberOfPages;
			updateCatalog.Title = catalog.Title;
			this.db.SubmitChanges();
			return true;
		}

		public override bool setEvent(Event _event)
		{
			Event updateEvent = this.getEvent(_event.Id);
			updateEvent.UserEntry = _event.UserEntry;
			updateEvent.StateEntry = _event.StateEntry;
			updateEvent.Time = _event.Time;
			this.db.SubmitChanges();
			return true;
		}

		public override bool setState(State state)
		{
			State updateState = this.getState(state.Id);
			updateState.Available = state.Available;
			updateState.CatalogEntry = state.CatalogEntry;
			this.db.SubmitChanges();
			return true;
		}

		public override bool setUser(User user)
		{
			User updateUser = this.getUser(user.Id);
			updateUser.FirstName = user.FirstName;
			updateUser.LastName = user.LastName;
			this.db.SubmitChanges();
			return true;
		}
	}
}
