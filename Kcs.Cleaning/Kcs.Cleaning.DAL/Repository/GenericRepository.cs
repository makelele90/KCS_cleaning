using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Kcs.Cleaning.DAL.Repository
{
    public abstract class GenericRepository<T, TDbContext> : BaseRepository<TDbContext>, IRepository<T>
        where TDbContext : DbContext, new()
        where T : class
    {

        public T[] FindAll()
        {
            return Context.Set<T>().ToArray();
        }
        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }
        public T[] Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToArray();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            SaveChanges();

        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            SaveChanges();
        }
    }
}
