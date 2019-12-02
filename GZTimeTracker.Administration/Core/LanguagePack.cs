using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Administration.Core
{
    public class LanguagePack
    {
        public string Name { get; set; }

        public string PackVersion { get; set; }

        public string SupportedVersion { get; set; }

        public string Code { get; set; }

        public List<LanguageItem> Resources { get; set; }
    }
}
