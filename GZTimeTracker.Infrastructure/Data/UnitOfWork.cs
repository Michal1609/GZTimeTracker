using GZIT.GZTimeTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;


namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private IRepository<Project> _projectRepository;
        

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<Project> ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new Repository<Project>(_context);
                }
                return _projectRepository;
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

