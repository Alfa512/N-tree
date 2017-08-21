using System.Collections.Generic;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Common.Contracts.Repositories
{
	public interface IDataAccessContext
	{
		List<User> UpdateUsers(List<User> users);
		User AddUser(User user);
		List<User> GetAllUsers();
		List<Image> GetAllImages();
		List<Image> UpdateImages(List<Image> images);
		Image AddImage(Image image);
	}
}