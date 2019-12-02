using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Administration.Areas.Administration.Models
{
    public class LanguageModel
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        public string Code { get; set; }

        public decimal Version { get; set; }
    }
}
