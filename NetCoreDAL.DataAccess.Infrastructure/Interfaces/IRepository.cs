using NetCoreDal.Domain.Entities.Abstract;

namespace NetCoreDAL.DataAccess.Infrastructure.Interfaces
{
    public interface IRepository<T> :
        ICreateRepository<T>,
        IReadRepository<T>,
        IUpdateRepository<T>,
        IDeleteRepository<T>
        where T : EntityBase
    {
    }
}
