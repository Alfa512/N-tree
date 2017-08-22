using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ntree.Common.Contracts.Repositories;

namespace Ntree.Data.Entity.NtreeAccess
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext Context;

        protected GenericRepository(DatabaseContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T Create(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

	    public IEnumerable<T> AddRange(IEnumerable<T> entity)
	    {
            return Context.Set<T>().AddRange(entity);
	    }

		public T Update(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry = Context.Entry(entity);
            }

            entry.State = EntityState.Modified;

            return entity;
        }

        public T Delete(T entity)
        {
            return Context.Set<T>().Remove(entity);
        }

	    public IEnumerable<T> DeleteRange(IEnumerable<T> entity)
	    {
		    return Context.Set<T>().RemoveRange(entity);
	    }

	}
}