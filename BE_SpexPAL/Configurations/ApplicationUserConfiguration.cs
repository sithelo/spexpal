using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BE_SpexPAL.Models;

namespace BE_SpexPAL.Configurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(u => u.FirstName).HasMaxLength(30).IsRequired();
            Property(u => u.LastName).HasMaxLength(30).IsRequired();
            HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            
        }
    }
}