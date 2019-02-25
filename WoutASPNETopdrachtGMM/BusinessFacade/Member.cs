using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessFacade
{
    [Table("Member")]
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Function Function { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
    }
}
