using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel
{
	public class UserViewModel : ViewModelBase
	{
		private readonly User _user;

		public string Id => _user.Id.ToString();
		public string FirstName => _user.FirstName;
		public string LastName => _user.LastName;

		public UserViewModel(User user)
		{
			this._user = user;
		}
	}
}
