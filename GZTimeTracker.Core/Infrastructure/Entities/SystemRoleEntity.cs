using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class SystemRoleEntity : BaseEnitity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public ICollection<SystemRoleActionsEntity> SystemRoleActions { get; set; }
    }
}
