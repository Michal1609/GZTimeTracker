using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<SystemInformationEntity> SystemInformationRepository { get; }
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }
        //IRoleRepository RoleRepository { get; }
        IRepository<TeamEntity> TeamRepository { get; }
        IClientRepository ClientRepository { get; }
        ITaskRepository TaskRepository { get; }
        IRepository<ActionEntity> ActionRepository { get; }
        ILocaleStringResourceRepository LocaleStringResourceRepository { get; }
        IRepository<LanguageEntity> LanguageRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRepository<SystemRoleEntity> SystemRoleRepository { get; }
        IRepository<SystemRoleActionsEntity> SystemRoleActionsRepository { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
        void Save();

    }
}
