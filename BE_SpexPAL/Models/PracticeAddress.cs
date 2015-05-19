using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE_SpexPAL.Models
{
    public class PracticeAddress
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public virtual ApplicationUser User { get; set; } 
    }
}
