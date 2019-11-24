using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class ClientModel
    {
        public UserModel Owner { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public ICollection<ProjectModel> Projects { get; set; }
    }
}
