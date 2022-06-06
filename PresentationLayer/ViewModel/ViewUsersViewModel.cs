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
	public class ViewUsersViewModel : ViewModelBase
	{
		private readonly ObservableCollection<UserViewModel> _users;

		public IEnumerable<UserViewModel> Users => _users;

		public ICommand AddUserCommand { get; }

		public ViewUsersViewModel()
		{
			this._users = new ObservableCollection<UserViewModel>();

			Service service = new Service();

			List<User> users = new List<User>();

			users = User.getUserListFromService(service.DataService.getAllUsers());

			foreach (User user in users)
			{
				_users.Add(new UserViewModel(user));
			}
		}
	}
}
