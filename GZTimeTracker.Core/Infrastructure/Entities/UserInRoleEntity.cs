using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class UserInRoleEntity : BaseEnitity
    {
        [Required]
        public int ProjectId { get; set; }

        public ProjectEntity Project { get; set; }

        [Required]
        public int UserId { get; set; }

        public UserEntity User { get; set; }

        [Required]
        public bool IsSystemRole { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
