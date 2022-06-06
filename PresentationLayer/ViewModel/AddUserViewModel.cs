using PresentationLayer.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
	public class AddUserViewModel : ViewModelBase
	{
		private string _fname;
		public string Firstname
		{
			get { return _fname; }
			set
			{
				_fname = value;
				OnPropertyChanged(nameof(Firstname));
			}
		}

		private string _lname;
		public string LastName
		{
			get { return _lname; }
			set
			{
				_lname = value;
				OnPropertyChanged(nameof(LastName));
			}
		}

		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		public AddUserViewModel() {
			this.SubmitCommand = new SubmitAddUserCommand(this);
			this.CancelCommand = new CancelCommand();
		}
	}
}
