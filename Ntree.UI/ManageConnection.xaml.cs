using System.Windows;
using Ntree.Common.Contracts.Repositories;

namespace Ntree.UI
{
	/// <summary>
	/// Interaction logic for ManageConnection.xaml
	/// </summary>
	public partial class ManageConnection : Window
	{
		private IConfigurationService _configurationService;
		private IConnectionService _connectionService;
		public ManageConnection(IConfigurationService configurationService, IConnectionService connectionService)
		{
			_configurationService = configurationService;
			_connectionService = connectionService;
			InitializeComponent();
		}

		private void Ok_Button_Click(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(SourceConnStringTb.Text.Trim()))
				_connectionService.ChangeDatabase(SourceConnStringTb.Text.Trim());

			if (!string.IsNullOrWhiteSpace(DestConnStringTb.Text.Trim()))
				_connectionService.ChangeDatabase(DestConnStringTb.Text.Trim());

			Close();
		}

		private void Cancel_Button_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
