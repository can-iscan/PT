using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel.Commands
{
	public class BorrowCommand : CommandBase
	{
		private readonly BorrowReturnViewModel borrowVM;

		public BorrowCommand(BorrowReturnViewModel borrowVM)
		{
			this.borrowVM = borrowVM;
		}

		public override void Execute(object parameter)
		{
			ModelAPI model = ModelAPI.CreateModel();

			model.BorrowCatalog(borrowVM.Title, Int32.Parse(borrowVM.UserId));
		}
	}
}
