using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class SpendTimeEntity : BaseEnitity
    {
        public int TaskId { get; set; }

        public TaskEntity Task { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan SpandedTime { get; set; }
    }
}
