using System.Collections.Generic;
using System.Linq;
using Ntree.Common.Contracts;
using Ntree.Common.Contracts.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity.NtreeAccess
{
	public class DataContext : IDataAccessContext
	{
		private readonly IDataContext _dbContext;

		public DataContext(IDataContext dbContext)
		{
			_dbContext = dbContext;
			//_dbContext.Users. Load();
			//_dbContext.UserImages.Load();
		}

		public List<User> UpdateUsers(List<User> users)
		{
			if (_dbContext.Users.GetAll().Any())
			{
				_dbContext.Users.DeleteRange(_dbContext.Users.GetAll());
			}
			if (users.Any())
			{
				_dbContext.Users.AddRange(users);
			}
			_dbContext.Commit();
			return _dbContext.Users.GetAll().ToList();
		}

		public User AddUser(User user)
		{
			var newUser = _dbContext.Users.Create(user);
			_dbContext.Commit();
			return newUser;
		}

		public List<User> GetAllUsers()
		{
			return _dbContext.Users.GetAll().ToList();
		}
		public List<Image> GetAllImages()
		{
			return _dbContext.UserImages.GetAll().ToList();
		}

		public List<Image> UpdateImages(List<Image> images)
		{
			//using (var context = new DatabaseContext())
			//{
			var im = GetAllImages();
				if (_dbContext.UserImages.GetAll().Any())
				{
					_dbContext.UserImages.DeleteRange(_dbContext.UserImages.GetAll());
				}
				if (images.Any())
				{
				//foreach (var image in images)
				//{
				//	_dbContext.UserImages.Attach(image);
				//	_dbContext.UserImages.Add(image);
				//}
				//_dbContext.UserImages.Add(images[0]);
					_dbContext.UserImages.AddRange(new List<Image>(images));
				}
			_dbContext.Commit();
				return _dbContext.UserImages.GetAll().ToList();
			//}
		}
		public Image AddImage(Image image)
		{
			var newImage = _dbContext.UserImages.Create(image);
			_dbContext.Commit();
			return newImage;
		}
	}
}
