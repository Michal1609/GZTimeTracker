using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Web.Framework.Repositories;
using GZTimeTracker.Web.Models;
using GZTimeTracker.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Web.Controllers
{
    public class TimeController : BaseController
    {

        private readonly IMapper _mapper;
       
        public TimeController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRoleServices roleServices
           ) : base(languageServices, unitOfWork, roleServices)
        {
            _mapper = mapper;           
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentUser = GetUser();
            var viewModel = new TimeIndexViewModel();
            ProjectRepository projectRepository = new ProjectRepository(_unitOfWork, _mapper);

            // Get all tasks for first project in the list
            viewModel.Projects = projectRepository.GetActiveProjectsForUser(currentUser);
            if (viewModel.Projects.Count > 0)
                viewModel.Projects[0].Tasks = projectRepository.GetTasksForProject(viewModel.Projects[0].Id);           

            // get tasks for run
            viewModel.TasksForRun = projectRepository.GetTasksForRun(currentUser.Id);

            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetTasks(int id)
        {
            var tasks = _unitOfWork.TaskRepository.GetAllForProject(
                _unitOfWork.ProjectRepository.GetById(id)).ToList();

            var tasksModel = _mapper.Map<List<TaskModel>>(tasks);

            return new JsonResult(tasksModel);
        }

        [HttpGet]
        public JsonResult AddTask(int id)
        {
            var currentUser = GetUser();
            var viewModel = new TimeIndexViewModel();
            //ProjectRepository projectRepository = new ProjectRepository(_unitOfWork, _mapper);
            IList<TaskForRunModel> tasks = new System.Collections.Generic.List<TaskForRunModel>();
            //tasks = projectRepository.GetTasksForRun(currentUser.Id);

            var task = _unitOfWork.TaskRepository.GetById(id);
            if (task != null)
            {
                tasks.Add(new TaskForRunModel()
                {
                    Id = task.Id,
                    Running = false,
                    SpendTime = new TimeSpan(0, 0, 0),
                    TaskName = task.Name,
                    ProjectCode = _unitOfWork.ProjectRepository.GetById(task.Project.Id).Code
                });
            }

            return new JsonResult(tasks);
        }

        public IActionResult TaskStart(int id)
        {
            ProjectRepository projectRepository = new ProjectRepository(_unitOfWork, _mapper);

            projectRepository.RunTask(GetUser().Id, id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult TaskStop(int id)
        {
            ProjectRepository projectRepository = new ProjectRepository(_unitOfWork, _mapper);

            projectRepository.StopTask(id, GetUser().Id);

            return RedirectToAction(nameof(Index));
        }
    }
}