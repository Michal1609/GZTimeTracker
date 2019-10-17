using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public class Client : BaseClass
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public IList<Project> Projects { get; set; }
    }
}
