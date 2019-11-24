using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class ClientEntity : BaseEnitity
    {
        [Required]
        public UserEntity Owner { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public ICollection<ProjectEntity> Projects { get; set; }
    }
}
