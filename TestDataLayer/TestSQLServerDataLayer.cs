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
	public class TestSQLServerDataLayer
	{

		[TestMethod]
		public void TestDataLayerAPI()
		{
			DataLayerAPI dataLayer = DataLayerAPI.CreateDataLayerWithSQLServer();

		}
		
	}

}
