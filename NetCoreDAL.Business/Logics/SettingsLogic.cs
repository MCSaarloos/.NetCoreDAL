using NetCoreDAL.Businesss.Infrastructure.Interfaces;
using NetCoreDAL.DataAccess.Infrastructure.Interfaces;
using NetCoreDAL.Domain.Entities;
using System.Collections.Generic;

namespace NetCoreDAL.Business.Logics
{
    public class SettingsLogic : ISettingsLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadRepository<Settings> _repository;

        public SettingsLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<Settings>();
        }

        public IEnumerable<Settings> GetAllSettings()
        {
            return _repository.GetAll();
        }
    }
}
