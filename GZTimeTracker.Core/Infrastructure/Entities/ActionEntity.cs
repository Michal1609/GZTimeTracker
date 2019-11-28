using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class ActionEntity : BaseEnitity
    {
        [Required]
        public string Action { get; set; }
        public string Description { get; set; }
        public ICollection<SystemRoleActionsEntity> SystemRoleActions { get; set; }

        public ICollection<CustomerRoleActionsEntity> CustomerRoleActions { get; set; }
    }
}
