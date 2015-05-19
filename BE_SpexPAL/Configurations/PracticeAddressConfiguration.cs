using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BE_SpexPAL.Models;

namespace BE_SpexPAL.Configurations
{
    public class PracticeAddressConfiguration : EntityTypeConfiguration<PracticeAddress>
    {
        public PracticeAddressConfiguration()
        {
            ToTable("PracticeAddresses");
            HasKey(e => e.Id);
            HasRequired(ad => ad.User).WithOptional(s => s.PracticeAddress);
        }
    }
}