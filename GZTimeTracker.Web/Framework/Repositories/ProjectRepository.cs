using AutoMapper;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
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

        public void CreateProject(ProjectModel projectModel, UserEntity owner)
        {
            if (projectModel == null)
                return;

            var projectEntity = _mapper.Map<ProjectEntity>(projectModel);
            projectEntity.Owner = owner;
            projectEntity = _unitOfWork.ProjectRepository.Insert(projectEntity);
            _unitOfWork.Save();

        }
    }
}
