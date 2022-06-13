using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceLayer
{
	[TestClass]
	public class ServiceLayerTest
	{
		[TestMethod]
		public void TestAddRmoveGet()
		{
			DataServiceAPI serviceLayer = DataServiceAPI.CreateDataService(new DataLayerForTesting());

			Assert.AreEqual(serviceLayer.addCatalog(new Catalog()), "test");
			Assert.AreEqual(serviceLayer.removeCatalog("1984"), true);
			Assert.AreEqual(serviceLayer.getCatalog("1984").GetType(), new Catalog().GetType());

			Assert.AreEqual(serviceLayer.addUser(new User()), 0);
			Assert.AreEqual(serviceLayer.removeUser(0), true);
			Assert.AreEqual(serviceLayer.getUser(0).GetType(), new User().GetType());
		}

		[TestMethod]
		public void TestBorrow()
		{
			DataServiceAPI serviceLayer = DataServiceAPI.CreateDataService(new DataLayerForTesting());

			Assert.AreEqual(serviceLayer.borrowCatalog("1984", 4), true);
		}

		[TestMethod]
		public void TestReturn()
		{
			DataServiceAPI serviceLayer = DataServiceAPI.CreateDataService(new DataLayerForTesting());

			Assert.AreEqual(serviceLayer.returnCatalog("1984", 3), true);
		}

		[TestMethod]
		public void TestCountAvailable()
		{
			DataServiceAPI serviceLayer = DataServiceAPI.CreateDataService(new DataLayerForTesting());

			Assert.AreEqual(serviceLayer.countAvailableCatalog("1984"), 1);
		}
	}
}
