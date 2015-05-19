using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BE_SpexPAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        //public string Status { get; set; }
        public virtual PracticeAddress PracticeAddress { get; set; }
        public virtual ICollection<Frontliner> Frontliners { get; set; }
        
    }
}