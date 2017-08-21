using Ntree.Common.Contracts.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity.NtreeAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}