using DataLayer.DataLayer;
using PT.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.DataLayer
{
	internal class DataStorageWithSQLServer : DataLayerAPI
	{
		private SQLServerDataContext db;

		public override bool Connect()
		{
			this.db = new SQLServerDataContext();

			return true;
		}

		public override ICatalog addCatalog(string title, ICatalog catalog)
		{
			Catalog newCatalog = new Catalog();

			newCatalog.Author = catalog.Author;
			newCatalog.Title = catalog.Title;
			newCatalog.NumberOfPages = catalog.NumberOfPages;

			db.Catalogs.InsertOnSubmit(newCatalog);
			db.SubmitChanges();
			return catalog;
		}

		public override IEvent addEvent(IEvent _event)
		{
			throw new NotImplementedException();
		}

		public override IState addState(IState state)
		{
			throw new NotImplementedException();
		}

		public override IUser addUser(IUser user)
		{
			User newUser = new User();

			newUser.FirstName = user.FirstName;
			newUser.LastName = user.LastName;

			db.Users.InsertOnSubmit(newUser);
			db.SubmitChanges();
			return user;
		}

		public override ICatalog createCatalog(string title, string author, ushort numberOfPages)
		{
			Catalog catalog = new Catalog();

			catalog.Title = title;
			catalog.Author = author;
			catalog.NumberOfPages = numberOfPages;

			return (ICatalog)catalog;
		}

		public override IEvent createEvent(IState state, IUser user)
		{
			throw new NotImplementedException();
		}

		public override IState createState(ICatalog catalog, bool available)
		{
			throw new NotImplementedException();
		}

		public override IUser createUser(string fname, string lname)
		{
			throw new NotImplementedException();
		}

		public override List<ICatalog> getAllCatalogs()
		{
			throw new NotImplementedException();
		}

		public override List<IEvent> getAllEvents()
		{
			throw new NotImplementedException();
		}

		public override List<IState> getAllStates()
		{
			throw new NotImplementedException();
		}

		public override List<IUser> getAllUsers()
		{
			var list = from user in this.db.Users
						select user;

			return (List<IUser>)list;
		}

		public override ICatalog getCatalog(string title)
		{
			throw new NotImplementedException();
		}

		public override IEvent getEvent(uint id)
		{
			throw new NotImplementedException();
		}

		public override IState getState(uint id)
		{
			throw new NotImplementedException();
		}

		public override IUser getUser(uint id)
		{
			throw new NotImplementedException();
		}

		public override bool removeCatalog(string title)
		{
			Catalog catalog;

			try
			{
				catalog = db.Catalogs.Single(o => o.Title == title);
			}
			catch (Exception e)
			{
				return false;
			}

			db.Catalogs.DeleteOnSubmit(catalog);
			db.SubmitChanges();

			return true;
		}

		public override bool removeEvent(uint id)
		{
			throw new NotImplementedException();
		}

		public override bool removeState(uint id)
		{
			throw new NotImplementedException();
		}

		public override bool removeUser(uint id)
		{
			User user;

			try
			{
				user = db.Users.Single(o => o.Id == id);
			}
			catch (Exception e)
			{
				return false;
			}

			db.Users.DeleteOnSubmit(user);
			db.SubmitChanges();

			return true;
		}

		public override bool setCatalog(ICatalog catalog)
		{
			throw new NotImplementedException();
		}

		public override bool setEvent(IEvent _event)
		{
			throw new NotImplementedException();
		}

		public override bool setState(IState state)
		{
			throw new NotImplementedException();
		}

		public override bool setUser(IUser user)
		{
			throw new NotImplementedException();
		}
	}
}
