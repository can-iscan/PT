using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
	public class Service
	{
		public DataServiceAPI DataService;

		public Service()
		{
			this.DataService = DataServiceAPI.CreateDataService();
		}
	} 
}
