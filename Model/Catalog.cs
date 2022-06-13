using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	internal class Catalog : ICatalog
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public int NumberOfPages { get; set; }


		public Catalog(string title, string author, int numberOfPages)
		{
			this.Title = title;
			this.Author = author;
			this.NumberOfPages = numberOfPages;
		}
	}
}
