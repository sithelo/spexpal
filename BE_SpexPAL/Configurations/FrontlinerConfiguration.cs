using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BE_SpexPAL.Models;

namespace BE_SpexPAL.Configurations
{
    public class FrontlinerConfiguration : EntityTypeConfiguration<Frontliner>
    {
        public FrontlinerConfiguration()
        {
            ToTable("Frontliners");
            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.FirstName).HasMaxLength(30).IsRequired();
            Property(u => u.LastName).HasMaxLength(30).IsRequired();
            HasOptional<ApplicationUser>(f => f.User)
                .WithMany(f => f.Frontliners)
                .HasForeignKey(f => f.UserId);
            
        }
    }
}