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
        public int Id { get; set; }

        [Display(Name = "ProjectModel.Name")]
        public string Name { get; set; }

        [Display(Name = "ProjectModel.Code")]
        public string Code { get; set; }

        [Display(Name = "ProjectModel.Description")]
        public string Description { get; set; }

        [Display(Name = "ProjectModel.StarTimeUTC")]
        public DateTime StarTimeUTC { get; set; }

        [Display(Name = "ProjectModel.EndTimeUTC")]
        public DateTime EndTimeUTC { get; set; }

        //[Display(Name = "Client")]
        //public ClientModel Client { get; set; }

        [Display(Name = "ProjectModel.Tasks")]
        public IList<TaskModel> Tasks { get; set; }
    }
}
