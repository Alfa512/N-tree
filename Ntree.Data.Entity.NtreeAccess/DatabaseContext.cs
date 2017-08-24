using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Ntree.Common.Contracts;
using Ntree.Common.Contracts.Repositories;
using Ntree.Data.Entity.NtreeAccess.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity.NtreeAccess
{
    public class DatabaseContext : DbContext, IDatabaseContext
	{
		//private IUserRepository _userRepository;
		//private IImageRepository _imageRepository;
		private IConfigurationService _configurationService;
		public DatabaseContext(IConfigurationService configurationService/*IUserRepository userRepository, IImageRepository imageRepository*/) : base(
			configurationService.DestinationConnectionString)
        {
	        _configurationService = configurationService;
			//_userRepository = userRepository;
			//_imageRepository = imageRepository;
			Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        IUserRepository IDatabaseContext.Users => new UserRepository(this);
        IImageRepository IDatabaseContext.UserImages => new ImageRepository(this);

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
            //modelBuilder.Entity<User>();
            //modelBuilder.Entity<Image>();
            //modelBuilder.Conventions.Add(conven);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

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