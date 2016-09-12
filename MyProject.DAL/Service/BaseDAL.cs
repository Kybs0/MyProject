using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MyProject.DAL.IService;

namespace MyProject.DAL.Service
{
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : Entity.Entity.Entity
    {
        protected readonly DbContext DB = EFDataContext.GetCurrentDbContext();
        private DbContextTransaction _transaction;
        public IQueryable<T> AsQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            var query = DB.Set<T>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public T GetById(int id)
        {
            return DB.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            DB.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            DB.Set<T>().Attach(entity);
            DB.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DB.Set<T>().Remove(entity);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DB.Set<T>().Any(predicate);
        }

        #region 事务
        public int SaveChanges()
        {
            return DB.SaveChanges();
        }

        public IDisposable BeginTransaction()
        {
            _transaction = DB.Database.BeginTransaction();
            return _transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DB != null)
                {
                    DB.Dispose();
                }
            }
        }
        #endregion
    }
}
