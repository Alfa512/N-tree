using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ntree.Common.Contracts.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity
{
	public class DataContext : IDataContext
	{
		private readonly IApplicationDbContext _dbContext;

		public DataContext(IApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbContext.Users.Load();
			_dbContext.UserImages.Load();
		}

		public List<User> GetAllUsers()
		{
			var users = _dbContext.Users.ToList();
			return users;
		}
		public List<Image> GetAllImages()
		{
			var images = _dbContext.UserImages.ToList();
			return images;
		}
	}
}
