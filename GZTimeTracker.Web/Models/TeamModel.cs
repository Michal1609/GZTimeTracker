using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models
{
    public class TeamModel
    {
        public UserModel Owner { get; set; }
       
        public UserModel Member { get; set; }
    }
}
