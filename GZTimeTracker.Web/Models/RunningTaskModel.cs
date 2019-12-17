using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class RunningTaskModel
    {
        [Display(Name = "RunningTaskModel.Id")]
        public int TaskId { get; set; }
        [Display(Name = "RunningTaskModel.Task")]
        public String Task { get; set; }

        [Display(Name = "RunningTaskModel.StartTime")]
        public DateTime StartTime { get; set; }

        public DateTime dateTime { get; set; }
    }
}
