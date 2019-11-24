using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class TeamEntity : BaseEnitity
    {
        [Required]
        public UserEntity Owner { get; set; }
        
        [Required]
        public UserEntity Member { get; set; }
    }
}
