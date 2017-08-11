using NetCoreDAL.Domain.Entities;
using System.Collections.Generic;

namespace NetCoreDAL.Businesss.Infrastructure.Interfaces
{
    public interface ISettingsLogic
    {
        IEnumerable<Settings> GetAllSettings();
    }
}
