using NetCoreDal.Domain.Entities.Abstract;

namespace NetCoreDAL.DataAccess.Infrastructure.Interfaces
{
    public interface ICreateRepository<T> where T : EntityBase
    {
        void Add(T entity);
    }
}
