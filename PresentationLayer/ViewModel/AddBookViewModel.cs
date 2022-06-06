using PresentationLayer.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
	public class AddBookViewModel : ViewModelBase
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		private string _author;
		public string Author
		{
			get { return _author; }
			set
			{
				_author = value;
				OnPropertyChanged(nameof(Author));
			}
		}

		private string _numofpages;
		public string NumOfPages
		{
			get { return _numofpages; }
			set
			{
				_numofpages = value;
				OnPropertyChanged(nameof(NumOfPages));
			}
		}

		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		public AddBookViewModel() {
			this.SubmitCommand = new SubmitAddBookCommand(this);
			this.CancelCommand = new CancelCommand();
		}
	}
}
