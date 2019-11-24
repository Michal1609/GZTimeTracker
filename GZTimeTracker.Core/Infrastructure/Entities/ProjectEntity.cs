using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    /// <summary>
    /// Represent a project
    /// </summary>
    public class ProjectEntity : BaseEnitity
    {
        public UserEntity Owner { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public DateTime StarTimeUTC { get; set; }

        public DateTime EndTimeUTC { get; set; }

        public ClientEntity Client { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; }

        //public ICollection<int> 
    }
}
