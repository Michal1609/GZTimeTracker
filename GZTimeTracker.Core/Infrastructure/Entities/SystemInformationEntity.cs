using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class SystemInformationEntity : BaseEnitity
    {
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Version { get; set; }
    }
}
