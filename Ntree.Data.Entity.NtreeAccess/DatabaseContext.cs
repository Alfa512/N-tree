using System.Data.Entity;
using Ntree.Common.Contracts;
using Ntree.Common.Contracts.Repositories;
using Ntree.Data.Entity.NtreeAccess.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity.NtreeAccess
{
	public class DatabaseContext : DbContext, IDataContext
	{
	    //private IUserRepository _userRepository;
	    //private IImageRepository _imageRepository;
        public DatabaseContext(/*IUserRepository userRepository, IImageRepository imageRepository*/) : base("DestinationConnection")
        {
            //_userRepository = userRepository;
            //_imageRepository = imageRepository;
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
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

		    modelBuilder.Entity<Image>()
		        .HasRequired(s => s.User)
		        .WithMany(s => s.UserImages)
		        .HasForeignKey(s => s.UserId);
        }


		//public static DatabaseContext Create()
		//{
		//	return new DatabaseContext();
		//}
	}
}