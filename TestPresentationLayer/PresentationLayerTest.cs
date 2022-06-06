using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Model;
using PresentationLayer.ViewModel;
using PresentationLayer.ViewModel.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPresentationLayer
{
	[TestClass]
	public class PresentationLayerTest
	{
		Service service1;
		Service service2;
		NavigationStore navStore;

		[TestInitialize]
		public void InitializeTest()
		{
			service1 = new Service(new ServiceLayerForTesting());
			service2 = new Service(new ServiceLayerForTesting());
			navStore = new NavigationStore();
		}

		[TestMethod]
		public void TestAddData()
		{
			Assert.IsTrue(service1.AddCatalog(new Catalog("1984", "George Orwell", 300)));
			Assert.IsTrue(service1.AddUser(new User(0, "Can", "Iscan")));

			Assert.IsTrue(service2.AddUser(new User(1, "Murat", "Boz")));
			Assert.IsTrue(service2.AddCatalog(new Catalog("Brave New World", "Huxley", 330)));
		}

		[TestMethod]
		public void TestBorrowReturn()
		{
			Assert.IsTrue(service1.BorrowCatalog("1984", 0));
			Assert.IsTrue(service1.BorrowCatalog("Brave New World", 1));
			Assert.IsTrue(service1.ReturnCatalog("1984", 0));
			Assert.IsTrue(service1.ReturnCatalog("Brave New World", 1));
		}

		[TestMethod]
		public void TestBookViewModel()
		{
			BookViewModel bookVM1= new BookViewModel(new Catalog("1984", "George Orwell", 300));
			BookViewModel bookVM2 = new BookViewModel(new Catalog("Brave New World", "Huxley", 330));

			Assert.AreEqual(bookVM1.Author, "George Orwell");
			Assert.AreEqual(bookVM1.Title, "1984");
			Assert.AreEqual(bookVM1.NumberOfPages, "300");

			Assert.AreEqual(bookVM2.Author, "Huxley");
			Assert.AreEqual(bookVM2.Title, "Brave New World");
			Assert.AreEqual(bookVM2.NumberOfPages, "330");
		}

		[TestMethod]
		public void TestUserViewModel()
		{
			UserViewModel userVM1 = new UserViewModel(new User(0, "Can", "Iscan"));
			UserViewModel userVM2 = new UserViewModel(new User(1, "Murat", "Boz"));

			Assert.AreEqual(userVM1.Id, "0");
			Assert.AreEqual(userVM1.FirstName, "Can");
			Assert.AreEqual(userVM1.LastName, "Iscan");

			Assert.AreEqual(userVM2.Id, "1");
			Assert.AreEqual(userVM2.FirstName, "Murat");
			Assert.AreEqual(userVM2.LastName, "Boz");
		}

	}
}
