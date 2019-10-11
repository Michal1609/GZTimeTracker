using GZIT.GZTimeTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Project> ProjectRepository { get; }
        void Save();

    }
}
