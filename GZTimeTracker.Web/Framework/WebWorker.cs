using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GZTimeTracker.Web.Framework
{
    public class WebWorker
    {        
        public static IList<LanguageEntity> InstalledLanguages { get; set; }

        public static int GetLanguageIdForCode(string languageCode)
        {
           return (from row in WebWorker.InstalledLanguages
                              where row.Code == languageCode
                              select row.Id).FirstOrDefault();

        }
    }
}
