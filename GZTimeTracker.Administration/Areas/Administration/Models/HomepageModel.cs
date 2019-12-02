using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Administration.Areas.Administration.Models
{
    public class HomepageModel
    {
        public int UsersCount { get; set; }
        public int ProjectCount { get; set; }
        public int TaskCount { get; set; }
    }
}
