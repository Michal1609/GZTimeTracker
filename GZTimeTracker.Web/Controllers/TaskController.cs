using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Web.Controllers
{
    public class TaskController : BaseController
    {        
        private readonly IMapper _mapper;

        public TaskController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(languageServices, unitOfWork)
        {            
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}