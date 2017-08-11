using NetCoreDAL.Businesss.Infrastructure.Interfaces;
using NetCoreDAL.DataAccess.Infrastructure.Interfaces;
using NetCoreDAL.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreDAL.Business.Logics
{
    public class SettingsLogic : ISettingsLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Settings> _repository;

        public SettingsLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<Settings>();
        }

        public IEnumerable<Settings> GetAllSettings()
        {
            return _repository.GetAll();
        }

        public async Task<bool> SaveSettings(Settings settings)
        {
            _repository.Add(settings);
            return await _unitOfWork.SaveChanges();
        }
    }
}
