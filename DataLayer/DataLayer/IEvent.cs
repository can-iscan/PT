using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.DataLayer
{
	public interface IEvent
	{
		uint Id { get; set; }
		IState StateEntry { get; set; }
		IUser UserEntry { get; set; }
		DateTime Time { get; set; }
	}
}
