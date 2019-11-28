using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class SystemRole
    {
        public int id { get; set; }

        public string Name { get; set; }

        public IList<string> Actions { get; set; }
    }
}
