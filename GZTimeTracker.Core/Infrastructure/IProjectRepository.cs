using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface IProjectRepository : IRepository<ProjectEntity>
    {
        IList<ProjectEntity> GetProjectsForOwner(UserEntity owner);

        ProjectEntity GetProjectForOwner(int projectId, UserEntity owner);
    }
}
