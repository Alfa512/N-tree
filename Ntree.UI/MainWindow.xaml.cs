using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using Ntree.Common.Contracts.Repositories;
using Ntree.Data.Entity;
using Ntree.Domain.Model.DataModel;

namespace Ntree.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DataContext _db;
		private readonly IDataAccessContext _dbs;
		public MainWindow(IDataAccessContext dbs)
		{
			
			//BootStrapper.Start();
			
		    InitializeComponent();
		    _db = new DataContext();
            _dbs = dbs;
        }

	    private void BindData()
		{
			var users = new ObservableCollection<User>(_db.GetAllUsers());
			var images = new ObservableCollection<Image>(_db.GetAllImages());
			UsersGrid.ItemsSource = users.ToBindingList();
			ImagessGrid.ItemsSource = images.ToBindingList();
			_dbs.UpdateUsers(users.ToList());
		    _dbs.UpdateImages(images.ToList());

        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			BindData();
		}

		private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItem_Click_Start(object sender, RoutedEventArgs e)
		{
			BindData();
		}
	}
}
