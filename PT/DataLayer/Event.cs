using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class Event
	{
		public uint Id;
		public State StateEntry;
		public User UserEntry;

		public Event(State stateEntry, User userEntry)
		{
			this.StateEntry = stateEntry;
			this.UserEntry = userEntry;
		}
	}

	public class EventDictionary : Dictionary<uint, Event>
	{

	}
}

