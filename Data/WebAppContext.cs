﻿using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Common;
using Data.Migrations;
using Ef6SchemaCompare;
using Model;
using WebGrease.Css.Extensions;

namespace Data
{
    public class WebAppContext : DbContext
    {
        public WebAppContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebAppContext, Configuration>("DefaultConnection"));

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Configurations.Add(new UserMap());
            //modelBuilder.Configurations.Add(new RoleMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
