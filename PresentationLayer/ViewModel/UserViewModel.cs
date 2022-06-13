using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel
{
	public class UserViewModel : ViewModelBase
	{
		private readonly IUser _user;

		public string Id => _user.Id.ToString();
		public string FirstName => _user.FirstName;
		public string LastName => _user.LastName;

		public UserViewModel(IUser user)
		{
			this._user = user;
		}
	}
}
