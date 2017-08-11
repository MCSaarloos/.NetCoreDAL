using NetCoreDal.Domain.Entities.Abstract;

namespace NetCoreDAL.DataAccess.Infrastructure.Interfaces
{
    public interface IUpdateRepository<in T> where T : EntityBase
    {
        void Update(T entity);
    }
}
