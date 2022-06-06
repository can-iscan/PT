using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{

	public class Event
	{
		public long Id;
		public long StateEntry;
		public long UserEntry;

		public Event() { }

		public Event(long id, long state, long user)
		{
			this.Id = id;
			this.StateEntry = state;
			this.UserEntry = user;
		}

		internal Event(ServiceLayer.Event _event)
		{
			this.Id = _event.Id;
			this.StateEntry = _event.StateEntry;
			this.UserEntry = _event.UserEntry;
		}

		internal ServiceLayer.Event getDataLayerEvent()
		{
			ServiceLayer.Event _event = new ServiceLayer.Event();
			_event.Id = this.Id;
			_event.StateEntry = this.StateEntry;
			_event.UserEntry = this.UserEntry;
			return _event;
		}
	}
}
