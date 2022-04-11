using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public abstract class DataLayerAPI
	{
		public abstract bool Connect();
		
		public abstract bool addCatalog(string title, Catalog catalog);
		public abstract bool removeCatalog(string title);

		public abstract bool addUser(User user);
		public abstract bool removeUser(uint id);

		public abstract bool addState(State state);
		public abstract bool removeState(uint id);

		public abstract bool addEvent(Event _event);
		public abstract bool removeEvent(uint id);


		public static DataLayerAPI CreateDataLayerWithCollections()
		{
			return new DataStorageWithCollections();
		}
	}

	internal class DataStorageWithCollections : DataLayerAPI
	{
		private DataContext DataContextEntry;
		private uint IdCounterUser = 0;
		private uint IdCounterState = 0;
		private uint IdCounterEvent = 0;


		public DataStorageWithCollections() {
			this.DataContextEntry = new DataContext();
		}

		public override bool Connect()
		{
			// Nothing to initilize or no need connect to a database
			return true;
		}

		public override bool addCatalog(string title, Catalog catalog)
		{
			this.DataContextEntry.Catalogs.Add(title, catalog);
			return true;
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

		public override bool addUser(User user)
		{
			user.Id = this.IdCounterUser;
			this.DataContextEntry.Users.Add(this.IdCounterUser, user);
			this.IdCounterUser++;
			return true;
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

		public override bool addState(State state)
		{
			state.Id = this.IdCounterState;
			this.DataContextEntry.States.Add(this.IdCounterState, state);
			this.IdCounterState++;
			return true;
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

		public override bool addEvent(Event _event)
		{
			_event.Id = this.IdCounterEvent;
			this.DataContextEntry.Events.Add(this.IdCounterEvent, _event);
			this.IdCounterEvent++;
			return true;
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
	}
}
