using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure.Entities
{
    public class TeamEntity : BaseEnitity
    {        
        public UserEntity User { get; set; }
        
        public UserEntity Member { get; set; }
    }
}
