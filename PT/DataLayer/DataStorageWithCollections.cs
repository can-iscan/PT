using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT.DataLayer
{
	internal class DataStorageWithCollections : DataLayerAPI
	{
		private DataContext DataContextEntry;
		private uint IdCounterUser = 0;
		private uint IdCounterState = 0;
		private uint IdCounterEvent = 0;

		public DataStorageWithCollections()
		{
			this.DataContextEntry = new DataContext();
		}

		public override bool Connect()
		{
			// Nothing to initilize or no need connect to a database
			return true;
		}

		public override Catalog addCatalog(string title, Catalog catalog)
		{
			this.DataContextEntry.Catalogs.Add(title, catalog);
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

		public override Catalog getCatalog(string title)
		{
			return this.DataContextEntry.Catalogs[title];
		}

		public override bool setCatalog(Catalog catalog)
		{
			this.DataContextEntry.Catalogs[catalog.Title] = catalog;
			return true;
		}

		public override List<Catalog> getAllCatalogs()
		{
			return this.DataContextEntry.Catalogs.Values.ToList<Catalog>();
		}

		public override User addUser(User user)
		{
			user.Id = this.IdCounterUser;
			this.DataContextEntry.Users.Add(this.IdCounterUser, user);
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

		public override User getUser(uint id)
		{
			return this.DataContextEntry.Users[id];
		}

		public override bool setUser(User user)
		{
			this.DataContextEntry.Users[user.Id] = user;
			return true;
		}

		public override List<User> getAllUsers()
		{
			return this.DataContextEntry.Users.Values.ToList<User>();
		}

		public override State addState(State state)
		{
			state.Id = this.IdCounterState;
			this.DataContextEntry.States.Add(this.IdCounterState, state);
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

		public override State getState(uint id)
		{
			return this.DataContextEntry.States[id];
		}

		public override bool setState(State state)
		{
			this.DataContextEntry.States[state.Id] = state;
			return true;
		}

		public override List<State> getAllStates()
		{
			return this.DataContextEntry.States.Values.ToList<State>();
		}

		public override Event addEvent(Event _event)
		{
			_event.Id = this.IdCounterEvent;
			this.DataContextEntry.Events.Add(this.IdCounterEvent, _event);
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

		public override Event getEvent(uint id)
		{
			return this.DataContextEntry.Events[id];
		}

		public override bool setEvent(Event _event)
		{
			this.DataContextEntry.Events[_event.Id] = _event;
			return true;
		}

		public override List<Event> getAllEvents()
		{
			return this.DataContextEntry.Events.Values.ToList<Event>();
		}
	}
}
