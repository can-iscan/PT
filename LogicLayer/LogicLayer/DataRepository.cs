using System;
using System.Collections.Generic;
using System.Text;
using PT.DataLayer;

namespace PT.LogicLayer
{
	internal class DataRepository
	{
		public DataLayerAPI DataLayer;

		public DataRepository(DataLayerAPI dataLayer)
		{
			DataLayer = dataLayer;
			dataLayer.Connect();
		}
	}
}
