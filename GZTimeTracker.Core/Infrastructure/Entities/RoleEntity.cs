using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class RoleEntity : BaseEnitity
    {
        public string Role { get; set; }

        public string Description { get; set; }

        public ICollection<ActionEntity> Actions { get; set; }
    }
}
