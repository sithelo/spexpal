using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE_SpexPAL.Models
{
    public class Frontliner
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
       public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
