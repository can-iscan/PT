using Model;
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
			ModelAPI model = ModelAPI.CreateModel();

			IUser user = model.CreateUser(
				0,
				addUserVM.Firstname,
				addUserVM.LastName
				);

			model.AddUser(user);
		}
	}
}
