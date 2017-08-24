using System.Data.Entity;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Common.Contracts.Repositories
{
	public interface IApplicationDbContext
	{
		void Commit();
		void DisposeData();
		DbSet<User> Users { get; }
		DbSet<Image> UserImages { get; }
		Database Database { get; }
	}
}