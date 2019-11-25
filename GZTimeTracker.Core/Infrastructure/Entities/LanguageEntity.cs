using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class LanguageEntity : BaseEnitity
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<LocaleStringResourceEntity> LocaleStringResources { get; set; }
    }
}
