using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class ActionEntity : BaseEnitity
    {
        public string Entity { get; set; }

        public string Privilegia { get; set; }

        public string Description { get; set; }
    }
}
