using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Models.ViewModels
{
    public class ProjectEditViewModel
    {
        public ProjectModel Project { get; set; }

        public IList<ClientModel> Clients { get; set; }
    }
}
