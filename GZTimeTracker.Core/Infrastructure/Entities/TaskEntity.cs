using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    /// <summary>
    /// Represent project tak
    /// </summary>
    public class TaskEntity : BaseEnitity
    {
        /// <summary>
        /// Project
        /// </summary>
        [Required]
        public ProjectEntity Project { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }       

        
    }
}
