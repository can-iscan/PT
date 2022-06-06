using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
	public class ViewBooksViewModel : ViewModelBase
	{
		private readonly ObservableCollection<BookViewModel> _books;

		public IEnumerable<BookViewModel> Books => _books;

		public ICommand AddBookCommand { get; }

		public ViewBooksViewModel() {
			this._books = new ObservableCollection<BookViewModel>();

			Service service = new Service();

			List<Catalog> catalogs = new List<Catalog>();

			catalogs = Catalog.getCatalogListFromService(service.DataService.getAllCatalogs());

			foreach (Catalog catalog in catalogs)
			{
				_books.Add(new BookViewModel(catalog));
			}
		}
	}
}
