using GZIT.GZTimeTracker.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DataContext : DbContext
    {  

        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
            
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Task> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                  
            
        }
    }
}
