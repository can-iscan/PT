using ServiceLayer;
using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public Service service;
		public List<Catalog> catalogs;
		public List<User> users;

		public MainViewModel()
		{
			this.service = new Service();

			Task.Run(() => {
				this.catalogs = this.service.DataService.getAllCatalogs();
				this.users = this.service.DataService.getAllUsers();
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChange(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
