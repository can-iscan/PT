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
	public class ViewUsersViewModel : ViewModelBase
	{
		private readonly ObservableCollection<UserViewModel> _users;

		public IEnumerable<UserViewModel> Users => _users;

		public ICommand AddUserCommand { get; }

		public ViewUsersViewModel()
		{
			this._users = new ObservableCollection<UserViewModel>();

			ModelAPI model = ModelAPI.CreateModel();

			foreach (IUser user in model.GetAllUsers())
			{
				_users.Add(new UserViewModel(user));
			}
		}
	}
}
