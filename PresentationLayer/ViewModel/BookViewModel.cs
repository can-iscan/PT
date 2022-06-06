using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel
{
	public class BookViewModel : ViewModelBase
	{
		private readonly Catalog _book;

		public string Title => _book.Title;
		public string Author => _book.Author;
		public string NumberOfPages => _book.NumberOfPages.ToString();

		public BookViewModel(Catalog catalog)
		{
			this._book = catalog;
		}
	}
}
