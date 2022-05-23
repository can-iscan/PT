using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.DataLayer
{
	public interface IUser
	{
		uint Id { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
	}
}
