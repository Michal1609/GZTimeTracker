using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class RoleActionsEntity : BaseEnitity
    {
        public int UserId { get; set; }

        public int ProjectId { get; set; }
        public int RoleId { get; set; }

        //public RoleEntity Role { get; set; }

        public string Action { get; set; }
    }
}
