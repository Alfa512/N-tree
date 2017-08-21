using Ntree.Common.Contracts.Repositories;
using Ntree.Domain.Model.DataModel;

namespace Ntree.Data.Entity.NtreeAccess.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(DatabaseContext context) : base(context)
        {
        }
    }
}