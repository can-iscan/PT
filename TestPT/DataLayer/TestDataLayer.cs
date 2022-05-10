using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT;
using PT.DataLayer;

namespace TestPT
{
	[TestClass]
	public class TestDataLayerAPI
	{
		[TestMethod]
		public void TestCatalog()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();

			ICatalog catalog = dataLayer.createCatalog("1984", "George Orwell", 300);

			Assert.AreEqual(catalog.Title, "1984");
			Assert.AreEqual(catalog.Author, "George Orwell");
			Assert.AreEqual(catalog.NumberOfPages, 300);

			dataLayer.addCatalog(catalog.Title, catalog);

			Assert.AreEqual(catalog, dataLayer.getCatalog(catalog.Title));

			dataLayer.removeCatalog(catalog.Title);

			bool deleted = true;
			foreach (ICatalog catl in dataLayer.getAllCatalogs())
			{
				if (catl.Title == catalog.Title)
					deleted = false;
			}

			Assert.IsTrue(deleted);
		}

		[TestMethod]
		public void TestUser()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayer();

			IUser user = dataLayer.createUser("Can", "Iscan");

			Assert.AreEqual(user.FirstName, "Can");
			Assert.AreEqual(user.LastName, "Iscan");

			user = dataLayer.addUser(user);

			Assert.AreEqual(user, dataLayer.getUser(user.Id));

			foreach (IUser usr in dataLayer.getAllUsers())
			{
				if (usr.FirstName == "Can")
				{
					Assert.AreEqual(usr.LastName, "Iscan");
				}
			}

			dataLayer.removeUser(user.Id);

			foreach (IUser usr in dataLayer.getAllUsers())
			{
				if (usr.FirstName == "Can")
				{
					Assert.Fail();
				}
			}
		}

		[TestMethod]
		public void TestState()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();

			ICatalog catalog = dataLayer.createCatalog("1984", "George Orwell", 300);

			IState state = dataLayer.createState(catalog, true);

			Assert.AreEqual(state.CatalogEntry, catalog);
			Assert.AreEqual(state.Available, true);

			state = dataLayer.addState(state);

			Assert.AreEqual(state, dataLayer.getState(state.Id));

			dataLayer.removeState(state.Id);

			foreach (IState stt in dataLayer.getAllStates())
			{
				if (stt.Id == state.Id)
				{
					Assert.Fail();
				}
			}

		}

		[TestMethod]
		public void TestEvent()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayer();

			ICatalog catalog = dataLayer.createCatalog("1984", "George Orwell", 300);
			IState state = dataLayer.createState(catalog, true);
			IUser user = dataLayer.createUser("Can", "Iscan");
			IUser user2 = dataLayer.createUser("Eren", "Tekin");

			IEvent _event = dataLayer.createEvent(state, user);

			Assert.AreEqual(_event.StateEntry, state);
			Assert.AreEqual(_event.UserEntry, user);

			_event = dataLayer.addEvent(_event);

			Assert.AreEqual(_event, dataLayer.getEvent(_event.Id));

			_event.UserEntry = user2;
			dataLayer.setEvent(_event);

			Assert.AreEqual(user2, dataLayer.getEvent(_event.Id).UserEntry);

		}
	}

}
