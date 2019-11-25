using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        IList<TaskEntity> GetAllForProject(ProjectEntity projectEntity);
    }
}
