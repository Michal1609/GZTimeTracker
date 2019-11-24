using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class ExceptionlogEntity : BaseEnitity
    {

        public DateTime TimeStamp { get; set; }
        [MaxLength(50)]
        public string Level { get; set; }

        [MaxLength(250)]
        public string Logger { get; set; }

        public string Message { get; set; }

        public int UserId { get; set; }

        public string Exception { get; set; }     
        public string stacktrace { get; set; }
    }
}
