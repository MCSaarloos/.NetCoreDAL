using NetCoreDal.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCoreDAL.DataAccess.Infrastructure.Interfaces
{
    public interface IReadRepository<T> where T : EntityBase
    {
        T Get(Guid id);
        T Get(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetIQueryable();
        IList<T> GetAllPaged(int pageIndex, int pageSize, out int totalCount);
    }
}
