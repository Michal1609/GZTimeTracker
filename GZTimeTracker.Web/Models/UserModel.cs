using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class UserModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }        

        public ICollection<RoleModel> Roles { get; set; }

        public ICollection<ProjectModel> Projets { get; set; }

        public ICollection<TeamModel> Team { get; set; }

        public ICollection<ClientModel> Clients { get; set; }
    }
}
