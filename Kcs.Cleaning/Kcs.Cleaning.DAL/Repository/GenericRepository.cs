using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Kcs.Cleaning.Datacontainer.DTO;

namespace Kcs.Cleaning.DAL.Repository
{
    public class GenericRepository<T, TDbContext> : IRepository<T>
        where T : class
        where TDbContext : DbContext, new()
    {
        private DbContext _unitOfWork;
        protected DbContext UnitOfWork
        {
            get
            {
                if (_unitOfWork == null) _unitOfWork = new TDbContext();

                return _unitOfWork;
            }
        }
        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
        public T Single(Expression<Func<T, bool>> predicate)
        {
            return UnitOfWork.Set<T>().FirstOrDefault(predicate);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return UnitOfWork.Set<T>().Where(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return UnitOfWork.Set<T>().Select(e => e);
        }

        public OperationStatus Create(T item)
        {
            OperationStatus status;

            try
            {
                UnitOfWork.Set<T>().Add(item);

                SaveChanges();

                status = new OperationStatus()
                {
                    Status = true,
                    Message = "sucessfully created user"
                };
            }
            catch (Exception ex)
            {
                status = OperationStatus.CreateFromExeption(ex, "could not create user");
            }

            return status;
        }
        public OperationStatus Update(T entity)
        {

            OperationStatus status;
            try
            {
                UnitOfWork.Entry(entity).State = EntityState.Modified;

                SaveChanges();

                status = new OperationStatus()
                {
                    Status = true,
                    Message = "sucessfully update user"
                };
            }
            catch (Exception ex)
            {
                status = OperationStatus.CreateFromExeption(ex, "could not update user details");
            }

            return status;
        }
        public OperationStatus Delete(T entity)
        {
            OperationStatus status;
            try
            {
                UnitOfWork.Set<T>().Remove(entity);

                SaveChanges();

                status = new OperationStatus()
                {
                    Status = true,
                    Message = "sucessfully deleted user"
                };
            }
            catch (Exception ex)
            {
                status = OperationStatus.CreateFromExeption(ex, "could not delete user");
            }

            return status;
        }
    }
}
