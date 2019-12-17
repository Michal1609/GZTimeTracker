using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models.ViewModels
{
    public class TimeIndexViewModel
    {
        public IList<ProjectModel> Projects { get; set; }

        public IList<RunningTaskModel> RunnigTask { get; set; }

        public IList<TaskForRunModel> TasksForRun { get; set; }
        
    }
}
