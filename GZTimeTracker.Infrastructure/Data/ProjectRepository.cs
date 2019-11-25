using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class ProjectRepository : Repository<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(DataContext context)
            : base(context)
        {

        }

        public ProjectEntity GetProjectForOwner(int projectId, UserEntity owner)
        {
            return (from row in table
                    where row.Id == projectId && row.Owner == owner
                    select row).FirstOrDefault();
        }

        public IList<ProjectEntity> GetProjectsForOwner(UserEntity owner)
        {
            return (from row in table where row.Owner == owner select row).ToList();
        }
    }
}
