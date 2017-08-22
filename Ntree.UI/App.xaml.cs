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
        //private void Application_Startup(object sender, StartupEventArgs e)
        //{
        //    
        //    ProcessInitParams(e.InitParams);
        //    this.RootVisual = new MainPage();
        //}

        private readonly CompositeDisposable _disposable;

        public App()
        {
   //AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            //Current.DispatcherUnhandledException += DispatcherOnUnhandledException;
            //TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            _disposable = new CompositeDisposable();
        }

        protected override void OnStartup(StartupEventArgs args)
        {

            //RenderCapability.TierChanged += (s, a) =>
            //    Logger.Info($"WPF rendering capability (tier) = {(RenderCapability.Tier / 0x10000).ToString()}");

            base.OnStartup(args);

            BootStrapper.Start();

            var dataAccessContext = BootStrapper.Resolve<IDataAccessContext>();
            //var messageService = BootStrapper.Resolve<IMessageService>();
            //var gestureService = BootStrapper.Resolve<IGestureService>();

            var window = new MainWindow(dataAccessContext);

            //window.DataContext = BootStrapper.RootVisual;

            window.Closed += HandleClosed;
            //Current.Exit += HandleExit;

            // Let's go...
            window.Show();


        }

        private void HandleClosed(object sender, EventArgs e)
        {
            _disposable.Dispose();
            BootStrapper.Stop();
        }

    }


}
