using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class TaskRepository : Repository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(DataContext context)
            : base(context)
        {

        }

        public IList<TaskEntity> GetAllForProject(ProjectEntity projectEntity)
        {
            return (from row in table
                    where row.Project == projectEntity
                    select row).ToList();
        }
    }
}
