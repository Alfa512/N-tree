using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity
{
	public class ApplicationDbContext : DbContext//, IDataContext
	{
		public ApplicationDbContext() : base("DefaultConnection")
		{
			//Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Image> UserImages { get; set; }

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
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

		}
		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}