using System.Collections.Generic;
using System.Linq;

namespace Ntree.Common.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
	    IEnumerable<T> AddRange(IEnumerable<T> entity);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
	    IEnumerable<T> DeleteRange(IEnumerable<T> entity);
        
   }
}