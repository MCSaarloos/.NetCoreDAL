using NetCoreDAL.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreDAL.Businesss.Infrastructure.Interfaces
{
    public interface ISettingsLogic
    {
        IEnumerable<Settings> GetAllSettings();
        Task<bool> SaveSettings(Settings settings);
    }
}
