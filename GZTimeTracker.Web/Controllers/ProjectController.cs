using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Web.Framework;
using GZTimeTracker.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Web.Controllers
{
    public class ProjectController : BaseController
    {

        public ProjectController(ILanguageServices languageServices) : base(languageServices) { }
        public IActionResult Index()
        {           

            ProjectModel project = new ProjectModel()
            {
                Code = "001",
                Description = "Projekt na dve veci",
                Name = "Projekt1",
                EndTimeUTC = DateTime.Now,
                StarTimeUTC = DateTime.Now
            };

            List<ProjectModel> list = new List<ProjectModel>();
            list.Add(project);
            return View(list);
        }
    }
}