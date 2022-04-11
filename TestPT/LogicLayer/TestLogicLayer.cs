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


			Catalog newCatalog = new Catalog("1984", "George Orwell", 310);

			logicLayer.addCatalog(newCatalog);

			bool created = false;
			foreach (Catalog catalog in logicLayer.getCatalogs())
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

			User newUser = new User("Can", "Iscan");

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

			Catalog catalog = new Catalog("1984", "George Orwell", 310);
			User user = new User("Can", "Iscan");

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

			Catalog catalog = new Catalog("1984", "George Orwell", 310);
			User user = new User("Can", "Iscan");

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

			Catalog catalog = new Catalog("Brave New World", "Aldous Huxley", 288);
			User user = new User("Ozgen", "Acikelli");

			catalog = logicLayer.addCatalog(catalog);
			user = logicLayer.addUser(user);

			Assert.AreEqual(catalog, logicLayer.getCatalog(catalog.Title));
			Assert.AreEqual(user, logicLayer.getUser(user.Id));
		}
	}
}
