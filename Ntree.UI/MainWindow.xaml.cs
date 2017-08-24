using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using Ntree.Common.Contracts.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IDataAccessContext _dbs;
		private readonly IConfigurationService _configurationService;
		private readonly IConnectionService _connectionService;
		private readonly IDataContext _dataContext;

		private readonly ManageConnection _manageConnection;
		public MainWindow(IDataContext dataContext, IDataAccessContext dbs, IConfigurationService configurationService, IConnectionService connectionService)
		{
			//BootStrapper.Start();
			
		    InitializeComponent();
			_configurationService = configurationService;
			_connectionService = connectionService;
			_dataContext = dataContext;
            _dbs = dbs;
			_manageConnection = new ManageConnection(_configurationService, _connectionService);
		}

	    private void BindData()
		{
			var users = new ObservableCollection<User>(_dataContext.GetAllUsers());
			var images = new ObservableCollection<Image>(_dataContext.GetAllImages());
			UsersGrid.ItemsSource = users.ToBindingList();
			ImagessGrid.ItemsSource = images.ToBindingList();
			//_dbs.UpdateUsers(users.ToList());
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

		private void MenuItem_Click_ConnManage(object sender, RoutedEventArgs e)
		{
			_manageConnection.SourceConnStringTb.Text = _configurationService.SourceConnectionString;
			_manageConnection.DestConnStringTb.Text = _configurationService.DestinationConnectionString;
			_manageConnection.ShowDialog();
		}
	}
}
