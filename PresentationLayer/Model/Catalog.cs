using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
	public class Catalog
	{
		public string Title;
		public string Author;
		public int NumberOfPages;

		public Catalog() { }

		public Catalog(string title, string author, int numofpages)
		{
			this.Title = title;
			this.Author = author;
			this.NumberOfPages = numofpages;
		}

		internal Catalog(ServiceLayer.Catalog catalog)
		{
			this.Title = catalog.Title;
			this.Author = catalog.Author;
			this.NumberOfPages = catalog.NumberOfPages;
		}

		internal ServiceLayer.Catalog getServiceLayerCatalog()
		{
			ServiceLayer.Catalog catalog = new ServiceLayer.Catalog();
			catalog.Title = this.Title;
			catalog.Author = this.Author;
			catalog.NumberOfPages = this.NumberOfPages;
			return catalog;
		}

		internal static List<Catalog> getCatalogListFromService(List<ServiceLayer.Catalog> ser_catalogs)
		{
			List<Catalog> catalogs = new List<Catalog>();

			foreach (ServiceLayer.Catalog catalog in ser_catalogs)
			{
				catalogs.Add(new Catalog(catalog));
			}

			return catalogs;
		}
	}
}
