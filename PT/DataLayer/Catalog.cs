using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class Catalog
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

	public class CatalogDictionary : Dictionary<string, Catalog> {}
}
