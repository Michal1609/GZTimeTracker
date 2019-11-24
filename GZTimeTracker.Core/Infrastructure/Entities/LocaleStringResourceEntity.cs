using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class LocaleStringResourceEntity : BaseEnitity
    {
        [Required]
        [MaxLength(5)]
        public string Language { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        
        public string Value { get; set; }
    }
}
