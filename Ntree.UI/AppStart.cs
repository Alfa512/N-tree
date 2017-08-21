using System;
using Autofac;
using Autofac.Core;
using Ntree.Common.Contracts;
using Ntree.Common.Contracts.Repositories;
using Ntree.Data.Entity.NtreeAccess;
using Ntree.Data.Entity.NtreeAccess.Repositories;

namespace Ntree.UI
{
	public static class BootStrapper
	{
		private static ILifetimeScope _rootScope;

		//public static IViewModel RootVisual
		//{
		//	get
		//	{
		//		if (_rootScope == null)
		//		{
		//			Start();
		//		}

		//		_chromeViewModel = _rootScope.Resolve<IChromeViewModel>();
		//		return _chromeViewModel;
		//	}
		//}

		public static void Start()
		{
			if (_rootScope != null)
			{
				return;
			}

			var builder = new ContainerBuilder();
			//var assemblies = new[] { Assembly.GetExecutingAssembly() };
			builder.RegisterType<UserRepository>().As<IUserRepository>();
			builder.RegisterType<ImageRepository>().As<IImageRepository>();
			builder.RegisterType<DatabaseContext>().As<IDataContext>();
			builder.RegisterType<DataContext>().As<IDataAccessContext>();

			//builder.RegisterAssemblyTypes(assemblies)
			//	.Where(t => typeof(IService).IsAssignableFrom(t))
			//	.SingleInstance()
			//	.AsImplementedInterfaces();

			//builder.RegisterAssemblyTypes(assemblies)
			//	.Where(t => typeof(IViewModel).IsAssignableFrom(t) && !typeof(ITransientViewModel).IsAssignableFrom(t))
			//	.AsImplementedInterfaces();

			// several view model instances are transitory and created on the fly, if these are tracked by the container then they
			// won't be disposed of in a timely manner

			//builder.RegisterAssemblyTypes(assemblies)
			//	.Where(t => typeof(IViewModel).IsAssignableFrom(t))
			//	.Where(t =>
			//	{
			//		var isAssignable = typeof(ITransientViewModel).IsAssignableFrom(t);
			//		if (isAssignable)
			//		{
			//			Debug.WriteLine("Transient view model - " + t.Name);
			//		}

			//		return isAssignable;
			//	})
			//	.AsImplementedInterfaces()
			//	.ExternallyOwned();

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
}