using PresentationLayer.Model;
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
			Service service = new Service();

			Catalog catalog = new Catalog(
				addBookVM.Title,
				addBookVM.Author,
				Int32.Parse(addBookVM.NumOfPages)
				);

			service.DataService.addCatalog(catalog.getServiceLayerCatalog());
		}
	}
}
