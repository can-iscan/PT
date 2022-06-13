using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel.Commands
{
	class SubmitAddBookCommand : CommandBase
	{
		private readonly AddBookViewModel addBookVM;

		public SubmitAddBookCommand(AddBookViewModel addBookVM) {
			this.addBookVM = addBookVM;
		}

		public override void Execute(object parameter)
		{
			ModelAPI model = ModelAPI.CreateModel();

			ICatalog catalog = model.CreateCatalog(
				addBookVM.Title,
				addBookVM.Author,
				Int32.Parse(addBookVM.NumOfPages)
				);

			model.AddCatalog(catalog);
		}
	}
}
