using AutoMapper;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZTimeTracker.Web.Framework.Role;
using GZTimeTracker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GZTimeTracker.Web.Framework.Repositories
{
    public class ProjectRepository
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ProjectModel GetProject(int id)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IList<ProjectModel> GetProjectsForUser(UserEntity user)
        {
            // Get projects
            var projectEntities = _unitOfWork.ProjectRepository.GetProjectsForOwner(user);

            if (projectEntities == null)
                return new List<ProjectModel>();

            return _mapper.Map<List<ProjectModel>>(projectEntities);
        }

        public IList<ProjectModel> GetActiveProjectsForUser(UserEntity user)
        {
            // Get projects            
            var projectEntities = _unitOfWork.ProjectRepository.Get(
                x => x.Owner.Id == user.Id &&
                (
                    x.EndTimeUTC >= DateTime.UtcNow || x.EndTimeUTC == null)
                    && (x.StarTimeUTC <= DateTime.UtcNow || x.StarTimeUTC == null)
                    );

            if (projectEntities == null)
                return new List<ProjectModel>();

            return _mapper.Map<List<ProjectModel>>(projectEntities);
        }

        internal IList<TaskForRunModel> GetTasksForRun(int userId)
        {
            //Get running task
            var runningTask = GetRunningTasks(userId);

            // Get task which runs today
            var todayTasks = _unitOfWork.SpendTimeRepository.Get(x => x.Date == DateTime.Now.Date && x.UserId == userId).ToList();

            var tasksForRun = new List<TaskForRunModel>();
            foreach (var task in todayTasks)
            {
                var taskEntity = _unitOfWork.TaskRepository.GetById(task.TaskId);

                tasksForRun.Add(new TaskForRunModel()
                {
                    Id = task.TaskId,
                    ProjectCode = _unitOfWork.ProjectRepository.GetById(taskEntity.Project.Id).Code,
                    SpendTime = task.SpandedTime,
                    TaskName = taskEntity.Name,
                    Running = false
                });
            }

            if (runningTask != null && !tasksForRun.Exists(x => x.Id == runningTask.TaskId))
            {
                var task = _unitOfWork.TaskRepository.GetById(runningTask.TaskId);
                tasksForRun.Add(new TaskForRunModel()
                {                    
                    Id = runningTask.TaskId,
                    ProjectCode = _unitOfWork.ProjectRepository.GetById(task.Project.Id).Code,
                    SpendTime = new TimeSpan(0, 0, 0),
                    TaskName = task.Name,
                    Running = true
                }); ;
            }
            else if(runningTask != null)
            {
                var task = tasksForRun.Find(x => x.Id == runningTask.TaskId);                
                if (task != null) task.Running = true;
            }            

            return tasksForRun;
        }

        public void CreateProject(ProjectModel projectModel, UserEntity owner)
        {
            if (projectModel == null)
                return;
            
            // Save project
            var projectEntity = _mapper.Map<ProjectEntity>(projectModel);
            projectEntity.Owner = owner;
            projectEntity = _unitOfWork.ProjectRepository.Insert(projectEntity);
            _unitOfWork.Save();

            //Ad user role for project
            RoleServices roleServices = new RoleServices(_unitOfWork);
            roleServices.SetRoleForNewProjectAndSave(owner.Id, projectEntity.Id);
        }        

        public IList<TaskModel> GetTasksForProject(int id)
        {
            return _mapper.Map<List<TaskModel>>(_unitOfWork.TaskRepository.Get(x => x.Project.Id == id).ToList());
        }

        public RunningTaskModel GetRunningTasks(int userId)
        {
            return _mapper.Map<RunningTaskModel>(_unitOfWork.RunningTaskRepository.Get(x => x.UserId == userId).FirstOrDefault());
        }
   
        public void RunTask(int userId, int taskId)
        {
            // check if task is not runnig
            var runningTask = _unitOfWork.RunningTaskRepository.Get(x => x.TaskId == taskId && x.UserId == userId).FirstOrDefault();
            if (runningTask != null)
                return; // is running, nothing to do

            // finish another runnig task if exist
            var task = _unitOfWork.RunningTaskRepository.Get(x => x.UserId == userId).FirstOrDefault();
            if (task != null)
            {
                // add spend time 
                InsertTimeToTask(task.TaskId, DateTime.UtcNow - task.StarTimeUTC, userId);
                // delete runnig task
                _unitOfWork.RunningTaskRepository.Delete(new List<RunningTaskEntity>() { task });
                _unitOfWork.Save();
            }

            // save new task
            _unitOfWork.RunningTaskRepository.Insert(new RunningTaskEntity()
            {
                TaskId = taskId,
                UserId = userId,
                StarTimeUTC = DateTime.UtcNow
            });
            _unitOfWork.Save();
        }

        public void StopTask(int taskId, int userId)
        {
            var task = _unitOfWork.RunningTaskRepository.Get(x => x.UserId == userId && x.TaskId == taskId).FirstOrDefault();
            if (task == null)
                return; // task not exists, nothing to stop

            // append time
            InsertTimeToTask(taskId, DateTime.UtcNow - task.StarTimeUTC, userId);

            //delete runnig task
            _unitOfWork.RunningTaskRepository.Delete(new List<RunningTaskEntity>() { task });
            _unitOfWork.Save();

        }

        private void InsertTimeToTask(int taskId, TimeSpan time, int userId)
        {
            var todayTask = _unitOfWork.SpendTimeRepository
                .Get(x => x.TaskId == taskId && x.Date == DateTime.Now.Date && x.UserId == userId)
                .FirstOrDefault();

            if (todayTask != null)
            {
                todayTask.SpandedTime += time;
                _unitOfWork.Save();
            }
            else
            {
                // firt run today
                _unitOfWork.SpendTimeRepository.Insert(new SpendTimeEntity()
                {
                    TaskId = taskId,
                    UserId = userId,
                    Date = DateTime.Now.Date,
                    SpandedTime = time

                });
                _unitOfWork.Save();
            }
        }
    }
}
