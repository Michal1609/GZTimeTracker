using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class DataContext : IdentityDbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }

        public DbSet<ExceptionlogEntity> ExceptionLog { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProjectEntity> Project { get; set; }
        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<TaskEntity> Task { get; set; }        
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<LocaleStringResourceEntity> LocaleStringResource { get; set; }
        public DbSet<LanguageEntity> Language { get; set; }
        public DbSet<ActionEntity> Action { get; set; }
        public DbSet<SystemRoleEntity> SystemRoles { get; set; }
        public DbSet<SystemRoleActionsEntity> SystemRoleActions { get; set; }
        public DbSet<CustomerRolesEntity> CustomerRoles { get; set; }
        public DbSet<CustomerRoleActionsEntity> CustomerRoleActions { get; set; }
        public DbSet<UserInRoleEntity> UserInRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(x => x.Client)
                .WithMany("Projects")
                .HasForeignKey("ClientId")
                .IsRequired(false);

            modelBuilder.Entity<UserEntity>()
                .HasMany(a => a.Projets)
                .WithOne(e => e.Owner)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserEntity>()
                .HasMany(a => a.Team)
                .WithOne(e => e.User)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LocaleStringResourceEntity>()
                .HasIndex(i => new { i.LanguageId, i.Name });

            /* Role definitons */
            modelBuilder.Entity<SystemRoleActionsEntity>()
                  .HasOne(a => a.SystemRole)
                  .WithMany(b => b.SystemRoleActions)
                  .OnDelete(DeleteBehavior.Cascade)
                  .IsRequired();

            modelBuilder.Entity<SystemRoleActionsEntity>()
                .HasOne(a => a.Action)
                .WithMany(b => b.SystemRoleActions)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<CustomerRoleActionsEntity>()
                 .HasOne(a => a.CustomerRole)
                 .WithMany(b => b.CustomerRoleActions)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            modelBuilder.Entity<CustomerRoleActionsEntity>()
                .HasOne(a => a.Action)
                .WithMany(b => b.CustomerRoleActions)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<CustomerRolesEntity>()
                .HasOne(a => a.User)
                .WithMany(b => b.CustomerRoles)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<UserInRoleEntity>()
                .HasOne(a => a.Project)
                .WithMany(b => b.UserInRoles)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<UserInRoleEntity>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserInRoles)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            /*
            modelBuilder.Entity<ActionEntity>().HasData(
                new ActionEntity() {Id = 1, Entity = "Project", Privilegia = "Full", Description = "Full privilegia" },
                new ActionEntity() { Id = 2, Entity = "Project", Privilegia = "Read" , Description = "Only readign" },
                new ActionEntity() { Id =3, Entity = "Project", Privilegia = "Update", Description = "Full privilegia withou delete" }
                );
            
            modelBuilder.Entity<LanguageEntity>().HasData(
                new LanguageEntity() { Id = 1, Code = "cs", Name = "Čeština" });
                */

            modelBuilder.Entity<SystemRoleEntity>().HasData(                
                new SystemRoleEntity() { Id = 1, Name = "admin", Description = "Administrátor" },
                new SystemRoleEntity() { Id = 2, Name = "manager", Description = "Manager" },
                new SystemRoleEntity() { Id = 3, Name = "guest", Description = "Host" }
                );

            modelBuilder.Entity<ActionEntity>().HasData(
                new ActionEntity() { Id = 1, Action = "project.create" },
                new ActionEntity() { Id = 2, Action = "project.edit" },
                new ActionEntity() { Id = 3, Action = "project.delete" },
                new ActionEntity() { Id = 4, Action = "project.read" }
                );

            modelBuilder.Entity<SystemRoleActionsEntity>().HasData(
                new SystemRoleActionsEntity() { Id = 1, SystemRoleId = 1, ActionId = 1 },
                new SystemRoleActionsEntity() { Id = 2, SystemRoleId = 1, ActionId = 2 },
                new SystemRoleActionsEntity() { Id = 3, SystemRoleId = 1, ActionId = 3 },
                new SystemRoleActionsEntity() { Id = 4, SystemRoleId = 1, ActionId = 4 },
                new SystemRoleActionsEntity() { Id = 5, SystemRoleId = 2, ActionId = 1 },
                new SystemRoleActionsEntity() { Id = 6, SystemRoleId = 2, ActionId = 2 },
                new SystemRoleActionsEntity() { Id = 7, SystemRoleId = 2, ActionId = 4 }
                );
        }

      

    }
}
