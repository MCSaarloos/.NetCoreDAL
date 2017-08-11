using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreDal.Domain.Entities.Abstract;
using NetCoreDAL.DataAccess.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreDAL.DataAccess.Impl
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly DbContext _dataContext;
        private readonly ILogger<UnitOfWork> _logger;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(DbContext dataContext, ILogger<UnitOfWork> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }

        public IRepository<T> Repository<T>() where T : EntityBase
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var genericRepoType = repositoryType.MakeGenericType(typeof(T));
                var repositoryInstance = Activator.CreateInstance(genericRepoType, _dataContext);

                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<T>)_repositories[type];
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                var result = await _dataContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("The following error occurred while saving to the database: ", ex);
                throw;
            }
        }
    }
}
