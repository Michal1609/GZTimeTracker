using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class CustomerRoleActionsEntity : BaseEnitity
    {
        public int CustomerRoleId { get; set; }
        public CustomerRolesEntity CustomerRole { get; set; }

        public int ActionId { get; set; }
        public ActionEntity Action { get; set; }
    }
}
