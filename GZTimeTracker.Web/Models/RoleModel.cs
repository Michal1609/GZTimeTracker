using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class RoleModel
    {
        public string Role { get; set; }

        public string Description { get; set; }

        public ICollection<ActionModel> Actions { get; set; }
    }
}
