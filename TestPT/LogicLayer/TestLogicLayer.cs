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
		private DataLayerAPI dataLayer1;
		private DataLayerAPI dataLayer2;

		public TestLogicLayer()
		{ 
			dataLayer1 = DataLayerAPI.CreateDataLayerWithCollections();
			dataLayer2 = DataLayerAPI.CreateDataLayer();

			dataLayer1.addUser(dataLayer1.createUser("Stephen", "Bennet"));
			dataLayer1.addUser(dataLayer1.createUser("Ambre", "Garcia"));
			dataLayer1.addUser(dataLayer1.createUser("Anton", "Saarela"));
			dataLayer1.addUser(dataLayer1.createUser("Thibault", "Lefevre"));
			dataLayer1.addUser(dataLayer1.createUser("Kaylee", "Jenkins"));
			dataLayer1.addUser(dataLayer1.createUser("Donna", "Garcia"));


			dataLayer1.addCatalog("Trafik", dataLayer1.createCatalog("Trafik", "Rikki Ducornet", 88));
			dataLayer1.addCatalog("Finna", dataLayer1.createCatalog("Finna", "Nino Cipri", 92));
			dataLayer1.addCatalog("All Systems Red", dataLayer1.createCatalog("All Systems Red", "Martha Wells", 144));
			dataLayer1.addCatalog("Riot Baby", dataLayer1.createCatalog("Riot Baby", "Tochi Onyebuchi", 167));
			
			IUser user1 = dataLayer1.addUser(dataLayer1.createUser("Lucy", "Wheeler"));
			ICatalog catalog1 = dataLayer1.addCatalog("The Siler Patient", dataLayer1.createCatalog("The Siler Patient", "Alex Michaelides", 304));
			IState state1 = dataLayer1.addState(dataLayer1.createState(catalog1, false));
			dataLayer1.addEvent(dataLayer1.createEvent(state1, user1));


			dataLayer2.addUser(dataLayer2.createUser("Kean", "Mars"));
			dataLayer2.addUser(dataLayer2.createUser("Jonathan", "Ulrich"));
			dataLayer2.addUser(dataLayer2.createUser("Lars", "Hetfield"));
			dataLayer2.addUser(dataLayer2.createUser("Christian", "Jackson"));
			dataLayer2.addUser(dataLayer2.createUser("Brad", "Davis"));
					 
			dataLayer2.addCatalog("The Robber Bride", dataLayer2.createCatalog("The Robber Bride", "Margaret Atwood", 528));
			dataLayer2.addCatalog("The List", dataLayer2.createCatalog("The List", "Siobhan Vivian", 288));
			dataLayer2.addCatalog("Little, Big", dataLayer2.createCatalog("Little, Big", "John Crowley", 538));
			dataLayer2.addCatalog("Possession", dataLayer2.createCatalog("Possession", "A. S. Byatt", 555));


			IUser user2 = dataLayer2.addUser(dataLayer2.createUser("Andrew", "Carlson"));
			ICatalog catalog2 = dataLayer2.addCatalog("Follow Me to Ground", dataLayer2.createCatalog("Follow Me to Ground", "Sue Rainsford", 245));
			IState state2 = dataLayer2.addState(dataLayer2.createState(catalog2, false));
			dataLayer1.addEvent(dataLayer2.createEvent(state2, user2));
		}

		[TestMethod]
		public void TestCreateFunctionality()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer2);

			IUser user = logicLayer.createUser("Muslum", "Gurses");

			Assert.AreEqual(user.FirstName, "Muslum");
			Assert.AreEqual(user.LastName, "Gurses");

			ICatalog catalog = logicLayer.createCatalog("1984", "George Orwell", 310);

			Assert.AreEqual(catalog.Title, "1984");
			Assert.AreEqual(catalog.Author, "George Orwell");
			Assert.AreEqual(catalog.NumberOfPages, 310);

			IState state = logicLayer.createState(catalog, false);

			Assert.AreEqual(state.CatalogEntry, catalog);
			Assert.AreEqual(state.Available, false);

			IEvent _event = logicLayer.createEvent(state, user);

			Assert.AreEqual(_event.StateEntry, state);
			Assert.AreEqual(_event.UserEntry, user);
		}

		[TestMethod]
		public void TestDataLayerInjection()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer);

			Assert.IsNotNull(logicLayer);
		}

		[TestMethod]
		public void TestAddRemoveCatalog()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer1);

			ICatalog newCatalog = logicLayer.createCatalog("1984", "George Orwell", 310);

			newCatalog = logicLayer.addCatalog(newCatalog);

			foreach (ICatalog catalog in logicLayer.getCatalogs())
			{
				if (catalog.Title == newCatalog.Title)
				{
					Assert.AreEqual(catalog.Author, "George Orwell");
				}
			}

			logicLayer.removeCatalog(newCatalog);

			foreach (ICatalog catalog in logicLayer.getCatalogs())
			{
				if (catalog.Title == "1984")
				{
					Assert.Fail();
				}
			}

		}

		[TestMethod]
		public void TestAddRemoveUser()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer2);

			IUser newUser = logicLayer.createUser("Can", "Iscan");

			newUser = logicLayer.addUser(newUser);

			foreach (IUser user in logicLayer.getUsers())
			{
				if (user.Id == newUser.Id)
				{
					Assert.AreEqual(user.FirstName, "Can");
					Assert.AreEqual(user.LastName, "Iscan");
				}
			}

			logicLayer.removeUser(newUser);

			foreach (IUser user in logicLayer.getUsers())
			{
				if (user.Id == newUser.Id)
				{
					Assert.Fail();
				}
			}

		}

		[TestMethod]
		public void TestBorrowCatalogStateEventCreation()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer2);

			ICatalog catalog = logicLayer.createCatalog("1984", "George Orwell", 310);
			IUser user = logicLayer.createUser("Eren", "Tekin");

			catalog = logicLayer.addCatalog(catalog);
			user = logicLayer.addUser(user);
			logicLayer.borrowCatalog(catalog, user);

			bool created = false;
			foreach (IEvent _event in logicLayer.getEvents())
			{
				if (_event.StateEntry.CatalogEntry == catalog && _event.UserEntry == user && !_event.StateEntry.Available)
					created = true;
			}

			Assert.IsTrue(created);
		}

		[TestMethod]
		public void TestReturnCatalogStateEventCreation()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer1);

			ICatalog catalog = logicLayer.createCatalog("1984", "George Orwell", 310);
			IUser user = logicLayer.createUser("Can", "Iscan");

			catalog = logicLayer.addCatalog(catalog);
			user = logicLayer.addUser(user);

			logicLayer.returnCatalog(catalog, user);

			bool created = false;
			foreach (IEvent _event in logicLayer.getEvents())
			{
				if (_event.StateEntry.CatalogEntry == catalog && _event.UserEntry == user && _event.StateEntry.Available)
					created = true;
			}

			Assert.IsTrue(created);
		}


		[TestMethod]
		public void TestGetUserCatalog()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer2);

			ICatalog catalog = logicLayer.createCatalog("Brave New World", "Aldous Huxley", 288);
			IUser user = logicLayer.createUser("Ozgen", "Acikelli");

			catalog = logicLayer.addCatalog(catalog);
			user = logicLayer.addUser(user);

			Assert.AreEqual(catalog, logicLayer.getCatalog(catalog.Title));
			Assert.AreEqual(user, logicLayer.getUser(user.Id));
		}

		[TestMethod]
		public void TestMultipleFunctionalityOnDataLayer1()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer1);

			List<IUser> users = logicLayer.getUsers();
			List<ICatalog> catalogs = logicLayer.getCatalogs();

			ICatalog catalog1 = catalogs[1];
			ICatalog catalog2 = catalogs[2];
			ICatalog catalog3 = catalogs[3];

			IUser user2 = users[2];
			IUser user3 = users[3];
			IUser user4 = users[4];

			logicLayer.borrowCatalog(catalog2, user4);
			logicLayer.borrowCatalog(catalog1, user2);
			logicLayer.returnCatalog(catalog2, user4);
			logicLayer.borrowCatalog(catalog3, user3);

			foreach (IEvent _event in logicLayer.getEvents())
			{
				if (_event.StateEntry.Available == true && _event.StateEntry.CatalogEntry == catalog2)
				{
					Assert.AreEqual(_event.UserEntry, user4);
				}
				else if (_event.StateEntry.CatalogEntry == catalog3)
				{
					Assert.IsFalse(_event.StateEntry.Available);
				}
			}

			Assert.AreEqual(0 , logicLayer.countAvailableCatalog(catalog3));
			Assert.AreEqual(1 , logicLayer.countAvailableCatalog(catalog2));

			foreach (IUser user in logicLayer.getUsers()) {
				if (user.FirstName == "Lars" && user.LastName == "Hetfield")
				{
					logicLayer.removeUser(user);
				}
			}

			foreach (IUser user in logicLayer.getUsers())
			{
				if (user.FirstName == "Lars" && user.LastName == "Hetfield")
				{
					Assert.Fail();
				}
			}
		}


		[TestMethod]
		public void TestMultipleFunctionalityOnDataLayer2()
		{
			LogicLayerAPI logicLayer = LogicLayerAPI.CreateLayer(dataLayer2);

			List<IUser> users = logicLayer.getUsers();

			ICatalog catalog1 = logicLayer.getCatalog("The List");
			Assert.AreEqual(catalog1.NumberOfPages, 288);

			IUser user = logicLayer.addUser(logicLayer.createUser("Can", "Iscan"));
			Assert.AreEqual(logicLayer.getUser(user.Id).LastName, "Iscan");


			ICatalog catalogX = logicLayer.createCatalog("X", "Anonymous", 111);
			logicLayer.addCatalog(catalogX);


			Assert.AreEqual(logicLayer.countAvailableCatalog(catalogX), 1);

			logicLayer.borrowCatalog(catalogX, users[2]);

			Assert.AreEqual(logicLayer.countAvailableCatalog(catalogX), 0);

			Assert.IsFalse(logicLayer.borrowCatalog(catalogX, users[3]));

			logicLayer.returnCatalog(catalogX, users[2]);

			Assert.AreEqual(logicLayer.countAvailableCatalog(catalogX), 1);
		}
	}
}
