using System.Collections.Generic;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Common.Contracts.Repositories
{
	public interface IDataContext
	{
		List<User> GetAllUsers();
		List<Image> GetAllImages();
	}
}