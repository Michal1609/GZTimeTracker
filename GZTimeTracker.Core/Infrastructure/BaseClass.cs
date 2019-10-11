using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    /// <summary>
    /// Base class for database objects
    /// </summary>
    public abstract class BaseClass
    {
        /// <summary>
        /// Unique indetifivator as primary key
        /// </summary>
        public int Id { get; set; }
    }
}
