using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PT.DataLayer.Dictionary;

namespace PT.DataLayer
{
	internal class DataStorageWithCollections : DataLayerAPI
	{
		private DictionaryDataContext DataContextEntry;
		private uint IdCounterUser = 0;
		private uint IdCounterState = 0;
		private uint IdCounterEvent = 0;

		public DataStorageWithCollections()
		{
			this.DataContextEntry = new DictionaryDataContext();
		}

		public override bool Connect()
		{
			// Nothing to initilize or no need connect to a database
			return true;
		}

		public override ICatalog addCatalog(string title, ICatalog catalog)
		{
			this.DataContextEntry.Catalogs.Add(title, (Catalog)catalog);
			return catalog;
		}

		public override bool removeCatalog(string title)
		{
			if (this.DataContextEntry.Catalogs.ContainsKey(title))
			{
				this.DataContextEntry.Catalogs.Remove(title);
				return true;
			}
			else
			{
				return false;
			}
		}

		public override ICatalog getCatalog(string title)
		{
			return this.DataContextEntry.Catalogs[title];
		}

		public override bool setCatalog(ICatalog catalog)
		{
			this.DataContextEntry.Catalogs[catalog.Title] = (Catalog)catalog;
			return true;
		}

		public override List<ICatalog> getAllCatalogs()
		{
			return this.DataContextEntry.Catalogs.Values.ToList<ICatalog>();
		}

		public override IUser addUser(IUser user)
		{
			user.Id = this.IdCounterUser;
			this.DataContextEntry.Users.Add(this.IdCounterUser, (User)user);
			this.IdCounterUser++;
			return user;
		}

		public override bool removeUser(uint id)
		{
			if (this.DataContextEntry.Users.ContainsKey(id))
			{
				this.DataContextEntry.Users.Remove(id);
				return true;
			}
			else
			{
				return false;
			}
		}

		public override IUser getUser(uint id)
		{
			return this.DataContextEntry.Users[id];
		}

		public override bool setUser(IUser user)
		{
			this.DataContextEntry.Users[user.Id] = (User)user;
			return true;
		}

		public override List<IUser> getAllUsers()
		{
			return this.DataContextEntry.Users.Values.ToList<IUser>();
		}

		public override IState addState(IState state)
		{
			state.Id = this.IdCounterState;
			this.DataContextEntry.States.Add(this.IdCounterState, (State)state);
			this.IdCounterState++;
			return state;
		}

		public override bool removeState(uint id)
		{
			if (this.DataContextEntry.States.ContainsKey(id))
			{
				this.DataContextEntry.States.Remove(id);
				return true;
			}
			else
			{
				return false;
			}
		}

		public override IState getState(uint id)
		{
			return this.DataContextEntry.States[id];
		}

		public override bool setState(IState state)
		{
			this.DataContextEntry.States[state.Id] = (State)state;
			return true;
		}

		public override List<IState> getAllStates()
		{
			return this.DataContextEntry.States.Values.ToList<IState>();
		}

		public override IEvent addEvent(IEvent _event)
		{
			_event.Id = this.IdCounterEvent;
			this.DataContextEntry.Events.Add(this.IdCounterEvent, (Event)_event);
			this.IdCounterEvent++;
			return _event;
		}

		public override bool removeEvent(uint id)
		{
			if (this.DataContextEntry.Events.ContainsKey(id))
			{
				this.DataContextEntry.Events.Remove(id);
				return true;
			}
			else
			{
				return false;
			}
		}

		public override IEvent getEvent(uint id)
		{
			return this.DataContextEntry.Events[id];
		}

		public override bool setEvent(IEvent _event)
		{
			this.DataContextEntry.Events[_event.Id] = (Event)_event;
			return true;
		}

		public override List<IEvent> getAllEvents()
		{
			return this.DataContextEntry.Events.Values.ToList<IEvent>();
		}

		public override IEvent createEvent(IState state, IUser user)
		{
			return new Event((State)state, (User)user);
		}

		public override IState createState(ICatalog catalog, bool available)
		{
			return new State((Catalog)catalog, available);
		}

		public override IUser createUser(string fname, string lname)
		{
			return new User(fname, lname);
		}

		public override ICatalog createCatalog(string title, string author, ushort numberOfPages)
		{
			return new Catalog(title, author, numberOfPages);
		}
	}

}
