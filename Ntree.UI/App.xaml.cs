using System;
using System.Windows;
using Ntree.Common.Contracts.Repositories;
using System.Reactive.Disposables;

namespace Ntree.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly CompositeDisposable _disposable;

        public App()
        {
            _disposable = new CompositeDisposable();
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            BootStrapper.Start();

            var dataContext = BootStrapper.Resolve<IDataContext>();
            var dataAccessContext = BootStrapper.Resolve<IDataAccessContext>();
            var configurationService = BootStrapper.Resolve<IConfigurationService>();
            var connectionService = BootStrapper.Resolve<IConnectionService>();

            var window = new MainWindow(dataContext, dataAccessContext, configurationService, connectionService);

            window.Closed += HandleClosed;
            window.Show();
        }

        private void HandleClosed(object sender, EventArgs e)
        {
            _disposable.Dispose();
            BootStrapper.Stop();
        }

    }
}
