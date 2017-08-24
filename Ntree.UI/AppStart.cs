using System;
using Autofac;
using Autofac.Core;
using Ntree.Business.Services;
using Ntree.Common.Contracts;
using Ntree.Common.Contracts.Repositories;
using Ntree.Data.Entity;
using Ntree.Data.Entity.NtreeAccess;
using Ntree.Data.Entity.NtreeAccess.Repositories;
using DataContext = Ntree.Data.Entity.NtreeAccess.DataContext;

namespace Ntree.UI
{
	public static class BootStrapper
	{
		private static ILifetimeScope _rootScope;

		public static void Start()
		{
			if (_rootScope != null)
			{
				return;
			}

			var builder = new ContainerBuilder();

			builder.RegisterType<ConfigurationService>().As<IConfigurationService>().SingleInstance();
			builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
			builder.RegisterType<ImageRepository>().As<IImageRepository>().SingleInstance();
			builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().SingleInstance();
			builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().SingleInstance();
			builder.RegisterType<DataContext>().As<IDataAccessContext>().SingleInstance();
			builder.RegisterType<Data.Entity.DataContext>().As<IDataContext>().SingleInstance();
			builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
			


			// several view model instances are transitory and created on the fly, if these are tracked by the container then they
			// won't be disposed of in a timely manner

			//builder.RegisterAssemblyTypes(assemblies)
			//    .Where(t => typeof(IViewModel).IsAssignableFrom(t))
			//    .Where(t =>
			//    {
			//        var isAssignable = typeof(ITransientViewModel).IsAssignableFrom(t);
			//        if (isAssignable)
			//        {
			//            Debug.WriteLine("Transient view model - " + t.Name);
			//        }

			//        return isAssignable;
			//    })
			//    .AsImplementedInterfaces()
			//    .ExternallyOwned();

			_rootScope = builder.Build();
		}

		public static void Stop()
		{
			_rootScope.Dispose();
		}

		public static T Resolve<T>()
		{
			if (_rootScope == null)
			{
				throw new Exception("Bootstrapper hasn't been started!");
			}

			return _rootScope.Resolve<T>(new Parameter[0]);
		}

		public static T Resolve<T>(Parameter[] parameters)
		{
			if (_rootScope == null)
			{
				throw new Exception("Bootstrapper hasn't been started!");
			}

			return _rootScope.Resolve<T>(parameters);
		}
	}

	//public static class BootStrapper
	//{
	//    static IContainer AppContainer;
	//       public static void Start()
	//	{
	//	    var builder = new ContainerBuilder();

	//	    BuildupContainer(builder);

	//	    var container = builder.Build();

	//	    AppContainer = container;			
	//	}

	//    private static void BuildupContainer(ContainerBuilder builder)
	//    {
	//        builder.RegisterType<UserRepository>().As<IUserRepository>();
	//        builder.RegisterType<ImageRepository>().As<IImageRepository>();
	//        builder.RegisterType<DatabaseContext>().As<IDataContext>();
	//        builder.RegisterType<DataContext>().As<IDataAccessContext>();
	//       }

	//}
}