using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;


namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        private DataContext _context;
        private IRepository<SystemInformationEntity> _systemInformationRepository;
        private IUserRepository _userRepository;
        private ILocaleStringResourceRepository _localeStringResourceRepository;
        private IProjectRepository _projectRepository;       
        private IRepository<TeamEntity> _teamRepository;
        private IRepository<ActionEntity> _actionRepository;
        private IClientRepository _clientRepository;
        private ITaskRepository _taskRepository;
        private IRepository<LanguageEntity> _languageRepository;
        private IRepository<RoleActionsEntity> _roleActionsRepository;
        private IRoleRepository _roleRepository;
        private IRepository<SystemRoleEntity> _systemRoleRepositoryRepository;
        private IRepository<SystemRoleActionsEntity> _systemRoleAction;

        public UnitOfWork(DataContext context)
        {
            _context = context;            
        }

        public IRepository<SystemInformationEntity> SystemInformationRepository
        {
            get
            {
                if (_systemInformationRepository == null)
                {
                    _systemInformationRepository = new Repository<SystemInformationEntity>(_context);
                }
                return _systemInformationRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new ProjectRepository(_context);
                }
                return _projectRepository;
            }
        }

        
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(_context);
                }
                return _roleRepository;
            }
        }
        

        public IRepository<TeamEntity> TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                {
                    _teamRepository = new Repository<TeamEntity>(_context);
                }
                return _teamRepository;
            }
        }

        public IRepository<ActionEntity> ActionRepository
        {
            get
            {
                if (_actionRepository == null)
                {
                    _actionRepository = new Repository<ActionEntity>(_context);
                }
                return _actionRepository;
            }
        }

        public IClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_context);
                }
                return _clientRepository;
            }
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_context);
                }
                return _taskRepository;
            }
        }

        public ILocaleStringResourceRepository LocaleStringResourceRepository
        {
            get
            {
                if (_localeStringResourceRepository == null)
                {
                    _localeStringResourceRepository =  new LocaleStringResourcesRepository(_context);
                }
                return _localeStringResourceRepository;
            }
        }

        public IRepository<LanguageEntity> LanguageRepository
        {
            get
            {
                if (_languageRepository == null)
                {
                    _languageRepository = new Repository<LanguageEntity>(_context);
                }
                return _languageRepository;
            }
        }

        public IRepository<RoleActionsEntity> RoleActionsRepository
        {
            get
            {
                if (_roleActionsRepository == null)
                {
                    _roleActionsRepository = new Repository<RoleActionsEntity>(_context);
                }
                return _roleActionsRepository;
            }
        }

        public IRepository<SystemRoleEntity> SystemRoleRepository
        {
            get
            {
                if (_systemRoleRepositoryRepository == null)
                {
                    _systemRoleRepositoryRepository = new Repository<SystemRoleEntity>(_context);
                }
                return _systemRoleRepositoryRepository;
            }
        }

        public IRepository<SystemRoleActionsEntity> SystemRoleActionsRepository
        {
            get
            {
                if (_systemRoleAction == null)
                {
                    _systemRoleAction = new Repository<SystemRoleActionsEntity>(_context);
                }
                return _systemRoleAction;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                Save();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

