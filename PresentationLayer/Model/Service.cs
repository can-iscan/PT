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

		public bool BorrowCatalog(string title, long userId)
		{
			return DataService.borrowCatalog(title, userId);
		}

		public bool ReturnCatalog(string title, long userId)
		{
			return DataService.returnCatalog(title, userId);
		}

		public bool AddCatalog(Catalog catalog)
		{
			DataService.addCatalog(catalog.getServiceLayerCatalog());
			return true;
		}

		public bool AddUser(User user)
		{
			DataService.addUser(user.getServiceLayerUser());
			return true;
		}

		public Service()
		{
			this.DataService = DataServiceAPI.CreateDataService();
		}

		public Service(DataServiceAPI api)
		{
			this.DataService = api;
		}
	} 
}
