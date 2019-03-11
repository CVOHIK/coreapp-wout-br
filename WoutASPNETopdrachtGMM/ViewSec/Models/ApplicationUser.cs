using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViewSec.Models
{
    [Table("AspNetUser")]
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
