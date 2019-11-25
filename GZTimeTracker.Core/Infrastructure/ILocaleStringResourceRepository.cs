using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface ILocaleStringResourceRepository : IRepository<LocaleStringResourceEntity>
    {
        string GetString(string name, int language);

        IList<LocaleStringResourceEntity> GetAllStrings();
    }
}
