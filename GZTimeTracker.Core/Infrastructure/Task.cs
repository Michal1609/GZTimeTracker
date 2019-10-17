using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    /// <summary>
    /// Represent project tak
    /// </summary>
    public class Task : BaseClass
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }       

        /// <summary>
        /// Project
        /// </summary>
        public Project Project { get; set; }
    }
}
