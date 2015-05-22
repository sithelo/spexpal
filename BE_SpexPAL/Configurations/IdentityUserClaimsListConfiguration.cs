using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BE_SpexPAL.Models;

namespace BE_SpexPAL.Configurations
{
    public class IdentityUserClaimsListConfiguration : EntityTypeConfiguration<IdentityUserClaimsList>
    {
        public IdentityUserClaimsListConfiguration()
        {
            ToTable("IdentityUserClaimsLists");
            HasKey(u => u.Id);
            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.ClaimsListType).HasMaxLength(30).IsRequired();
            Property(u => u.ClaimsListValue).HasMaxLength(30).IsRequired();
        }
    }
}