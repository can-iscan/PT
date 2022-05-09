using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class Event : IEvent
	{
		public uint Id { get; set; }
		public IState StateEntry { get; set; }
		public IUser UserEntry { get; set; }
		public DateTime Time { get; set; }


		public Event(IState stateEntry, IUser userEntry, DateTime time)
		{
			this.Id = 0;
			this.StateEntry = stateEntry;
			this.UserEntry = userEntry;
			this.Time = time;
		}

		public Event(IState stateEntry, IUser userEntry)
		{
			this.Id = 0;
			this.StateEntry = stateEntry;
			this.UserEntry = userEntry;
			this.Time = DateTime.UtcNow;
		}
	}

	public class EventDictionary : Dictionary<uint, Event> {}

	public interface IEvent
	{
		public uint Id { get; set; }
		public IState StateEntry { get; set; }
		public IUser UserEntry { get; set; }
		public DateTime Time { get; set; }
	}
}

