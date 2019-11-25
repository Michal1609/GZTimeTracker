using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class LocaleStringResourcesRepository : Repository<LocaleStringResourceEntity>, ILocaleStringResourceRepository
    {
        public LocaleStringResourcesRepository(DataContext context)
            : base(context)
        {

        }

        public IList<LocaleStringResourceEntity> GetAllStrings()
        {
            return table.ToList();
        }

        public string GetString(string name, int language)
        {
            var value = (from row in table
                         where row.Name == name &&
                               row.Language.Id == language
                         select row.Value).FirstOrDefault();

            return value;
        }
    }
}
