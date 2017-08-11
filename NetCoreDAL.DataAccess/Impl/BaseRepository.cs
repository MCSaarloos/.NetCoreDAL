using Microsoft.EntityFrameworkCore;
using NetCoreDal.Domain.Entities.Abstract;
using NetCoreDAL.DataAccess.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCoreDAL.DataAccess.Impl
{
    public class BaseRepository<TEntity> : Disposable, IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbContext _dataContext;
        internal readonly DbSet<TEntity> EntitySet;

        public BaseRepository(DbContext dataContext)
        {
            _dataContext = dataContext;
            EntitySet = _dataContext.Set<TEntity>();
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }

        public virtual void Add(TEntity entity)
        {
            EntitySet.Add(entity);
        }

        public virtual void Delete(Guid id)
        {
            var dataObject = Get(id);
            if (dataObject != null)
                Delete(dataObject);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dataContext.Entry(entity).State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
            }
            EntitySet.Remove(entity);
        }

        public virtual TEntity Get(Guid id)
        {
            return EntitySet.FirstOrDefault(x => x.Id == id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.FirstOrDefault(predicate);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = EntitySet;
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query.FirstOrDefault(predicate);
        }

        public virtual IList<TEntity> GetAll()
        {
            return EntitySet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.AsQueryable().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = EntitySet;
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = EntitySet;
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query.Where(predicate);
        }

        public virtual void Update(TEntity entity)
        {
            EntitySet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<TEntity> GetIQueryable()
        {
            return EntitySet.AsQueryable();
        }

        public virtual IList<TEntity> GetAllPaged(int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = EntitySet.Count();
            return EntitySet.Skip(pageSize * pageIndex).Take(pageSize).ToList();
        }
    }
}
