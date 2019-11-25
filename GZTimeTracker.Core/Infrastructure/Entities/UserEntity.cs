using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class UserEntity : BaseEnitity
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<RoleEntity> Roles { get; set; }

        public ICollection<ProjectEntity> Projets { get; set; }

        public ICollection<TeamEntity> Team { get; set; }

        public ICollection<ClientEntity> Clients { get; set; }

        public ICollection<UsersOnProjectEntity> UsersOnProjects { get; set; }
    }
}
