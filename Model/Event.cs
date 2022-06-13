using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	internal class Event : IEvent
	{
		public long Id { get; set; }
		public long StateEntry { get; set; }
		public long UserEntry { get; set; }


		public Event(long stateEntry, long userEntry)
		{
			this.Id = 0;
			this.StateEntry = stateEntry;
			this.UserEntry = userEntry;
		}
	}
}
