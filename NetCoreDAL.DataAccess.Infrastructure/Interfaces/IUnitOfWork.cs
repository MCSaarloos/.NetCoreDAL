using NetCoreDal.Domain.Entities.Abstract;
using System;
using System.Threading.Tasks;

namespace NetCoreDAL.DataAccess.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChanges();
        IRepository<T> Repository<T>() where T : EntityBase;
    }
}
