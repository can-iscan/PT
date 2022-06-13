using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
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

		[TestMethod]
		public void TestBookViewModel()
		{
			ModelAPI model = new ModelForTesting();

			BookViewModel bookVM1= new BookViewModel(model.CreateCatalog("1984", "George Orwell", 300));
			BookViewModel bookVM2 = new BookViewModel(model.CreateCatalog("Brave New World", "Huxley", 330));

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
			ModelAPI model = ModelAPI.CreateModel();

			UserViewModel userVM1 = new UserViewModel(model.CreateUser(0, "Can", "Iscan"));
			UserViewModel userVM2 = new UserViewModel(model.CreateUser(1, "Murat", "Boz"));

			Assert.AreEqual(userVM1.Id, "0");
			Assert.AreEqual(userVM1.FirstName, "Can");
			Assert.AreEqual(userVM1.LastName, "Iscan");

			Assert.AreEqual(userVM2.Id, "1");
			Assert.AreEqual(userVM2.FirstName, "Murat");
			Assert.AreEqual(userVM2.LastName, "Boz");
		}

	}
}
