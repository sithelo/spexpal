using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BE_SpexPAL.Configurations;

using BE_SpexPAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BE_SpexPAL.DataContext
{
    public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDbContext()
            :base("AuthSpexPAL", throwIfV1Schema:false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
          // Database.SetInitializer<ApplicationUserDbContext>(new DropCreateDatabaseAlways<ApplicationUserDbContext>());
        }

        //public Dbs Type { get; set; }
        public static ApplicationUserDbContext Create()
        {
            return new ApplicationUserDbContext();
        }
        //ApplicationUser related tables
        public DbSet<Frontliner> Frontliners { get; set; }
        public DbSet<PracticeAddress> PracticeAddresses { get; set; }
        //table names changed
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new FrontlinerConfiguration());
            modelBuilder.Configurations.Add(new PracticeAddressConfiguration());
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        }
    }
}