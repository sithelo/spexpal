using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BE_SpexPAL.Models
{
    public class ClaimBindingModel
    {
        [Required]
       public string Type { get; set; }

        [Required]
      public string Value { get; set; }
    }
}