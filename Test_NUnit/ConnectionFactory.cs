using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Test
{
   public  class ConnectionFactory : IDisposable
    {
        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(CreateContextForInMemory());
        }

        private DataContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new DataContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
