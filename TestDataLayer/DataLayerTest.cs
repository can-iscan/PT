using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestDataLayer
{
	[TestClass]
	public class DataLayerTest
	{
		[TestMethod]
		public void TestUser()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithSQLServer();
			dataLayer.Connect();

			User user = new User();

			user.FirstName = "TestUser";
			user.LastName = "Testing";

			// Create - Read
			long id = dataLayer.addUser(user);
			Assert.AreEqual(dataLayer.getUser(id), user);

			// Update
			user.FirstName = "Edited";
			Assert.IsTrue(dataLayer.setUser(user));
			Assert.AreEqual(dataLayer.getUser(id).FirstName, "Edited");

			// Delete
			Assert.IsTrue(dataLayer.removeUser(id));
			Assert.IsNull(dataLayer.getUser(id));
		}

		[TestMethod]
		public void TestCatalog()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithSQLServer();
			dataLayer.Connect();

			Catalog catalog = new Catalog();

			catalog.Title = "TestCatalog";
			catalog.Author = "Testing";

			// Create - Read
			string title = dataLayer.addCatalog(catalog);
			Assert.AreEqual(dataLayer.getCatalog(title), catalog);

			// Update
			catalog.Author = "Edited";
			Assert.IsTrue(dataLayer.setCatalog(title, catalog));
			Assert.AreEqual(dataLayer.getCatalog(title).Author, "Edited");

			// Delete
			Assert.IsTrue(dataLayer.removeCatalog(title));
			Assert.IsNull(dataLayer.getCatalog(title));
		}

		[TestMethod]
		public void TestStateEvent()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithSQLServer();
			dataLayer.Connect();

			// Preparing Data
			Catalog catalog = new Catalog();
			catalog.Title = "Test" + new Random().Next(0, 9999);
			catalog.NumberOfPages = 123;
			catalog.Author = "Tester";
			string catalogTitle = dataLayer.addCatalog(catalog);

			User user = new User();
			user.FirstName = "Test123";
			user.LastName = "Testing";
			long userId = dataLayer.addUser(user);

			User user2 = new User();
			user2.FirstName = "Test321";
			user2.LastName = "Testing";
			long userId2 = dataLayer.addUser(user2);

			State state = new State();

			state.Available = true;
			state.CatalogEntry = catalogTitle;

			// Create - Read State
			long stateId = dataLayer.addState(state);
			Assert.AreEqual(dataLayer.getState(stateId), state);

			// Update State
			state.Available = false;
			Assert.IsTrue(dataLayer.setState(state));
			Assert.AreEqual(dataLayer.getState(stateId).Available, false);

			Event _event = new Event();

			_event.StateEntry = stateId;
			_event.UserEntry = userId;
			_event.Time = DateTime.Now;

			// Create - Read State
			long _eventId = dataLayer.addEvent(_event);
			Assert.AreEqual(dataLayer.getEvent(_eventId), _event);

			// Update Event
			_event.UserEntry = user2.Id;
			Assert.IsTrue(dataLayer.setEvent(_event));
			Assert.AreEqual(dataLayer.getEvent(_eventId).UserEntry, user2.Id);

			Assert.IsFalse(dataLayer.removeState(stateId)); // Foreign Key exception

			// Delete Event
			Assert.IsTrue(dataLayer.removeEvent(_eventId));
			Assert.IsNull(dataLayer.getEvent(_eventId));

			// Delete State
			Assert.IsTrue(dataLayer.removeState(stateId));
			Assert.IsNull(dataLayer.getState(stateId));

			dataLayer.removeCatalog(catalogTitle);
			dataLayer.removeUser(userId);
			dataLayer.removeUser(userId2);
		}
	}
}
