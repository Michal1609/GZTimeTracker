using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GZTimeTracker.Web.Models;
using GZTimeTracker.Web.Framework;
using GZIT.GZTimeTracker.Core.Web;
using GZIT.GZTimeTracker.Core.Infrastructure;

namespace GZTimeTracker.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IRoleServices roleServices) : base(languageServices, unitOfWork, roleServices)
        {
            //_logger = logger;            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
