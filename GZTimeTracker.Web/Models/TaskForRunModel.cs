using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class TaskForRunModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

        public string ProjectCode { get; set; }        

        public TimeSpan SpendTime { get; set; }

        public bool Running { get; set; }
    }
}
