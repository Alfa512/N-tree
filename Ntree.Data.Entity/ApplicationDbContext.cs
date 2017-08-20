using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Ntree.Common.Contracts;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity
{
	public class ApplicationDbContext : DbContext//, IDataContext
	{
		public ApplicationDbContext() : base("ConnectionString")
		{
			Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Image> Images { get; set; }

		//void IDataContext.Commit()
		//{
		//	SaveChanges();
		//}

		//void IDisposable.Dispose()
		//{
		//	Dispose();
		//}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>();
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

		}
		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}