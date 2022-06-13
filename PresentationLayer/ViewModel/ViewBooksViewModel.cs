using Model;
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

			ModelAPI model = ModelAPI.CreateModel();		

			foreach (ICatalog catalog in model.GetAllCatalogs())
			{
				_books.Add(new BookViewModel(catalog));
			}
		}
	}
}
