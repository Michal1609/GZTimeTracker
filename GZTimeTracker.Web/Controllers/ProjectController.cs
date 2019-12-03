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
using GZTimeTracker.Web.Models.ViewModels;
using GZTimeTracker.Web.Framework.Repositories;
using GZIT.GZTimeTracker.Core.Domain;
using GZIT.GZTimeTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;

namespace GZTimeTracker.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class ProjectController : BaseController
    {        
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public ProjectController(
            ILanguageServices languageServices,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRoleServices roleServices,
            IEmailSender emailSender) : base(languageServices, unitOfWork, roleServices) 
        {        
            _mapper = mapper;
            _emailSender = emailSender;
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjectModel projectModel)
        {
            if (projectModel is null)
                return View();
            
            ProjectRepository projectRepository = new ProjectRepository(_unitOfWork, _mapper);
            
            projectRepository.CreateProject(projectModel, GetUser());

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

            if (!HasUserPrivilegia(owner.Id, id, ActionsPrivilegia.ProjectEdit))
            {
                return BadRequest("Nedostatečná oprávnění");
            }

            // Get project
            var projectEntity = _unitOfWork.ProjectRepository.GetProjectForOwner(id, owner);
            var projectModel = _mapper.Map<ProjectModel>(projectEntity);

            // Get tasks for project
            var tasksEntity = _unitOfWork.TaskRepository.GetAllForProject(projectEntity); 
            projectModel.Tasks = _mapper.Map<IList<TaskModel>>(tasksEntity);

            // Get all lients for html Dropdawn
            List<ClientModel> clients = _mapper.Map<List<ClientModel>>(_unitOfWork.ClientRepository.GetClientsForOwner(owner));

            ProjectEditViewModel projectEditViewModel = new ProjectEditViewModel();
            projectEditViewModel.Project = projectModel;
            projectEditViewModel.Clients = clients;

            return View(projectEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromForm] ProjectEditViewModel projectEditViewModel)
        {           
                
            if (projectEditViewModel is null)
                return RedirectToAction(nameof(Index));

            var owner = GetUser();
            if (owner == null)
                return BadRequest("Nepřihlášený uživatel");

            var projectModel = projectEditViewModel.Project;
            var projectEntity = _unitOfWork.ProjectRepository.GetProjectForOwner(id, owner);
            projectEntity.Name = projectModel.Name;
            projectEntity.Description = projectModel.Description;
            projectEntity.StarTimeUTC = projectModel.StarTimeUTC;
            projectEntity.EndTimeUTC = projectModel.EndTimeUTC;

            // add client
            if (projectModel.ClientId != null)
                projectEntity.Client = _unitOfWork.ClientRepository.GetClientForOwner(owner, (int)projectModel.ClientId);

            // save project changes
            _unitOfWork.ProjectRepository.Update(projectEntity);
            
            // save tasks
            foreach(var taskModel in projectModel.Tasks)
            {
                var taskEntity = await _unitOfWork.TaskRepository.GetByIdAsync(taskModel.Id);
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

            if (projectModel.ClientId > 0)
                projectModel.Client = _mapper.Map<ClientModel>
                    (_unitOfWork.ClientRepository.GetClientForOwner(owner, (int)projectModel.ClientId));
            
            if (projectModel == null)
                return RedirectToAction(nameof(Index));

            projectModel.Tasks = _mapper.Map<List<TaskModel>>(_unitOfWork.TaskRepository.GetAllForProject(projectEntity));
            return View(projectModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            string returnUrl = Request.Headers["Referer"].ToString();
            if (Url.IsLocalUrl(returnUrl)) // Make sure the url is relative, not absolute path
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }                 
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

            string returnUrl = Request.Headers["Referer"].ToString();
            if (Url.IsLocalUrl(returnUrl)) // Make sure the url is relative, not absolute path
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
    }
    
}