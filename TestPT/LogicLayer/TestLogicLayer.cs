using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PT.LogicLayer;
using PT.DataLayer;

namespace TestPT.LogicLayer
{
	[TestClass]
	public class TestLogicLayer
	{
		
		[TestMethod]
		public void TestDataLayerInjection()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);

			Assert.IsNotNull(logicLayer);
		}

		[TestMethod]
		public void TestAddCatalog()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);


			ICatalog newCatalog = new Catalog("1984", "George Orwell", 310);

			logicLayer.addCatalog(newCatalog);

			bool created = false;
			foreach (ICatalog catalog in logicLayer.getCatalogs())
			{
				if (catalog.Title == "1984")
					created = true;
			}

			Assert.IsTrue(created);
		}

		[TestMethod]
		public void TestAddUser()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);

			IUser newUser = new User("Can", "Iscan");

			newUser = logicLayer.addUser(newUser);

			bool created = false;
			foreach (User user in logicLayer.getUsers())
			{
				if (user.Id == newUser.Id)
					created = true;
			}

			Assert.IsTrue(created);
		}

		[TestMethod]
		public void TestBorrowCatalogStateEventCreation()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);

			ICatalog catalog = new Catalog("1984", "George Orwell", 310);
			IUser user = new User("Can", "Iscan");

			catalog = logicLayer.addCatalog(catalog);
			user = logicLayer.addUser(user);
			logicLayer.borrowCatalog(catalog, user);


			bool created = false;
			foreach (Event _event in logicLayer.getEvents())
			{
				if (_event.StateEntry.CatalogEntry == catalog && _event.UserEntry == user && !_event.StateEntry.Available)
					created = true;
			}

			Assert.IsTrue(created);
		}

		[TestMethod]
		public void TestReturnCatalogStateEventCreation()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);

			ICatalog catalog = new Catalog("1984", "George Orwell", 310);
			IUser user = new User("Can", "Iscan");

			catalog = logicLayer.addCatalog(catalog);
			user = logicLayer.addUser(user);

			logicLayer.returnCatalog(catalog, user);

			bool created = false;
			foreach (Event _event in logicLayer.getEvents())
			{
				if (_event.StateEntry.CatalogEntry == catalog && _event.UserEntry == user && _event.StateEntry.Available)
					created = true;
			}

			Assert.IsTrue(created);
		}


		[TestMethod]
		public void TestGetUserCatalog()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);

			ICatalog catalog = new Catalog("Brave New World", "Aldous Huxley", 288);
			IUser user = new User("Ozgen", "Acikelli");

			catalog = logicLayer.addCatalog(catalog);
			user = logicLayer.addUser(user);

			Assert.AreEqual(catalog, logicLayer.getCatalog(catalog.Title));
			Assert.AreEqual(user, logicLayer.getUser(user.Id));
		}

		[TestMethod]
		public void TestMultipleInstances()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);


			ICatalog catalog1 = logicLayer.addCatalog(new Catalog("1984", "George Orwell", 310));
			ICatalog catalog2 = logicLayer.addCatalog(new Catalog("Brave New World", "Aldous Huxley", 288));
			ICatalog catalog3 = logicLayer.addCatalog(new Catalog("Maus", "Art Spiegelman", 270));

			IUser user1 = logicLayer.addUser(new User("Ozgen", "Acikelli"));
			IUser user2 = logicLayer.addUser(new User("Can", "Iscan"));
			IUser user3 = logicLayer.addUser(new User("Mert", "Tekin"));

			logicLayer.borrowCatalog(catalog2, user3);
			logicLayer.borrowCatalog(catalog1, user2);
			logicLayer.returnCatalog(catalog2, user3);
			logicLayer.borrowCatalog(catalog3, user1);

			foreach (Event _event in logicLayer.getEvents())
			{
				if (_event.StateEntry.Available == true && _event.StateEntry.CatalogEntry == catalog2)
				{
					Assert.AreEqual(_event.UserEntry, user3);
				}
				else if (_event.StateEntry.CatalogEntry == catalog3)
				{
					Assert.IsFalse(_event.StateEntry.Available);
				}
			}

			Assert.AreEqual(0 , logicLayer.countAvailableCatalog(catalog3));
			Assert.AreEqual(1 , logicLayer.countAvailableCatalog(catalog2));
	}
	}
}
