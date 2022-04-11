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
		}
	}

}
