using System.Collections.Generic;
using BE_SpexPAL.DataContext;
using BE_SpexPAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BE_SpexPAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BE_SpexPAL.DataContext.ApplicationUserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BE_SpexPAL.DataContext.ApplicationUserDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationUserDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationUserDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "sithelo",
                Email = "sithelo@gmail.com",
                EmailConfirmed = true,
                FirstName = "Sithelo",
                LastName = "Ngwenya",
                ContactPerson = "Sithelo",
                ContactPhone = "0116402220",
                RegistrationDate = DateTime.UtcNow,
                PracticeAddress = new PracticeAddress() { City = "Johannesburg", PostalCode = "2192", Street = "71 Orchards Road", Suburb = "Cheltondale"},
                Frontliners = new List<Frontliner>() { new Frontliner() { ModifiedDate = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, FirstName = "Paul", LastName = "Smith" }, new Frontliner() { ModifiedDate = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, FirstName = "British", LastName = "Maloka" } }
            };

            manager.Create(user, "Sinikiwe");

            if (roleManager.Roles.Count() == 0)
            {
               
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByName("sithelo");

            manager.AddToRoles(adminUser.Id, new string[] { "User", "Admin" });
          
        }
    }
}
