using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel.Commands
{
	class SubmitAddUserCommand : CommandBase
	{
		private readonly AddUserViewModel addUserVM;

		public SubmitAddUserCommand(AddUserViewModel addUserVM)
		{
			this.addUserVM = addUserVM;
		}

		public override void Execute(object parameter)
		{
			Service service = new Service();

			User user = new User(
				0,
				addUserVM.Firstname,
				addUserVM.LastName
				);

			service.DataService.addUser(user.getServiceLayerUser());
		}
	}
}
