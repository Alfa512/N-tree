using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using Ntree.Data.Entity;
using Ntree.Domain.Model.DataModel;

namespace Ntree.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DataContext db;
		public MainWindow()
		{
			InitializeComponent();
			db = new DataContext();
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var users = new ObservableCollection<User>(db.GetAllUsers());
			var images = new ObservableCollection<Image>(db.GetAllImages());
			UsersGrid.ItemsSource = users.ToBindingList();
			ImagessGrid.ItemsSource = images.ToBindingList();
		}

		private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
