using NetCoreDal.Domain.Entities.Abstract;
using System;

namespace NetCoreDAL.DataAccess.Infrastructure.Interfaces
{
    public interface IDeleteRepository<in T> where T : EntityBase
    {
        void Delete(T entity);
        void Delete(Guid id);
    }
}
