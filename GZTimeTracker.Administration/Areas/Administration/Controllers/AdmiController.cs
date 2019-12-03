using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZTimeTracker.Administration.Areas.Administration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Administration.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class AdmiController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public AdmiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IActionResult> Index()
        {
            
            HomepageModel homepageModel = new HomepageModel();
            homepageModel.ProjectCount = await _unitOfWork.ProjectRepository.Count();
            homepageModel.TaskCount = await _unitOfWork.TaskRepository.Count();
            homepageModel.UsersCount = await _unitOfWork.UserRepository.Count();
            
            return View(homepageModel);
        }
    }
}