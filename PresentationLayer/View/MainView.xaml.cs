using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PresentationLayer.ViewModel;

namespace PresentationLayer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainViewModel viewModel;

		public MainWindow()
		{
			this.viewModel = new MainViewModel();
			DataContext = viewModel;
			InitializeComponent();
		}

		private void GetCatalogs_Click(object sender, RoutedEventArgs e)
		{
			GridTable.ItemsSource = viewModel.catalogs;
		}

		private void GetUsers_Click(object sender, RoutedEventArgs e)
		{
			GridTable.ItemsSource = viewModel.users;
		}
	}
}
