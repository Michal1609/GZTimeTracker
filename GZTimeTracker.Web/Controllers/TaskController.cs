using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class TaskController : BaseController
    {        
        private readonly IMapper _mapper;

        public TaskController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRoleServices roleServices) : base(languageServices, unitOfWork, roleServices)
        {            
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}