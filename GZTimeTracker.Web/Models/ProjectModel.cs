using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class ProjectModel
    {
        //[Display(Name ="Owner")]
        //public UserModel Owner { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "StarTimeUTC")]
        public DateTime StarTimeUTC { get; set; }

        [Display(Name = "EndTimeUTC")]
        public DateTime EndTimeUTC { get; set; }

        //[Display(Name = "Client")]
        //public ClientModel Client { get; set; }

        //[Display(Name = "Tasks")]
        //public ICollection<TaskModel> Tasks { get; set; }
    }
}
