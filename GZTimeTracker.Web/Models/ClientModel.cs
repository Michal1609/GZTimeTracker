using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class ClientModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        /*
        [Display(Name = "ClientModel.Owner")]
        public UserModel Owner { get; set; }
        */
        [Display(Name = "ClientModel.Name")]
        public string Name { get; set; }

        [Display(Name = "ClientModel.Address")]
        public string Address { get; set; }

        [Display(Name = "ClientModel.Description")]
        public string Description { get; set; }
       
        [Display(Name = "ClientModel.Projects")]
        public ICollection<ProjectModel> Projects { get; set; }
    }
}
