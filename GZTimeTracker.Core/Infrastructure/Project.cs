using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    /// <summary>
    /// Represent a project
    /// </summary>
    public class Project : BaseClass
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public DateTime StarTimeUTC { get; set; }

        public DateTime EndTimeUTC { get; set; }

        public Client Client { get; set; }

        public IList<Task> Tasks { get; set; }
    }
}
