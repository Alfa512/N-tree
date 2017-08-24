using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using Ntree.Common.Contracts;
using Ntree.Common.Contracts.Repositories;

namespace Ntree.Business.Services
{
	public class ConnectionService : IConnectionService
	{
		private readonly IApplicationDbContext _source = null;
		private readonly IDatabaseContext _destination = null;
		public void ChangeDatabase(
				string sourceonnectionStringName = "",
				string destconnectionStringName = "",
				string initialCatalog = "",
				string dataSource = "",
				string userId = "",
				string password = "",
				bool integratedSecuity = true)
		{
			try
			{
				if (!string.IsNullOrEmpty(sourceonnectionStringName))
				{
					var configNameEf = _source != null
						? _source.GetType().Name
						: sourceonnectionStringName;

					// add a reference to System.Configuration
					var entityCnxStringBuilder = new EntityConnectionStringBuilder
					(System.Configuration.ConfigurationManager
						.ConnectionStrings[!string.IsNullOrEmpty(configNameEf) ? configNameEf : ""]
						.ConnectionString);

					// init the sqlbuilder with the full EF connectionstring cargo
					var sqlCnxStringBuilder = new SqlConnectionStringBuilder
						(entityCnxStringBuilder.ProviderConnectionString);

					// only populate parameters with values if added
					if (!string.IsNullOrEmpty(initialCatalog))
						sqlCnxStringBuilder.InitialCatalog = initialCatalog;
					if (!string.IsNullOrEmpty(dataSource))
						sqlCnxStringBuilder.DataSource = dataSource;
					if (!string.IsNullOrEmpty(userId))
						sqlCnxStringBuilder.UserID = userId;
					if (!string.IsNullOrEmpty(password))
						sqlCnxStringBuilder.Password = password;

					// set the integrated security status
					sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

					// now flip the properties that were changed
					if (_source != null)
						_source.Database.Connection.ConnectionString
							= sqlCnxStringBuilder.ConnectionString;
				}
				if (string.IsNullOrEmpty(destconnectionStringName)) return;
				{
					var configNameEf = _source != null
						? _source.GetType().Name
						: destconnectionStringName;

					var entityCnxStringBuilder = new EntityConnectionStringBuilder
					(System.Configuration.ConfigurationManager
						.ConnectionStrings[!string.IsNullOrEmpty(configNameEf) ? configNameEf : ""]
						.ConnectionString);

					var sqlCnxStringBuilder = new SqlConnectionStringBuilder
						(entityCnxStringBuilder.ProviderConnectionString);

					if (!string.IsNullOrEmpty(initialCatalog))
						sqlCnxStringBuilder.InitialCatalog = initialCatalog;
					if (!string.IsNullOrEmpty(dataSource))
						sqlCnxStringBuilder.DataSource = dataSource;
					if (!string.IsNullOrEmpty(userId))
						sqlCnxStringBuilder.UserID = userId;
					if (!string.IsNullOrEmpty(password))
						sqlCnxStringBuilder.Password = password;

					sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

					if (_destination != null)
						_destination.Database.Connection.ConnectionString
							= sqlCnxStringBuilder.ConnectionString;
				}
			}
			catch (Exception)
			{
				// set log item if required
			}
		}
	}
}