using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class Event
	{
		public uint Id = 0;
		public State StateEntry;
		public User UserEntry;
		public DateTime Time;

		public Event(State stateEntry, User userEntry, DateTime time)
		{
			this.StateEntry = stateEntry;
			this.UserEntry = userEntry;
			this.Time = time;
		}

		public Event(State stateEntry, User userEntry)
		{
			this.StateEntry = stateEntry;
			this.UserEntry = userEntry;
			this.Time = DateTime.UtcNow;
		}
	}

	public class EventDictionary : Dictionary<uint, Event> {}
}

