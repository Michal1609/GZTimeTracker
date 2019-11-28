using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class SystemRoleActionsEntity : BaseEnitity
    {
        public int SystemRoleId { get; set; }

        public SystemRoleEntity SystemRole { get; set; }

        public int ActionId { get; set; }

        public ActionEntity Action { get; set; }
    }
}
