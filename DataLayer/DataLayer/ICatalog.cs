using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.DataLayer
{
	public interface ICatalog
	{
		string Title { get; set; }
		string Author { get; set; }
		ushort NumberOfPages { get; set; }
	}
}
