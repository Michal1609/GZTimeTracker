using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    /// <summary>
    /// Represent tasks users are working on right now
    /// </summary>
    public class RunningTaskEntity : BaseEnitity
    {        
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public int  UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTime StarTimeUTC { get; set; }
    }
}
