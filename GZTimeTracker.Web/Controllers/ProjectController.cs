using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Web.Framework;
using GZTimeTracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GZTimeTracker.Web.Controllers
{
    public class ProjectController : BaseController
    {
        
        private readonly IMapper _mapper;
     

        public ProjectController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(languageServices, unitOfWork) 
        {        
            _mapper = mapper;
        }
       
        [HttpGet]
        public IActionResult Index()
        {           

            IList<ProjectModel> projects = new List<ProjectModel>();

            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var projectsEntity = _unitOfWork.ProjectRepository.GetProjectsForOwner(owner);

            foreach (var project in projectsEntity)
                projects.Add(_mapper.Map<ProjectModel>(project));

            
            return View(projects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectModel projectModel)
        {
            if (projectModel is null)
                return View();

            var project = _mapper.Map<ProjectEntity>(projectModel);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            project.Owner = _unitOfWork.UserRepository.GetUserByUserId(Guid.Parse(userId));

            _unitOfWork.ProjectRepository.Insert(project);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var project = _unitOfWork.ProjectRepository.GetProjectForOwner(id, owner);
            if (project == null)
                return BadRequest("Nemáte oprávnění");               

            _unitOfWork.ProjectRepository.Delete(id);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            // Get project
            var projectEntity = _unitOfWork.ProjectRepository.GetProjectForOwner(id, owner);
            var projectModel = _mapper.Map<ProjectModel>(projectEntity);

            // Get tasks for project
            var tasksEntity = _unitOfWork.TaskRepository.GetAllForProject(projectEntity); 
            projectModel.Tasks = _mapper.Map<IList<TaskModel>>(tasksEntity);
            
            return View(projectModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromForm] ProjectModel projectModel)
        {           
                
            if (projectModel is null)
                return RedirectToAction(nameof(Index));

            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var projectEntity = _unitOfWork.ProjectRepository.GetProjectForOwner(id, owner);
            projectEntity.Name = projectModel.Name;
            projectEntity.Description = projectModel.Description;
            projectEntity.StarTimeUTC = projectModel.StarTimeUTC;
            projectEntity.EndTimeUTC = projectModel.EndTimeUTC;

            // save project changes
            _unitOfWork.ProjectRepository.Update(projectEntity);
            
            // save tasks
            foreach(var taskModel in projectModel.Tasks)
            {
                var taskEntity = await _unitOfWork.TaskRepository.GetById(taskModel.Id);
                if (taskEntity == null)
                    continue;

                taskEntity.Name = taskModel.Name;
                _unitOfWork.TaskRepository.Update(taskEntity);
            }

            // save changes
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var projectEntity = _unitOfWork.ProjectRepository.GetProjectForOwner(id, owner);
            if (projectEntity == null)
                return BadRequest("Nemáte oprávnění");

            var projectModel = _mapper.Map<ProjectModel>(projectEntity);
            
            if (projectModel == null)
                return RedirectToAction(nameof(Index));
            return View(projectModel);
        }

        [HttpPost]
        public IActionResult CreateTask(string name, int projectId)
        {
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var projectEntity = _unitOfWork.ProjectRepository.GetProjectForOwner(projectId, owner);
            if (projectEntity == null)
                return BadRequest("Nemáte oprávnění");

            TaskEntity taskEntity = new TaskEntity();
            taskEntity.Name = name;
            taskEntity.Project = projectEntity;
            _unitOfWork.TaskRepository.Insert(taskEntity);
            _unitOfWork.Save();

            return  Redirect(Request.Headers["Referer"].ToString());           
        }

        public IActionResult DeleteTask(int id, int projectId)
        {
            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var projectEntity = _unitOfWork.ProjectRepository.GetProjectForOwner(projectId, owner);
            if (projectEntity == null)
                return BadRequest("Nemáte oprávnění");

            _unitOfWork.TaskRepository.Delete(id);
            _unitOfWork.Save();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
    
}