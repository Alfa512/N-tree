using System.Collections.Generic;
using System.Linq;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity
{
	public class DataContext
	{
		private readonly ApplicationDbContext _dbContext;

		public DataContext()
		{
			_dbContext = new ApplicationDbContext();
			_dbContext.Database.Initialize(false);
		}

		public List<User> GetAllUsers()
		{
			var users = _dbContext.Users.ToList();
			return users;
		}
		public List<Image> GetAllImages()
		{
			var images = _dbContext.Images.ToList();
			return images;
		}
	}
}
