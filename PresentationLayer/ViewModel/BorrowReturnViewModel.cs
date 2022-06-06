using PresentationLayer.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
	public class BorrowReturnViewModel : ViewModelBase
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

		private string _id;
		public string UserId
		{
			get { return _id; }
			set
			{
				_id = value;
				OnPropertyChanged(nameof(UserId));
			}
		}

		public ICommand BorrowCommand { get; }
		public ICommand ReturnCommand { get; }
		public ICommand CancelCommand { get; }

		public BorrowReturnViewModel()
		{
			this.BorrowCommand = new BorrowCommand(this);
			this.ReturnCommand = new ReturnCommand(this);
			this.CancelCommand = new CancelCommand();
		}
	}
}
