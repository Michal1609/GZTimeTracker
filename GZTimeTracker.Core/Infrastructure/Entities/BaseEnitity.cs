using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    /// <summary>
    /// Base class for database objects
    /// </summary>
    public abstract class BaseEnitity
    {
        /// <summary>
        /// Unique indetifivator as primary key
        /// </summary>
        public int Id { get; set; }
    }
}
