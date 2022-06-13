using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel
{
	[TestClass]
	public class ModelTest
	{
		ModelAPI model1;
		ModelAPI model2;

		[TestInitialize]
		public void InitializeTest()
		{
			model1 = ModelAPI.CreateModel(new ServiceLayerForTesting());
			model2 = ModelAPI.CreateModel(new ServiceLayerForTesting());
		}

		[TestMethod]
		public void TestAddData()
		{
			Assert.IsTrue(model1.AddCatalog(model1.CreateCatalog("1984", "George Orwell", 300)));
			Assert.IsTrue(model1.AddUser(model1.CreateUser(0, "Can", "Iscan")));

			Assert.IsTrue(model2.AddUser(model2.CreateUser(1, "Murat", "Boz")));
			Assert.IsTrue(model2.AddCatalog(model2.CreateCatalog("Brave New World", "Huxley", 330)));
		}

		[TestMethod]
		public void TestRemoveData()
		{
			Assert.IsTrue(model1.RemoveCatalog("1984"));
			Assert.IsTrue(model1.RemoveUser(0));

			Assert.IsTrue(model2.RemoveUser(1));
			Assert.IsTrue(model2.RemoveCatalog("Brave New World"));
		}

		[TestMethod]
		public void TestBorrowReturn()
		{
			Assert.IsTrue(model1.BorrowCatalog("1984", 0));
			Assert.IsTrue(model1.BorrowCatalog("Brave New World", 1));

			Assert.IsTrue(model2.ReturnCatalog("1984", 0));
			Assert.IsTrue(model2.ReturnCatalog("Brave New World", 1));
		}

		[TestMethod]
		public void TestGet()
		{
			Assert.AreEqual(model1.GetCatalog("test").Title, "testCatalog");
			Assert.AreEqual(model1.GetUser(1).FirstName, "testUser");

			Assert.AreEqual(model2.GetCatalog("test").Title, "testCatalog");
			Assert.AreEqual(model2.GetUser(1).FirstName, "testUser");
		}

		[TestMethod]
		public void TestGetAll()
		{
			Assert.IsInstanceOfType(model1.GetAllCatalogs(), typeof(List<ICatalog>));
			Assert.IsInstanceOfType(model1.GetAllUsers(), typeof(List<IUser>));
			Assert.IsInstanceOfType(model1.GetAllStates(), typeof(List<IState>));
			Assert.IsInstanceOfType(model1.GetAllEvents(), typeof(List<IEvent>));
		}
	}
}
