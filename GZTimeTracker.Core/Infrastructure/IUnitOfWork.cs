using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IRepository<RoleEntity> RoleRepository { get; }
        IRepository<TeamEntity> TeamRepository { get; }
        IClientRepository ClientRepository { get; }
        ITaskRepository TaskRepository { get; }
        IRepository<ActionEntity> ActionRepository { get; }
        ILocaleStringResourceRepository LocaleStringResourceRepository { get; }
        IRepository<LanguageEntity> LanguageRepository { get; }
        void Save();

    }
}
