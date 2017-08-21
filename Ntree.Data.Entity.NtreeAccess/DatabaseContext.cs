using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Ntree.Common.Contracts;
using Ntree.Common.Contracts.Repositories;
using Ntree.Data.Entity.NtreeAccess.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity.NtreeAccess
{
	public class DatabaseContext : DbContext, IDataContext
	{
		public DatabaseContext() : base("DestinationConnection")
		{
			Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
		}

		IUserRepository IDataContext.Users => new UserRepository(this);
		IImageRepository IDataContext.UserImages => new ImageRepository(this);

		public void Commit()
		{
			SaveChanges();
		}

		public void DisposeData()
		{
			Dispose();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>();
			modelBuilder.Entity<Image>();
			//modelBuilder.Conventions.Add(conven);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public static DatabaseContext Create()
		{
			return new DatabaseContext();
		}
	}
}