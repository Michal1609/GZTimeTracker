using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public ProjectModel Project { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// 
        [Display(Name = "TaskModel.Name")]
        public string Name { get; set; }
    }
}
