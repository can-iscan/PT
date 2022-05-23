using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer.Dictionary
{
	internal class Catalog : ICatalog
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public ushort NumberOfPages { get; set; }


		public Catalog(string title, string author, ushort numberOfPages)
		{
			this.Title = title;
			this.Author = author;
			this.NumberOfPages = numberOfPages;
		}
	}

	internal class CatalogDictionary : Dictionary<string, Catalog> {}

}
