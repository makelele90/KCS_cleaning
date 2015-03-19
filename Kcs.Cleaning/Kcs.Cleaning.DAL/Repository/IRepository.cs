using System;
using System.Linq.Expressions;

namespace Kcs.Cleaning.DAL.Repository
{
    public interface IRepository<T>
    {
        T[] FindAll();
        T Single(Expression<Func<T, bool>> predicate);
        T[] Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
