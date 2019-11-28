using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class CustomerRolesEntity : BaseEnitity
    {
        [Required]
        public int UserId { get; set; }

        public UserEntity User { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
        public ICollection<CustomerRoleActionsEntity> CustomerRoleActions { get; set; }
    }
}
