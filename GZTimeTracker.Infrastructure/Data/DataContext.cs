﻿using GZIT.GZTimeTracker.Core.Infrastructure;
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
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<ActionEntity> Action { get; set; }
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<LocaleStringResourceEntity> LocaleStringResource { get; set; }
        public DbSet<LanguageEntity> Language { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasMany(a => a.Projets)
                .WithOne(e => e.Owner)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserEntity>()
                .HasMany(a => a.Team)
                .WithOne(e => e.Owner)
                .IsRequired();

            modelBuilder.Entity<LocaleStringResourceEntity>()
                .HasIndex(i => new { i.Language, i.Name });                


            modelBuilder.Entity<ActionEntity>().HasData(
                new ActionEntity() {Id = 1, Entity = "Project", Privilegia = "Full", Description = "Full privilegia" },
                new ActionEntity() { Id = 2, Entity = "Project", Privilegia = "Read" , Description = "Only readign" },
                new ActionEntity() { Id =3, Entity = "Project", Privilegia = "Update", Description = "Full privilegia withou delete" }
                );

        }

    }
}
