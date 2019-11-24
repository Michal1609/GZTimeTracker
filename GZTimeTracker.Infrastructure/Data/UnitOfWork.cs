using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private IUserRepository _userRepository;
        private ILocaleStringResourceRepository _localeStringResourceRepository;
        private IRepository<ProjectEntity> _projectRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<TeamEntity> _teamRepository;
        private IRepository<ActionEntity> _actionRepository;
        private IRepository<ClientEntity> _clientRepository;
        private IRepository<TaskEntity> _taskRepository;
        private IRepository<LanguageEntity> _languageRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
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

        public IRepository<ProjectEntity> ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new Repository<ProjectEntity>(_context);
                }
                return _projectRepository;
            }
        }

        public IRepository<RoleEntity> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new Repository<RoleEntity>(_context);
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

        public IRepository<ClientEntity> ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new Repository<ClientEntity>(_context);
                }
                return _clientRepository;
            }
        }

        public IRepository<TaskEntity> TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new Repository<TaskEntity>(_context);
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

        public void Save()
        {
            _context.SaveChanges();
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

