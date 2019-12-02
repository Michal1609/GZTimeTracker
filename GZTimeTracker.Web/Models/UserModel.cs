using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class UserModel
    {
        [Display(Name = "UserModel.Email")]
        public string Email { get; set; }
        [Display(Name = "UserModel.FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "UserModel.LastName")]
        public string LastName { get; set; }
        [Display(Name = "UserModel.Roles")]
        public ICollection<RoleModel> Roles { get; set; }
        [Display(Name = "UserModel.Projets")]
        public ICollection<ProjectModel> Projets { get; set; }
        [Display(Name = "UserModel.Team")]
        public ICollection<TeamModel> Team { get; set; }
        [Display(Name = "UserModel.Clients")]
        public ICollection<ClientModel> Clients { get; set; }
    }
}
