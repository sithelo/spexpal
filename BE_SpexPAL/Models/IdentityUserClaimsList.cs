using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE_SpexPAL.Models
{
    public class IdentityUserClaimsList
    {
        public int Id { get; set; }
        public string ClaimsListType { get; set; }
        public string ClaimsListValue { get; set; }
    }
}