using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.DataLayer
{
	public interface IState
	{
		uint Id { get; set; }
		ICatalog CatalogEntry { get; set; }
		bool Available { get; set; }
	}
}
