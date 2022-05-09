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

			Catalog catalog = new Catalog("1984", "George Orwell", 300);
			dataLayer.addCatalog(catalog.Title, catalog);

			Assert.AreEqual(catalog, dataLayer.getCatalog(catalog.Title));

			dataLayer.removeCatalog(catalog.Title);

			bool deleted = true;
			foreach (Catalog catl in dataLayer.getAllCatalogs())
			{
				if (catl.Title == catalog.Title)
					deleted = false;
			}

			Assert.IsTrue(deleted);
		}

		[TestMethod]
		public void TestUser()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();

			User user = new User("Can", "Iscan");
			user = (User)dataLayer.addUser(user);

			Assert.AreEqual(user, dataLayer.getUser(user.Id));

			Assert.IsNotNull(dataLayer.getAllUsers());
		}

		[TestMethod]
		public void TestState()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();

			Catalog catalog = new Catalog("1984", "George Orwell", 300);

			State state = new State(catalog, true);
			state = (State)dataLayer.addState(state);

			Assert.AreEqual(state, dataLayer.getState(state.Id));

		}

		[TestMethod]
		public void TestEvent()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithCollections();

			Catalog catalog = new Catalog("1984", "George Orwell", 300);
			State state = new State(catalog, true);
			User user = new User("Can", "Iscan");
			User user2 = new User("Eren", "Tekin");

			Event _event = new Event(state, user);
			_event = (Event)dataLayer.addEvent(_event);

			Assert.AreEqual(_event, dataLayer.getEvent(_event.Id));

			_event.UserEntry = user2;
			dataLayer.setEvent(_event);

			Assert.AreEqual(user2, dataLayer.getEvent(_event.Id).UserEntry);

		}
	}

}
