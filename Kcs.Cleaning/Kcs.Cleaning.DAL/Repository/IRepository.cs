using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kcs.Cleaning.Datacontainer.DTO;

namespace Kcs.Cleaning.DAL.Repository
{
    public interface IRepository<T>
    {
        T Single(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll();
        OperationStatus Create(T entity);
        OperationStatus Update(T entity);
        OperationStatus Delete(T entity);
    }
}
