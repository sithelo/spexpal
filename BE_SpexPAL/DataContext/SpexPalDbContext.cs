using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BE_SpexPAL.Models;

namespace BE_SpexPAL.DataContext
{
    public class SpexPalDbContext : DbContext
    {
        public SpexPalDbContext()
            : base("SpexPalData")
        {

        }
        public DbSet<IdentityUserClaimsList> IdentityUserClaimsLists { get; set; }
    }
}